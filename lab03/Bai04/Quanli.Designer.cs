// File: Quanli.Designer.cs

using System.Drawing;

namespace lab03.Bai04
{
    partial class Quanli
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Controls
        private System.Windows.Forms.Button Ghe1button;
        private System.Windows.Forms.Button Ghe2button;
        private System.Windows.Forms.Button Ghe3button;
        private System.Windows.Forms.Button Ghe4button;
        private System.Windows.Forms.Button Ghe5button;
        private System.Windows.Forms.Button Ghe6button;
        private System.Windows.Forms.Button Ghe7button;
        private System.Windows.Forms.Button Ghe8button;
        private System.Windows.Forms.Button Ghe9button;

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtClientLog;
        private System.Windows.Forms.Label lblStatus;

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
            Ghe1button = new Button();
            Ghe2button = new Button();
            Ghe3button = new Button();
            Ghe4button = new Button();
            Ghe5button = new Button();
            Ghe6button = new Button();
            Ghe7button = new Button();
            Ghe8button = new Button();
            Ghe9button = new Button();
            txtServerIP = new TextBox();
            txtServerPort = new TextBox();
            btnConnect = new Button();
            lblStatus = new Label();
            btnXacNhan = new Button();
           
            SuspendLayout();
            // 
            // Ghe1button
            // 
            Ghe1button.Font = new Font("Segoe UI", 11F);
            Ghe1button.Location = new Point(157, 101);
            Ghe1button.Name = "Ghe1button";
            Ghe1button.Size = new Size(94, 38);
            Ghe1button.TabIndex = 8;
            Ghe1button.Text = "1";
            Ghe1button.UseVisualStyleBackColor = true;
            // 
            // Ghe2button
            // 
            Ghe2button.Font = new Font("Segoe UI", 11F);
            Ghe2button.Location = new Point(301, 101);
            Ghe2button.Name = "Ghe2button";
            Ghe2button.Size = new Size(94, 38);
            Ghe2button.TabIndex = 7;
            Ghe2button.Text = "2";
            Ghe2button.UseVisualStyleBackColor = true;
            // 
            // Ghe3button
            // 
            Ghe3button.Font = new Font("Segoe UI", 11F);
            Ghe3button.Location = new Point(464, 101);
            Ghe3button.Name = "Ghe3button";
            Ghe3button.Size = new Size(94, 38);
            Ghe3button.TabIndex = 6;
            Ghe3button.Text = "3";
            Ghe3button.UseVisualStyleBackColor = true;
            // 
            // Ghe4button
            // 
            Ghe4button.Font = new Font("Segoe UI", 11F);
            Ghe4button.Location = new Point(157, 183);
            Ghe4button.Name = "Ghe4button";
            Ghe4button.Size = new Size(94, 38);
            Ghe4button.TabIndex = 5;
            Ghe4button.Text = "4";
            Ghe4button.UseVisualStyleBackColor = true;
            // 
            // Ghe5button
            // 
            Ghe5button.Font = new Font("Segoe UI", 11F);
            Ghe5button.Location = new Point(301, 183);
            Ghe5button.Name = "Ghe5button";
            Ghe5button.Size = new Size(94, 38);
            Ghe5button.TabIndex = 4;
            Ghe5button.Text = "5";
            Ghe5button.UseVisualStyleBackColor = true;
            // 
            // Ghe6button
            // 
            Ghe6button.Font = new Font("Segoe UI", 11F);
            Ghe6button.Location = new Point(464, 183);
            Ghe6button.Name = "Ghe6button";
            Ghe6button.Size = new Size(94, 38);
            Ghe6button.TabIndex = 3;
            Ghe6button.Text = "6";
            Ghe6button.UseVisualStyleBackColor = true;
            // 
            // Ghe7button
            // 
            Ghe7button.Font = new Font("Segoe UI", 11F);
            Ghe7button.Location = new Point(157, 268);
            Ghe7button.Name = "Ghe7button";
            Ghe7button.Size = new Size(94, 38);
            Ghe7button.TabIndex = 2;
            Ghe7button.Text = "7";
            Ghe7button.UseVisualStyleBackColor = true;
            // 
            // Ghe8button
            // 
            Ghe8button.Font = new Font("Segoe UI", 11F);
            Ghe8button.Location = new Point(301, 268);
            Ghe8button.Name = "Ghe8button";
            Ghe8button.Size = new Size(94, 38);
            Ghe8button.TabIndex = 1;
            Ghe8button.Text = "8";
            Ghe8button.UseVisualStyleBackColor = true;
            // 
            // Ghe9button
            // 
            Ghe9button.Font = new Font("Segoe UI", 11F);
            Ghe9button.Location = new Point(464, 268);
            Ghe9button.Name = "Ghe9button";
            Ghe9button.Size = new Size(94, 38);
            Ghe9button.TabIndex = 0;
            Ghe9button.Text = "9";
            Ghe9button.UseVisualStyleBackColor = true;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(10, 10);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(120, 27);
            txtServerIP.TabIndex = 9;
            txtServerIP.Text = "127.0.0.1";
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(140, 10);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(60, 27);
            txtServerPort.TabIndex = 10;
            txtServerPort.Text = "8888";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(210, 8);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(80, 25);
            btnConnect.TabIndex = 11;
            btnConnect.Text = "Kết nối";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(300, 12);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(92, 20);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Chưa kết nối";
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(590, 180);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(120, 50);
            btnXacNhan.TabIndex = 13;
            btnXacNhan.Text = "Xác nhận Đặt vé";
            // 
            // txtClientLog
            // 
            
            // 
            // Quanli
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 450);
            Controls.Add(Ghe9button);
            Controls.Add(Ghe8button);
            Controls.Add(Ghe7button);
            Controls.Add(Ghe6button);
            Controls.Add(Ghe5button);
            Controls.Add(Ghe4button);
            Controls.Add(Ghe3button);
            Controls.Add(Ghe2button);
            Controls.Add(Ghe1button);
            Controls.Add(txtServerIP);
            Controls.Add(txtServerPort);
            Controls.Add(btnConnect);
            Controls.Add(lblStatus);
            Controls.Add(btnXacNhan);
            Controls.Add(txtClientLog);
            Name = "Quanli";
            Text = "Quản Lý Phòng Vé (Client)";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}