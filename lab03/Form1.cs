using System;
using System.Windows.Forms;

// ??m b?o b?n có th? truy c?p các l?p Form c?a t?ng bài
// Gi? ??nh: Bai3 n?m trong namespace lab03.Bai03
// (B?n c?n thay ??i các dòng 'using' này d?a trên c?u trúc project th?c t? c?a b?n)
// using lab03.Bai01; 
// using lab03.Bai02;
using lab03.Bai03; // S? d?ng l?i Bai3 ?ã tri?n khai tr??c ?ó
// using lab03.Bai04;
// using lab03.Bai05;

namespace lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Gán s? ki?n Click cho t?t c? các nút
            Bai1button.Click += BaiButton_Click;
            Bai2button.Click += BaiButton_Click;
            Bai3button.Click += BaiButton_Click;
            Bai4button.Click += BaiButton_Click;
            Bai5button.Click += BaiButton_Click;

            this.Text = "M?c l?c - Lab03";
        }

        private void BaiButton_Click(object sender, EventArgs e)
        {
            // Xác ??nh nút nào ???c nh?n
            Button btn = sender as Button;
            if (btn == null) return;

            // L?y tên bài t?p t? Text c?a nút (ví d?: "Bai1", "Bai2", "Bai3")
            string baiName = btn.Text;

            try
            {
                Form nextForm = null;

                switch (baiName)
                {
                    case "Bai1":

                        break;
                    case "Bai2":
                        nextForm = new lab03.Bai02.Listen();
                        break;
                    case "Bai3":
                        nextForm = new lab03.Bai03.Bai3();
                        break;
                    case "Bai4":
                        nextForm = new lab03.Bai04.Chung();
                        break;
                    case "Bai5":
                        nextForm = new lab03.Bai05.Menu();
                        break;
                    default:

                        break;
                }

                // N?u Form ???c kh?i t?o thành công, hi?n th? nó
                if (nextForm != null)
                {
                    nextForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i khi m? bài t?p {baiName}: {ex.Message}", "L?i");
            }
        }

        private void Bai4button_Click(object sender, EventArgs e)
        {

        }

        private void Bai5button_Click(object sender, EventArgs e)
        {

        }
    }
}