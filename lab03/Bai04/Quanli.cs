// File: Quanli.cs (Đã loại bỏ txtClientLog)

using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace lab03.Bai04
{
    // Cần đảm bảo lớp TicketMessage và enum ActionType đã được định nghĩa
    public partial class Quanli : Form
    {
        private TcpClient _client;
        private Thread _receiveThread;
        private Button[] _seatButtons;
        private int? _selectedSeatIndex = null;

        // *Lưu ý: txtClientLog và hàm Log() đã bị xóa bỏ*

        public Quanli()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
            _seatButtons = new Button[] {
                Ghe1button, Ghe2button, Ghe3button, Ghe4button, Ghe5button,
                Ghe6button, Ghe7button, Ghe8button, Ghe9button
            };

            for (int i = 0; i < _seatButtons.Length; i++)
            {
                _seatButtons[i].Tag = i; // Gán chỉ số (0-8)
                _seatButtons[i].BackColor = Color.LightGray;
                _seatButtons[i].Click += SeatButton_Click;
            }

            btnConnect.Click += btnConnect_Click;
            btnXacNhan.Click += btnXacNhan_Click;
        }

        // Phương thức Log() đã bị xóa khỏi đây.

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_client != null && _client.Connected) return;

            try
            {
                string ip = txtServerIP.Text;
                int port = int.Parse(txtServerPort.Text);

                _client = new TcpClient();
                _client.Connect(ip, port);

                lblStatus.Text = "Đã kết nối";
                MessageBox.Show($"Đã kết nối tới Server {ip}:{port}", "Kết nối thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); // Thông báo thành công

                _receiveThread = new Thread(ReceiveMessages);
                _receiveThread.IsBackground = true;
                _receiveThread.Start();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Kết nối thất bại";
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); // Thông báo lỗi
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int seatIndex = (int)clickedButton.Tag;

            // KIỂM TRA MÀU ĐỎ (GHẾ ĐÃ ĐẶT)
            if (clickedButton.BackColor == System.Drawing.Color.Red)
            {
                MessageBox.Show($"Ghế {seatIndex + 1} đã được đặt! Vui lòng chọn ghế khác.",
                                "Ghế đã được đặt",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (!_client?.Connected ?? true)
            {
                MessageBox.Show("Vui lòng kết nối Server trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa trạng thái chọn tạm thời của ghế cũ (nếu có)
            if (_selectedSeatIndex.HasValue && _selectedSeatIndex.Value != seatIndex)
            {
                _seatButtons[_selectedSeatIndex.Value].BackColor = System.Drawing.Color.LightGray;
            }

            // Chọn ghế mới
            _selectedSeatIndex = seatIndex;
            clickedButton.BackColor = System.Drawing.Color.Yellow;
            // Không cần thông báo chọn tạm thời, chỉ cần thông báo khi xác nhận đặt vé.
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!_client?.Connected ?? true)
            {
                MessageBox.Show("Lỗi: Chưa kết nối Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_selectedSeatIndex.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một ghế trước khi xác nhận.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gửi yêu cầu đặt vé lên Server
            TicketMessage request = new TicketMessage
            {
                Action = ActionType.RequestBooking,
                SeatIndex = _selectedSeatIndex.Value
            };
            SendTicketMessage(request);
        }

        private void ReceiveMessages()
        {
            try
            {
                var stream = _client.GetStream();
                while (_client.Connected)
                {
                    // Logic nhận tin nhắn (Length-Prefixing)
                    byte[] lengthBytes = new byte[4];
                    int bytesRead = stream.Read(lengthBytes, 0, 4);
                    if (bytesRead == 0 || bytesRead < 4) break;

                    int length = BitConverter.ToInt32(lengthBytes, 0);

                    byte[] buffer = new byte[length];
                    int totalBytesRead = 0;
                    while (totalBytesRead < length)
                    {
                        int currentRead = stream.Read(buffer, totalBytesRead, length - totalBytesRead);
                        if (currentRead == 0) break;
                        totalBytesRead += currentRead;
                    }

                    if (totalBytesRead == length)
                    {
                        var message = JsonSerializer.Deserialize<TicketMessage>(buffer);
                        UpdateUI(message);
                    }
                }
            }
            catch (Exception)
            {
                if (_client != null) _client.Close();
                lblStatus.Invoke(new Action(() => lblStatus.Text = "Mất kết nối"));
            }
        }

        private void UpdateUI(TicketMessage message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TicketMessage>(UpdateUI), message);
                return;
            }

            // 1. XỬ LÝ LỖI ĐẶT VÉ TỪ SERVER (MESSAGEBOX)
            if (message.Action != ActionType.UpdateSeatStatus &&
                message.Message != null &&
                message.Message.Contains("đã được đặt bởi quầy khác"))
            {
                MessageBox.Show(message.Message, "Đặt vé thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reset ghế đang chọn tạm thời (màu vàng)
                if (_selectedSeatIndex.HasValue)
                {
                    _seatButtons[_selectedSeatIndex.Value].BackColor = Color.LightGray;
                    _selectedSeatIndex = null;
                }
                return;
            }

            // 2. XỬ LÝ CẬP NHẬT TRẠNG THÁI THÀNH CÔNG

            // Tùy chọn: Nếu muốn thông báo thành công sau khi xác nhận:
            if (message.Action == ActionType.UpdateSeatStatus && message.IsBooked)
            {
                // Chỉ thông báo nếu đây là hành động đặt vé thành công của chính Client này
                if (_selectedSeatIndex.HasValue && _selectedSeatIndex.Value == message.SeatIndex)
                {
                    MessageBox.Show($"Đặt Ghế {message.SeatIndex + 1} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Nếu là thông báo từ Client khác (đồng bộ hóa), không cần MessageBox.
            }

            if (message.Action == ActionType.UpdateSeatStatus && message.SeatIndex >= 0 && message.SeatIndex < 9)
            {
                int index = message.SeatIndex;
                Button seat = _seatButtons[index];

                if (message.IsBooked)
                {
                    seat.BackColor = Color.Red;
                    seat.Enabled = false;

                    // Reset trạng thái chọn tạm thời (vì đã hoàn tất)
                    if (_selectedSeatIndex.HasValue && _selectedSeatIndex.Value == index)
                    {
                        _selectedSeatIndex = null;
                    }
                }
                else
                {
                    // Logic hủy vé (nếu có)
                    seat.BackColor = Color.LightGray;
                    seat.Enabled = true;
                }
            }
        }

        private void SendTicketMessage(TicketMessage message)
        {
            try
            {
                lock (_client)
                {
                    var stream = _client.GetStream();
                    byte[] buffer = JsonSerializer.SerializeToUtf8Bytes(message);

                    // Send length prefix (4 bytes)
                    byte[] lengthBytes = BitConverter.GetBytes(buffer.Length);
                    stream.Write(lengthBytes, 0, 4);

                    // Send actual message
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}", "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}