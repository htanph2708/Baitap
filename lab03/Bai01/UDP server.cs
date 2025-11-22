using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// 1. Đảm bảo namespace là 'lab03.Bai01' (giống file Client)
namespace lab03.Bai01
{
    // 2. Đảm bảo có kế thừa ': Form'
    public partial class UDP_server : Form
    {
        private UdpClient serverUdpClient;
        private Thread serverThread;

        public UDP_server()
        {
            InitializeComponent(); // Hàm này gọi file Designer
            SetupListView();
        }

        // Cài đặt các cột cho ListView
        private void SetupListView()
        {
            lvMessages.Columns.Add("Thời gian", 150);
            lvMessages.Columns.Add("Từ (IP:Port)", 150);
            lvMessages.Columns.Add("Nội dung tin nhắn", 300);
        }

        // Sự kiện click nút Start
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(txtServerPort.Text);

                serverThread = new Thread(() => ListenThread(port));
                serverThread.IsBackground = true;
                serverThread.Start();

                btnStartServer.Enabled = false;
                btnStartServer.Text = "Server Running...";
                txtServerPort.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        // Luồng lắng nghe
        private void ListenThread(int port)
        {
            try
            {
                serverUdpClient = new UdpClient(port);
                while (true)
                {
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = serverUdpClient.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);
                    string source = remoteEP.ToString();
                    string time = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

                    UpdateListView(time, source, message);
                }
            }
            catch (SocketException)
            {
                // Xảy ra khi UdpClient bị Close() (bình thường)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi luồng server: " + ex.Message);
            }
        }

        // Hàm cập nhật ListView (Thread-Safe)
        private void UpdateListView(string time, string source, string message)
        {
            if (lvMessages.InvokeRequired)
            {
                lvMessages.Invoke(new MethodInvoker(() => UpdateListView(time, source, message)));
            }
            else
            {
                ListViewItem item = new ListViewItem(time);
                item.SubItems.Add(source);
                item.SubItems.Add(message);
                lvMessages.Items.Add(item);
                lvMessages.Items[lvMessages.Items.Count - 1].EnsureVisible();
            }
        }

        // Sự kiện khi đóng Form
        private void UDP_server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverUdpClient != null)
            {
                serverUdpClient.Close();
            }
        }
    }
}