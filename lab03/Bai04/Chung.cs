// File: Chung.cs

using System;
using System.Windows.Forms;

namespace lab03.Bai04
{
    public partial class Chung : Form
    {
        public Chung()
        {
            InitializeComponent();

            // Gán sự kiện cho các nút
            Openserverbutton.Click += Openserverbutton_Click;
            Openquanlibutton.Click += Openquanlibutton_Click;
        }

        private void Openserverbutton_Click(object sender, EventArgs e)
        {
            // Mở Form Server trong một luồng (thread) mới để không làm đóng Form Chung
            // và để Server có thể chạy song song.

            // Tạo một thể hiện mới của Form Server
            Server serverForm = new Server();

            // Hiển thị Form Server
            serverForm.Show();

            // Tùy chọn: Có thể muốn ẩn nút này sau khi Server đã mở
            // Openserverbutton.Enabled = false; 
        }

        private void Openquanlibutton_Click(object sender, EventArgs e)
        {
            // Mở Form Quanli (Client)

            // Tạo một thể hiện mới của Form Client
            // Bạn có thể mở nhiều Client để kiểm tra tính đồng bộ
            Quanli clientForm = new Quanli();
            clientForm.Text = "Quầy vé Client (Số " + (Application.OpenForms.Count - 1) + ")";

            // Hiển thị Form Client
            clientForm.Show();
        }

        // *Lưu ý quan trọng:*
        // Trong môi trường đa luồng (Multi-Client/Server), việc gọi Show() cho các Form
        // trong cùng một luồng (thread) chính có thể gây ra vấn đề UI blocking.
        // Tuy nhiên, đối với WinForms cơ bản, cách trên là đủ để khởi động các Form.
        // Nếu muốn mở Form Server và Client hoàn toàn độc lập, bạn cần sử dụng Thread hoặc Task.
    }
}