using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab03.Bai02
{
    public partial class Listen : Form
    {
        private TcpListener listener;
        private bool isListening = false;
        private const int PORT = 8080; // Cổng Telnet mặc định theo yêu cầu

        public Listen()
        {
            InitializeComponent();
            // Đặt sự kiện Click cho Button "Listen"
            buttonListen.Click += buttonListen_Click;
        }

        private async void buttonListen_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                // 2. Nhấn nút Listen
                buttonListen.Text = "Stop Listening";
                isListening = true;
                await StartListeningAsync();
            }
            else
            {
                StopListening();
                buttonListen.Text = "Listen";
                isListening = false;
            }
        }

        private async Task StartListeningAsync()
        {
            try
            {
                // Khởi tạo TcpListener để lắng nghe trên mọi địa chỉ IP và cổng 8080
                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();
                AppendToLog($"*** Bắt đầu lắng nghe trên cổng {PORT}...");

                while (isListening)
                {
                    // Chờ và chấp nhận kết nối Telnet mới
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    AppendToLog("--- Đã có kết nối Telnet mới! ---");

                    // Xử lý việc nhận dữ liệu từ client trong một tác vụ nền
                    // Dấu gạch dưới (_) để bỏ qua cảnh báo vì tác vụ không được await
                    _ = HandleClientDataAsync(client);
                }
            }
            catch (SocketException ex) when (ex.ErrorCode == 10004)
            {
                // Lỗi 10004 (Operation aborted) thường xảy ra khi gọi listener.Stop()
                AppendToLog("--- Đã dừng lắng nghe. ---");
            }
            catch (Exception ex)
            {
                AppendToLog($"Lỗi chung: {ex.Message}");
                // Đảm bảo trạng thái nút được cập nhật nếu có lỗi
                buttonListen.Text = "Listen";
                isListening = false;
            }
        }

        private void StopListening()
        {
            isListening = false;
            if (listener != null)
            {
                // Dừng listener. Việc này sẽ kích hoạt lỗi 10004 ở hàm AcceptTcpClientAsync đang chạy.
                listener.Stop();
                listener = null;
            }
        }

        private async Task HandleClientDataAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            // Sử dụng StringBuilder để đệm các ký tự Telnet nhận được
            StringBuilder receivedMessage = new StringBuilder();

            try
            {
                int bytesRead;
                // Đọc dữ liệu từ luồng
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    // Chuyển đổi bytes thành chuỗi (Telnet thường dùng ASCII)
                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Xử lý dữ liệu:
                    // Telnet gửi ký tự kết thúc dòng là CR (Carriage Return - \r) và LF (Line Feed - \n)

                    if (data.Contains("\n"))
                    {
                        // Nếu dữ liệu chứa ký tự xuống dòng, xử lý từng phần
                        string[] parts = data.Split('\n');

                        for (int i = 0; i < parts.Length; i++)
                        {
                            string part = parts[i].Replace("\r", ""); // Loại bỏ CR (\r)

                            if (i < parts.Length - 1)
                            {
                                // Nếu là một phần kết thúc bằng \n, nghĩa là đây là cuối câu
                                receivedMessage.Append(part);

                                // 4. Chương trình sẽ nhận và hiện lên form.
                                // In ra dòng hoàn chỉnh và reset buffer
                                AppendToLog($"[Telnet]: {receivedMessage.ToString()}");
                                receivedMessage.Clear();
                            }
                            else
                            {
                                // Đây là phần cuối cùng (có thể là một phần của dòng tiếp theo)
                                receivedMessage.Append(part);
                            }
                        }
                    }
                    else
                    {
                        // Nếu chưa có ký tự xuống dòng, tiếp tục đệm dữ liệu
                        receivedMessage.Append(data.Replace("\r", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý khi kết nối bị đóng hoặc gặp lỗi
                AppendToLog($"Kết nối bị ngắt hoặc gặp lỗi: {ex.Message}");
            }
            finally
            {
                // Đảm bảo đóng kết nối TCP client
                client.Close();
                // Nếu còn dữ liệu chưa in, in nốt trước khi đóng
                if (receivedMessage.Length > 0)
                {
                    AppendToLog($"[Telnet - Dang dở]: {receivedMessage.ToString()}");
                }
                AppendToLog("--- Kết nối Telnet đã đóng. ---");
            }
        }
        /// <summary>
        /// Phương thức an toàn để thêm text vào TextBox từ bất kỳ luồng nào.
        /// </summary>
        private void AppendToLog(string text)
        {
            // Kiểm tra xem có cần Invoke để chạy trên luồng UI không
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() => textBox1.AppendText(text + Environment.NewLine)));
            }
            else
            {
                textBox1.AppendText(text + Environment.NewLine);
            }
        }
    }
}