namespace WinFormsApp4
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            button4 = new Button();
            button5 = new Button();
            panel3 = new Panel();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(273, 144);
            label1.Name = "label1";
            label1.Size = new Size(128, 43);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(63, 411);
            label2.Name = "label2";
            label2.Size = new Size(62, 21);
            label2.TabIndex = 1;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(730, 411);
            label4.Name = "label4";
            label4.Size = new Size(62, 21);
            label4.TabIndex = 3;
            label4.Text = "label4";
            label4.Click += label4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(730, 374);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 6;
            button2.Text = "CLICK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(63, 374);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 7;
            button3.Text = "CLICK";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(10, 18, 80);
            panel1.Controls.Add(button4);
            panel1.Location = new Point(1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 42);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(231, 64, 50);
            button4.BackgroundImage = Properties.Resources.Close;
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(890, 0);
            button4.Name = "button4";
            button4.Size = new Size(57, 41);
            button4.TabIndex = 0;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(10, 18, 80);
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Zoom;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(0, 3);
            button5.Name = "button5";
            button5.Size = new Size(56, 48);
            button5.TabIndex = 1;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(10, 18, 80);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(button5);
            panel3.Location = new Point(1, 42);
            panel3.Name = "panel3";
            panel3.Size = new Size(947, 54);
            panel3.TabIndex = 9;
            panel3.Paint += panel3_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(62, 16);
            label6.Name = "label6";
            label6.Size = new Size(120, 23);
            label6.TabIndex = 2;
            label6.Text = "Dashboard";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(706, 218);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(51, 218);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 130);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 18, 80);
            ClientSize = new Size(947, 661);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            Text = "a";
            Load += Form2_Load_1;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Button button4;
        private Button button5;
        private Panel panel3;
        private Label label6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}