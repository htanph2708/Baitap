// File: Server.cs (Phần Logic)

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;

namespace lab03.Bai04
{
    public partial class Server : Form
    {
        // Networking & Đồng bộ
        private TcpListener _listener;
        private Thread _listenerThread;
        private List<TcpClient> _clients = new List<TcpClient>();

        // Dữ liệu Ghế Dùng Chung
        private bool[] _seats = new bool[9];
        private readonly object _lock = new object(); // KHÓA ĐỒNG BỘ

        public Server()
        {
            InitializeComponent();
            this.Load += Server_Load;
            btnStartServer.Click += btnStartServer_Click;

            // Khởi tạo trạng thái ghế ban đầu là trống
            for (int i = 0; i < 9; i++) _seats[i] = false;
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Log("Server sẵn sàng. Nhấn 'Start' để bắt đầu lắng nghe.");
        }

        private void Log(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(Log), message);
            }
            else
            {
                txtLog.AppendText($"[{DateTime.Now.ToShortTimeString()}] {message}{Environment.NewLine}");
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();

                _listenerThread = new Thread(ListenForClients);
                _listenerThread.IsBackground = true;
                _listenerThread.Start();

                lblServerStatus.Text = $"Đang chạy trên Port: {port}";
                Log($"Server đã khởi động trên Port: {port}");
            }
            catch (Exception ex)
            {
                Log($"Lỗi khởi động Server: {ex.Message}");
            }
        }

        private void ListenForClients()
        {
            while (true)
            {
                try
                {
                    TcpClient client = _listener.AcceptTcpClient();

                    lock (_lock)
                    {
                        _clients.Add(client);
                    }
                    Log($"Client {client.Client.RemoteEndPoint} đã kết nối. Tổng: {_clients.Count}");

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Log($"Lỗi lắng nghe: {ex.Message}");
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            string clientEndPoint = client.Client.RemoteEndPoint.ToString();

            try
            {
                SendFullStateToClient(client);

                while (client.Connected)
                {
                    // Nhận yêu cầu đặt vé
                    TicketMessage request = ReceiveMessage(client);

                    if (request != null && request.Action == ActionType.RequestBooking)
                    {
                        ProcessBookingRequest(request, client);
                    }
                }
            }
            catch (IOException)
            {
                Log($"Client {clientEndPoint} đã ngắt kết nối.");
            }
            catch (Exception ex)
            {
                Log($"Lỗi xử lý Client {clientEndPoint}: {ex.Message}");
            }
            finally
            {
                client.Close();
                lock (_lock)
                {
                    _clients.Remove(client);
                }
                Log($"Tổng số Client còn lại: {_clients.Count}");
            }
        }

        private TicketMessage ReceiveMessage(TcpClient client)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var stream = client.GetStream();
                    byte[] lengthBytes = new byte[4];
                    int read = stream.Read(lengthBytes, 0, 4);
                    if (read < 4) return null;
                    int length = BitConverter.ToInt32(lengthBytes, 0);
                    byte[] buffer = new byte[length];
                    read = stream.Read(buffer, 0, length);
                    if (read < length) return null;
                    ms.Write(buffer, 0, length);
                    ms.Position = 0;
                    return JsonSerializer.Deserialize<TicketMessage>(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }

        private void ProcessBookingRequest(TicketMessage request, TcpClient client)
        {
            int seatIndex = request.SeatIndex;
            TicketMessage response = null;

            lock (_lock)
            {
                if (seatIndex < 0 || seatIndex >= 9)
                {
                    response = new TicketMessage { Message = "Lỗi: Chỉ số ghế không hợp lệ." };
                }
                else if (_seats[seatIndex])
                {
                    response = new TicketMessage { Message = $"Ghế {seatIndex + 1} đã được đặt bởi quầy khác!" };
                    Log($"Yêu cầu đặt Ghế {seatIndex + 1} thất bại (Đã đặt) từ {client.Client.RemoteEndPoint}");
                }
                else
                {
                    // Đặt thành công
                    _seats[seatIndex] = true;
                    Log($"Đặt thành công Ghế {seatIndex + 1} từ {client.Client.RemoteEndPoint}");

                    BroadcastSeatUpdate(seatIndex, true, $"Quầy {client.Client.RemoteEndPoint} đã đặt Ghế {seatIndex + 1}!");
                    return;
                }
            }

            if (response != null)
                SendSingleMessage(client, response);
        }

        private void BroadcastSeatUpdate(int seatIndex, bool isBooked, string message)
        {
            TicketMessage updateMessage = new TicketMessage
            {
                Action = ActionType.UpdateSeatStatus,
                SeatIndex = seatIndex,
                IsBooked = isBooked,
                Message = message
            };

            lock (_lock)
            {
                var clientsCopy = new List<TcpClient>(_clients);
                foreach (var client in clientsCopy)
                {
                    SendSingleMessage(client, updateMessage);
                }
            }
        }

        private void SendFullStateToClient(TcpClient client)
        {
            lock (_lock)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (_seats[i])
                    {
                        TicketMessage initialUpdate = new TicketMessage
                        {
                            Action = ActionType.UpdateSeatStatus,
                            SeatIndex = i,
                            IsBooked = true,
                            Message = $"Ghế {i + 1} đã được đặt trước đó."
                        };
                        SendSingleMessage(client, initialUpdate);
                    }
                }
            }
        }

        private void SendSingleMessage(TcpClient client, TicketMessage message)
        {
            try
            {
                if (client.Client.Poll(0, SelectMode.SelectRead) && client.Client.Available == 0) return;

                lock (client)
                {
                    var stream = client.GetStream();
                    byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(message);
                    byte[] lengthBytes = BitConverter.GetBytes(jsonBytes.Length);
                    stream.Write(lengthBytes, 0, 4);
                    stream.Write(jsonBytes, 0, jsonBytes.Length);
                }
            }
            catch { }
        }
    }
}