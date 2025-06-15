namespace ibu_hamilll.view
{
    partial class Ibu_Hamil_utama
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(114, 574);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(405, 53);
            comboBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(641, 629);
            button1.Name = "button1";
            button1.Size = new Size(182, 69);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += this.button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(551, 33);
            label1.Name = "label1";
            label1.Size = new Size(341, 74);
            label1.TabIndex = 7;
            label1.Text = "IBU HAMIL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(114, 203);
            label2.Name = "label2";
            label2.Size = new Size(123, 51);
            label2.TabIndex = 8;
            label2.Text = "Nama";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(114, 308);
            label3.Name = "label3";
            label3.Size = new Size(115, 51);
            label3.TabIndex = 9;
            label3.Text = "Umur";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(114, 413);
            label4.Name = "label4";
            label4.Size = new Size(289, 51);
            label4.TabIndex = 10;
            label4.Text = "Usia Kehamilan";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(114, 520);
            label5.Name = "label5";
            label5.Size = new Size(156, 51);
            label5.TabIndex = 11;
            label5.Text = "Keluhan";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Comic Sans MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(114, 257);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(405, 48);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Comic Sans MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(114, 362);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(405, 48);
            textBox2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Comic Sans MS", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(114, 467);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(405, 39);
            dateTimePicker1.TabIndex = 14;
            // 
            // Ibu_Hamil_utama
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1500, 878);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Name = "Ibu_Hamil_utama";
            Text = "Ibu_Hamil_utama";
            Load += Ibu_Hamil_utama_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
    }
}