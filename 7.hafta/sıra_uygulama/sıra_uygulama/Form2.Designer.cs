namespace sıra_uygulama
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
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            listBox3 = new ListBox();
            siradakiMusteri = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(25, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(252, 229);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Location = new Point(281, 63);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(252, 229);
            listBox2.TabIndex = 1;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 25;
            listBox3.Location = new Point(539, 63);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(252, 229);
            listBox3.TabIndex = 2;
            // 
            // siradakiMusteri
            // 
            siradakiMusteri.BackColor = Color.LightGreen;
            siradakiMusteri.Location = new Point(66, 320);
            siradakiMusteri.Name = "siradakiMusteri";
            siradakiMusteri.Size = new Size(129, 100);
            siradakiMusteri.TabIndex = 3;
            siradakiMusteri.Text = "SIRADAKİNİ ÇAĞIR";
            siradakiMusteri.UseVisualStyleBackColor = false;
            siradakiMusteri.Click += siradakiMusteri_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(320, 351);
            label1.Name = "label1";
            label1.Size = new Size(349, 43);
            label1.TabIndex = 4;
            label1.Text = "      SIRADAKİ MÜŞTERİ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.LightGreen;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(564, 354);
            label2.Name = "label2";
            label2.Size = new Size(88, 38);
            label2.TabIndex = 5;
            label2.Text = "   ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(539, 10);
            label4.Name = "label4";
            label4.Size = new Size(252, 50);
            label4.TabIndex = 9;
            label4.Text = "Ticari İşlemler";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(281, 10);
            label3.Name = "label3";
            label3.Size = new Size(252, 50);
            label3.TabIndex = 8;
            label3.Text = "Müşteri Temsilcisi";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(25, 10);
            label5.Name = "label5";
            label5.Size = new Size(252, 50);
            label5.TabIndex = 7;
            label5.Text = "Gişe İşlemleri";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 469);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(siradakiMusteri);
            Controls.Add(listBox3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Name = "Form2";
            Text = "MusteriCagir";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private Button siradakiMusteri;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label5;
    }
}