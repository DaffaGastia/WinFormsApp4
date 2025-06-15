namespace ibu_hamilll.view
{
    partial class Keluhan
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
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Comic Sans MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(899, 692);
            button1.Name = "button1";
            button1.Size = new Size(160, 67);
            button1.TabIndex = 9;
            button1.Text = "CEK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Comic Sans MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1279, 692);
            button2.Name = "button2";
            button2.Size = new Size(165, 67);
            button2.TabIndex = 10;
            button2.Text = "KELUAR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1127, 174);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 250);
            panel1.Name = "panel1";
            panel1.Size = new Size(441, 163);
            panel1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 52);
            label1.Name = "label1";
            label1.Size = new Size(127, 51);
            label1.TabIndex = 14;
            label1.Text = "Saran";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 465);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 171);
            panel2.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 59);
            label2.Name = "label2";
            label2.Size = new Size(178, 51);
            label2.TabIndex = 14;
            label2.Text = "Lifestyle";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Perut Keram", "Muntah", "Kaki Bengkak" });
            comboBox1.Location = new Point(1000, 583);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(341, 53);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(868, 294);
            label3.Name = "label3";
            label3.Size = new Size(622, 60);
            label3.TabIndex = 15;
            label3.Text = "Masukan Kembali Keluhannya";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(1000, 404);
            label4.Name = "label4";
            label4.Size = new Size(336, 45);
            label4.TabIndex = 16;
            label4.Text = "Masukan No Antrian";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(1106, 524);
            label5.Name = "label5";
            label5.Size = new Size(156, 51);
            label5.TabIndex = 17;
            label5.Text = "Keluhan";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1000, 465);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(341, 52);
            textBox1.TabIndex = 18;
            // 
            // Keluhan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1677, 979);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Keluhan";
            Text = "Keluhan";
            Load += Keluhan_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
    }
}