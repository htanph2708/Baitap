namespace lab03.Bai04
{
    partial class Chung
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
            Openserverbutton = new Button();
            Openquanlibutton = new Button();
            SuspendLayout();
            // 
            // Openserverbutton
            // 
            Openserverbutton.Font = new Font("Segoe UI", 11F);
            Openserverbutton.Location = new Point(85, 58);
            Openserverbutton.Name = "Openserverbutton";
            Openserverbutton.Size = new Size(237, 67);
            Openserverbutton.TabIndex = 0;
            Openserverbutton.Text = "Open server";
            Openserverbutton.UseVisualStyleBackColor = true;
            // 
            // Openquanlibutton
            // 
            Openquanlibutton.Font = new Font("Segoe UI", 11F);
            Openquanlibutton.Location = new Point(85, 178);
            Openquanlibutton.Name = "Openquanlibutton";
            Openquanlibutton.Size = new Size(237, 67);
            Openquanlibutton.TabIndex = 1;
            Openquanlibutton.Text = "Open quanli";
            Openquanlibutton.UseVisualStyleBackColor = true;
            // 
            // Chung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 274);
            Controls.Add(Openquanlibutton);
            Controls.Add(Openserverbutton);
            Name = "Chung";
            Text = "Chung";
            ResumeLayout(false);
        }

        #endregion

        private Button Openserverbutton;
        private Button Openquanlibutton;
    }
}