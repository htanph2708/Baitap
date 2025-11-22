namespace lab03
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Bai1button = new Button();
            Bai2button = new Button();
            Bai3button = new Button();
            Bai4button = new Button();
            Bai5button = new Button();
            SuspendLayout();
            // 
            // Bai1button
            // 
            Bai1button.Location = new Point(42, 51);
            Bai1button.Name = "Bai1button";
            Bai1button.Size = new Size(117, 47);
            Bai1button.TabIndex = 0;
            Bai1button.Text = "Bai1";
            Bai1button.UseVisualStyleBackColor = true;
            // 
            // Bai2button
            // 
            Bai2button.Location = new Point(263, 51);
            Bai2button.Name = "Bai2button";
            Bai2button.Size = new Size(117, 47);
            Bai2button.TabIndex = 1;
            Bai2button.Text = "Bai2";
            Bai2button.UseVisualStyleBackColor = true;
            // 
            // Bai3button
            // 
            Bai3button.Location = new Point(471, 51);
            Bai3button.Name = "Bai3button";
            Bai3button.Size = new Size(117, 47);
            Bai3button.TabIndex = 2;
            Bai3button.Text = "Bai3";
            Bai3button.UseVisualStyleBackColor = true;
            // 
            // Bai4button
            // 
            Bai4button.Location = new Point(371, 160);
            Bai4button.Name = "Bai4button";
            Bai4button.Size = new Size(117, 47);
            Bai4button.TabIndex = 3;
            Bai4button.Text = "Bai4";
            Bai4button.UseVisualStyleBackColor = true;
            Bai4button.Click += Bai4button_Click;
            // 
            // Bai5button
            // 
            Bai5button.Location = new Point(147, 160);
            Bai5button.Name = "Bai5button";
            Bai5button.Size = new Size(117, 47);
            Bai5button.TabIndex = 4;
            Bai5button.Text = "Bai5";
            Bai5button.UseVisualStyleBackColor = true;
            Bai5button.Click += Bai5button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 261);
            Controls.Add(Bai5button);
            Controls.Add(Bai4button);
            Controls.Add(Bai3button);
            Controls.Add(Bai2button);
            Controls.Add(Bai1button);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button Bai1button;
        private Button Bai2button;
        private Button Bai3button;
        private Button Bai4button;
        private Button Bai5button;
    }
}
