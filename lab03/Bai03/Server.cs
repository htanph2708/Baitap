using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace lab03.Bai03
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private Thread listenThread;
        private const int PORT = 13000;
        private const string IP_ADDRESS = "127.0.0.1";

        public Server()
        {
            InitializeComponent();
            Listenbutton.Click += Listenbutton_Click;
            this.FormClosing += Server_FormClosing;
        }

        private void Listenbutton_Click(object sender, EventArgs e)
        {
            // Bắt đầu lắng nghe
            StartListening();
            Listenbutton.Enabled = false; // Vô hiệu hóa nút Listen sau khi khởi động
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dừng lắng nghe khi Form đóng
            StopListening();
        }

        private void StartListening()
        {
            try
            {
                // 1. Chạy Server
                listener = new TcpListener(IPAddress.Parse(IP_ADDRESS), PORT);
                listener.Start();
                UpdateLog($"Server đang lắng nghe trên {IP_ADDRESS}:{PORT}...");

                // 2. Chạy lắng nghe trong một Task/Luồng riêng
                listenThread = new Thread(new ThreadStart(AcceptClients));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                UpdateLog($"Lỗi khi bắt đầu lắng nghe: {ex.Message}");
            }
        }

        private async void AcceptClients()
        {
            while (true)
            {
                try
                {
                    // Chấp nhận kết nối từ Client
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    UpdateLog("Client đã kết nối!");

                    // 3. Xử lý giao tiếp Client trong Task riêng
                    Task.Run(() => HandleClientComm(client));
                }
                catch (SocketException)
                {
                    // Lỗi này thường xảy ra khi listener.Stop() được gọi
                    UpdateLog("Dừng lắng nghe.");
                    break;
                }
                catch (Exception ex)
                {
                    UpdateLog($"Lỗi AcceptClients: {ex.Message}");
                }
            }
        }

        private void HandleClientComm(TcpClient client)
        {
            NetworkStream clientStream = client.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    // 4. Nhận thông điệp từ Client
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    // Lỗi socket hoặc lỗi ngắt kết nối
                    break;
                }

                if (bytesRead == 0)
                {
                    // Client đã ngắt kết nối
                    break;
                }

                // 5. Hiển thị thông điệp lên Form (textbox1)
                string receivedMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                UpdateLog($"Client: {receivedMessage}");
            }

            UpdateLog("Client đã ngắt kết nối.");
            client.Close();
        }

        private void StopListening()
        {
            listener?.Stop();
        }

        private void UpdateLog(string message)
        {
            // Sử dụng Invoke để cập nhật UI từ một luồng khác
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new MethodInvoker(delegate
                {
                    textBox1.AppendText($"{DateTime.Now.ToLongTimeString()} - {message}{Environment.NewLine}");
                }));
            }
            else
            {
                textBox1.AppendText($"{DateTime.Now.ToLongTimeString()} - {message}{Environment.NewLine}");
            }
        }
    }
}