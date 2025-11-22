using System;
using System.Windows.Forms;

namespace lab03.Bai03
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
            Openclientbutton.Click += Openclientbutton_Click;
            Openserverbutton.Click += Openserverbutton_Click;
        }

        private void Openserverbutton_Click(object sender, EventArgs e)
        {
            // Mở Form Server
            Server serverForm = new Server();
            serverForm.Show();
        }

        private void Openclientbutton_Click(object sender, EventArgs e)
        {
            // Mở Form Client
            client clientForm = new client();
            clientForm.Show();
        }
    }
}