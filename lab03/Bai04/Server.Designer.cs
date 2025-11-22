// File: Server.Designer.cs (Dựa trên Namespace của bạn)

namespace lab03.Bai04
{
    partial class Server
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.TextBox txtPort;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // 1. TextBox Port
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPort.Location = new System.Drawing.Point(10, 10);
            this.txtPort.Size = new System.Drawing.Size(80, 20);
            this.txtPort.Text = "8888";
            this.txtPort.Name = "txtPort";

            // 2. Nút Start Server
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.Location = new System.Drawing.Point(100, 10);
            this.btnStartServer.Size = new System.Drawing.Size(120, 30);
            this.btnStartServer.Name = "btnStartServer";

            // 3. Status Label
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblServerStatus.Text = "Trạng thái: Đã dừng";
            this.lblServerStatus.Location = new System.Drawing.Point(230, 15);
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Name = "lblServerStatus";

            // 4. TextBox Log
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtLog.Multiline = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Location = new System.Drawing.Point(10, 50);
            this.txtLog.Size = new System.Drawing.Size(780, 380);
            this.txtLog.ReadOnly = true;
            this.txtLog.Name = "txtLog";

            // Cấu hình Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Server - Quản lý Phòng Vé";

            // Thêm Controls vào Form
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.txtLog);
        }
    }
}