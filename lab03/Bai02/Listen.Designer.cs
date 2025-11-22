namespace lab03.Bai02
{
    partial class Listen
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
            buttonListen = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(31, 67);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(382, 349);
            textBox1.TabIndex = 0;
            // 
            // buttonListen
            // 
            buttonListen.Location = new Point(148, 12);
            buttonListen.Name = "buttonListen";
            buttonListen.Size = new Size(124, 38);
            buttonListen.TabIndex = 1;
            buttonListen.Text = "Listen";
            buttonListen.UseVisualStyleBackColor = true;
            // 
            // Listen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 435);
            Controls.Add(buttonListen);
            Controls.Add(textBox1);
            Name = "Listen";
            Text = "Listen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonListen;
    }
}