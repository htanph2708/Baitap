namespace lab03.Bai03
{
    partial class Bai3
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
            Openclientbutton = new Button();
            Openserverbutton = new Button();
            SuspendLayout();
            // 
            // Openclientbutton
            // 
            Openclientbutton.Location = new Point(34, 34);
            Openclientbutton.Name = "Openclientbutton";
            Openclientbutton.Size = new Size(277, 39);
            Openclientbutton.TabIndex = 0;
            Openclientbutton.Text = "Open TCP client";
            Openclientbutton.UseVisualStyleBackColor = true;
            // 
            // Openserverbutton
            // 
            Openserverbutton.Location = new Point(34, 99);
            Openserverbutton.Name = "Openserverbutton";
            Openserverbutton.Size = new Size(277, 39);
            Openserverbutton.TabIndex = 1;
            Openserverbutton.Text = "Open TCP sever";
            Openserverbutton.UseVisualStyleBackColor = true;
            // 
            // Bai3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 150);
            Controls.Add(Openserverbutton);
            Controls.Add(Openclientbutton);
            Name = "Bai3";
            Text = "Bai3";
            ResumeLayout(false);
        }

        #endregion

        private Button Openclientbutton;
        private Button Openserverbutton;
    }
}