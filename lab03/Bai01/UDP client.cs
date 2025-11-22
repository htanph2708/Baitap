using System;
using System.Net.Sockets; // Cần cho UdpClient
using System.Text;      // Cần cho Encoding.UTF8
using System.Windows.Forms; // Cần cho Form

// Đảm bảo namespace này khớp với file Designer.cs của bạn
namespace lab03.Bai01
{
    // Lớp này phải là 'partial' và kế thừa từ 'Form'
    public partial class UDP_Client : Form
    {
        public UDP_Client()
        {
            // Hàm này rất quan trọng, nó tải tất cả control từ file Designer.cs
            InitializeComponent();
        }

        // Đây là hàm xử lý sự kiện mà file Designer.cs đang tìm kiếm
        // Nó được liên kết với nút btnSend
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Sử dụng 'using' để đảm bảo UdpClient luôn được đóng
            // ngay cả khi có lỗi xảy ra
            using (UdpClient clientUdpClient = new UdpClient())
            {
                try
                {
                    // 1. Lấy dữ liệu từ các TextBox
                    string ip = txtRemoteIP.Text;
                    int port = int.Parse(txtRemotePort.Text);
                    string message = txtMessage.Text;

                    // 2. Kiểm tra tin nhắn rỗng
                    if (string.IsNullOrEmpty(message))
                    {
                        MessageBox.Show("Vui lòng nhập tin nhắn!");
                        return;
                    }

                    // 3. Chuyển chuỗi string (Tiếng Việt) thành mảng byte[]
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    // 4. Gửi dữ liệu đến IP và Port của Server
                    clientUdpClient.Send(data, data.Length, ip, port);

                    // 5. Xóa tin nhắn đã gửi
                    txtMessage.Text = "";
                }
                catch (FormatException)
                {
                    // Xử lý lỗi nếu người dùng nhập chữ vào ô Port
                    MessageBox.Show("Port không hợp lệ. Vui lòng nhập một số.");
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi chung khác (ví dụ: không tìm thấy server)
                    MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message);
                }
            }
        }
    }
}