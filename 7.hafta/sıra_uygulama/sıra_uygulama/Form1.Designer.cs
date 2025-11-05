namespace sıra_uygulama
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
            giseSiraAl = new Button();
            temsilciSiraAl = new Button();
            ticariSiraAl = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            siraNo = new Label();
            SuspendLayout();
            // 
            // giseSiraAl
            // 
            giseSiraAl.BackColor = Color.IndianRed;
            giseSiraAl.Location = new Point(305, 122);
            giseSiraAl.Name = "giseSiraAl";
            giseSiraAl.Size = new Size(50, 50);
            giseSiraAl.TabIndex = 0;
            giseSiraAl.UseVisualStyleBackColor = false;
            giseSiraAl.Click += giseSiraAl_Click;
            // 
            // temsilciSiraAl
            // 
            temsilciSiraAl.BackColor = Color.IndianRed;
            temsilciSiraAl.Location = new Point(305, 195);
            temsilciSiraAl.Name = "temsilciSiraAl";
            temsilciSiraAl.Size = new Size(50, 50);
            temsilciSiraAl.TabIndex = 1;
            temsilciSiraAl.UseVisualStyleBackColor = false;
            temsilciSiraAl.Click += temsilciSiraAl_Click;
            // 
            // ticariSiraAl
            // 
            ticariSiraAl.BackColor = Color.IndianRed;
            ticariSiraAl.Location = new Point(305, 264);
            ticariSiraAl.Name = "ticariSiraAl";
            ticariSiraAl.Size = new Size(50, 50);
            ticariSiraAl.TabIndex = 2;
            ticariSiraAl.UseVisualStyleBackColor = false;
            ticariSiraAl.Click += ticariSiraAl_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 34F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(373, 93);
            label1.TabIndex = 3;
            label1.Text = "SIRAMATİK";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(47, 122);
            label2.Name = "label2";
            label2.Size = new Size(252, 50);
            label2.TabIndex = 4;
            label2.Text = "Gişe İşlemleri";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(47, 195);
            label3.Name = "label3";
            label3.Size = new Size(252, 50);
            label3.TabIndex = 5;
            label3.Text = "Müşteri Temsilcisi";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(47, 264);
            label4.Name = "label4";
            label4.Size = new Size(252, 50);
            label4.TabIndex = 6;
            label4.Text = "Ticari İşlemler";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(75, 354);
            label5.Name = "label5";
            label5.Size = new Size(150, 50);
            label5.TabIndex = 7;
            label5.Text = "SIRANIZ:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // siraNo
            // 
            siraNo.BorderStyle = BorderStyle.Fixed3D;
            siraNo.Font = new Font("Segoe UI", 18F);
            siraNo.Location = new Point(231, 354);
            siraNo.Name = "siraNo";
            siraNo.Size = new Size(90, 50);
            siraNo.TabIndex = 8;
            siraNo.Text = "999";
            siraNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 449);
            Controls.Add(siraNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ticariSiraAl);
            Controls.Add(temsilciSiraAl);
            Controls.Add(giseSiraAl);
            Name = "Form1";
            Text = "SiraAl";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button giseSiraAl;
        private Button temsilciSiraAl;
        private Button ticariSiraAl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label siraNo;
    }
}
