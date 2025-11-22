using System;
using System.Windows.Forms;

// Đảm bảo namespace khớp với các form còn lại
namespace lab03.Bai01
{
    // Lớp này phải kế thừa từ Form
    public partial class multi : Form
    {
        public multi()
        {
            InitializeComponent();
        }

        // Sự kiện click nút "Start Server"
        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng của form UDP_server
            UDP_server serverForm = new UDP_server();

            // Hiển thị form server
            // Dùng .Show() để có thể mở nhiều cửa sổ
            serverForm.Show();
        }

        // Sự kiện click nút "Start Client"
        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng của form UDP_Client
            UDP_Client clientForm = new UDP_Client();

            // Hiển thị form client
            clientForm.Show();
        }
    }
}