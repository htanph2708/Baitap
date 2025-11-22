using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace lab03.Bai03
{
    public partial class client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream clientStream;
        private const int PORT = 13000;
        private const string IP_ADDRESS = "127.0.0.1";

        public client()
        {
            InitializeComponent();
            Connectbutton.Click += Connectbutton_Click;
            Sendbutton.Click += Sendbutton_Click;
            Disconnectbutton.Click += Disconnectbutton_Click;
            this.FormClosing += client_FormClosing;

            // Thiết lập trạng thái ban đầu
            Sendbutton.Enabled = false;
            Disconnectbutton.Enabled = false;
        }

        private void client_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ngắt kết nối khi Form đóng
            Disconnect();
        }

        private void Connectbutton_Click(object sender, EventArgs e)
        {
            // 3. Khởi tạo Client và kết nối
            Connect();
        }

        private void Disconnectbutton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            // 4. Gửi thông điệp từ Client đến Server
            string message = textBox1.Text;
            if (!string.IsNullOrEmpty(message))
            {
                SendMessage(message);
                textBox1.Clear(); // Xóa nội dung đã gửi
            }
        }

        private void Connect()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IP_ADDRESS, PORT);
                clientStream = tcpClient.GetStream();

                UpdateLog($"Đã kết nối thành công đến {IP_ADDRESS}:{PORT}");

                // Cập nhật UI
                Connectbutton.Enabled = false;
                Sendbutton.Enabled = true;
                Disconnectbutton.Enabled = true;
            }
            catch (Exception ex)
            {
                UpdateLog($"Lỗi kết nối: Server chưa chạy hoặc không tìm thấy. ({ex.Message})");
                Disconnect();
            }
        }

        private void Disconnect()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
                clientStream = null;
                UpdateLog("Đã ngắt kết nối.");

                // Cập nhật UI
                Connectbutton.Enabled = true;
                Sendbutton.Enabled = false;
                Disconnectbutton.Enabled = false;
            }
        }

        private void SendMessage(string message)
        {
            if (clientStream == null || !tcpClient.Connected)
            {
                UpdateLog("Chưa kết nối đến Server.");
                return;
            }

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                // Hiển thị thông điệp gửi đi
                UpdateLog($"Đã gửi: {message}");
            }
            catch (Exception ex)
            {
                UpdateLog($"Lỗi gửi tin: {ex.Message}");
                Disconnect();
            }
        }

        private void UpdateLog(string message)
        {
            // Hiển thị trạng thái lên chính TextBox (cần tách ra một TextBox riêng cho log để dễ quản lý hơn)
            // Hiện tại dùng chung textBox1, nên chỉ hiển thị thông báo trạng thái/lỗi
            // Nếu muốn hiện thị Log, nên đổi textBox1 thành 2 control: 1 cho Input, 1 cho Log

            // Thay đổi cách hiển thị để không lẫn lộn với thông điệp gửi:
            // Thường ta sẽ dùng một TextBox khác cho Log.

            // Giả sử có một TextBox riêng tên là txtLog thay vì textBox1:
            // txtLog.AppendText($"{DateTime.Now.ToLongTimeString()} - {message}{Environment.NewLine}");
        }
    }
}