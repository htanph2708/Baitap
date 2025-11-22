    namespace lab03.Bai05
    {
        partial class Menu
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
            pictureBoxMenu = new PictureBox();
            panel1 = new Panel();
            Phanloai = new Label();
            Gia = new Label();
            Tenmon = new Label();
            TentextBox = new TextBox();
            PhanloaitextBox = new TextBox();
            GiatextBox = new TextBox();
            textBox2 = new TextBox();
            Timkiemtextbox = new TextBox();
            dataGridView1 = new DataGridView();
            Themmon = new Button();
            Xoamonbutton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenu).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMenu
            // 
            pictureBoxMenu.Location = new Point(508, 74);
            pictureBoxMenu.Name = "pictureBoxMenu";
            pictureBoxMenu.Size = new Size(280, 178);
            pictureBoxMenu.TabIndex = 0;
            pictureBoxMenu.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(Phanloai);
            panel1.Controls.Add(Gia);
            panel1.Controls.Add(Tenmon);
            panel1.Controls.Add(TentextBox);
            panel1.Controls.Add(PhanloaitextBox);
            panel1.Controls.Add(GiatextBox);
            panel1.Controls.Add(textBox2);
            panel1.Location = new Point(508, 278);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 160);
            panel1.TabIndex = 1;
            // 
            // Phanloai
            // 
            Phanloai.AutoSize = true;
            Phanloai.Font = new Font("Segoe UI", 10F);
            Phanloai.Location = new Point(14, 124);
            Phanloai.Name = "Phanloai";
            Phanloai.Size = new Size(81, 23);
            Phanloai.TabIndex = 9;
            Phanloai.Text = "Phân loại";
            // 
            // Gia
            // 
            Gia.AutoSize = true;
            Gia.Font = new Font("Segoe UI", 10F);
            Gia.Location = new Point(35, 75);
            Gia.Name = "Gia";
            Gia.Size = new Size(35, 23);
            Gia.TabIndex = 8;
            Gia.Text = "Gia";
            // 
            // Tenmon
            // 
            Tenmon.AutoSize = true;
            Tenmon.Font = new Font("Segoe UI", 10F);
            Tenmon.Location = new Point(14, 27);
            Tenmon.Name = "Tenmon";
            Tenmon.Size = new Size(100, 23);
            Tenmon.TabIndex = 7;
            Tenmon.Text = "Tên món ăn";
            // 
            // TentextBox
            // 
            TentextBox.Location = new Point(120, 23);
            TentextBox.Name = "TentextBox";
            TentextBox.Size = new Size(125, 27);
            TentextBox.TabIndex = 6;
            // 
            // PhanloaitextBox
            // 
            PhanloaitextBox.Location = new Point(120, 120);
            PhanloaitextBox.Name = "PhanloaitextBox";
            PhanloaitextBox.Size = new Size(125, 27);
            PhanloaitextBox.TabIndex = 4;
            // 
            // GiatextBox
            // 
            GiatextBox.Location = new Point(120, 75);
            GiatextBox.Name = "GiatextBox";
            GiatextBox.Size = new Size(125, 27);
            GiatextBox.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(106, -33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // Timkiemtextbox
            // 
            Timkiemtextbox.Location = new Point(12, 26);
            Timkiemtextbox.Multiline = true;
            Timkiemtextbox.Name = "Timkiemtextbox";
            Timkiemtextbox.Size = new Size(125, 37);
            Timkiemtextbox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(450, 285);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Themmon
            // 
            Themmon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Themmon.Location = new Point(195, 26);
            Themmon.Name = "Themmon";
            Themmon.Size = new Size(110, 47);
            Themmon.TabIndex = 7;
            Themmon.Text = "Thêm món";
            Themmon.UseVisualStyleBackColor = true;
            Themmon.Click += Themmon_Click_1;
            // 
            // Xoamonbutton
            // 
            Xoamonbutton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Xoamonbutton.Location = new Point(350, 26);
            Xoamonbutton.Name = "Xoamonbutton";
            Xoamonbutton.Size = new Size(110, 47);
            Xoamonbutton.TabIndex = 8;
            Xoamonbutton.Text = "Xóa món ";
            Xoamonbutton.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Xoamonbutton);
            Controls.Add(Themmon);
            Controls.Add(dataGridView1);
            Controls.Add(Timkiemtextbox);
            Controls.Add(panel1);
            Controls.Add(pictureBoxMenu);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxMenu;
            private Panel panel1;
            private TextBox PhanloaitextBox;
            private TextBox GiatextBox;
            private TextBox textBox2;
            private TextBox Timkiemtextbox;
            private DataGridView dataGridView1;
            private Button Themmon;
            private Button Xoamonbutton;
            private Label Phanloai;
            private Label Gia;
            private Label Tenmon;
            private TextBox TentextBox;
        }
    }