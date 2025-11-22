namespace lab03.Bai03
{
    partial class client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            Connectbutton = new Button();
            Sendbutton = new Button();
            Disconnectbutton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 26);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(497, 214);
            textBox1.TabIndex = 0;
            // 
            // Connectbutton
            // 
            Connectbutton.Location = new Point(534, 47);
            Connectbutton.Name = "Connectbutton";
            Connectbutton.Size = new Size(94, 38);
            Connectbutton.TabIndex = 1;
            Connectbutton.Text = "Connect";
            Connectbutton.UseVisualStyleBackColor = true;
            // 
            // Sendbutton
            // 
            Sendbutton.Location = new Point(534, 110);
            Sendbutton.Name = "Sendbutton";
            Sendbutton.Size = new Size(94, 38);
            Sendbutton.TabIndex = 2;
            Sendbutton.Text = "Send";
            Sendbutton.UseVisualStyleBackColor = true;
            // 
            // Disconnectbutton
            // 
            Disconnectbutton.Location = new Point(534, 175);
            Disconnectbutton.Name = "Disconnectbutton";
            Disconnectbutton.Size = new Size(94, 38);
            Disconnectbutton.TabIndex = 3;
            Disconnectbutton.Text = "Disconnect";
            Disconnectbutton.UseVisualStyleBackColor = true;
            // 
            // client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 257);
            Controls.Add(Disconnectbutton);
            Controls.Add(Sendbutton);
            Controls.Add(Connectbutton);
            Controls.Add(textBox1);
            Name = "client";
            Text = "client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Connectbutton;
        private Button Sendbutton;
        private Button Disconnectbutton;
    }
}