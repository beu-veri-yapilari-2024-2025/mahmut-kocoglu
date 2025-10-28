namespace WinFormsApp1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtOgrNo = new TextBox();
            txtDers = new TextBox();
            txtNot = new TextBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnListStudent = new Button();
            btnListCourse = new Button();
            lstOutput = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 68);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 0;
            label1.Text = "Öğrenci No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 105);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 1;
            label2.Text = "Ders Kodu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 142);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Harf Notu";
            // 
            // txtOgrNo
            // 
            txtOgrNo.Location = new Point(128, 65);
            txtOgrNo.Name = "txtOgrNo";
            txtOgrNo.Size = new Size(150, 31);
            txtOgrNo.TabIndex = 3;
            txtOgrNo.TextChanged += txtOgrNo_TextChanged;
            // 
            // txtDers
            // 
            txtDers.Location = new Point(128, 102);
            txtDers.Name = "txtDers";
            txtDers.Size = new Size(150, 31);
            txtDers.TabIndex = 4;
            txtDers.TextChanged += txtDers_TextChanged;
            // 
            // txtNot
            // 
            txtNot.Location = new Point(128, 139);
            txtNot.Name = "txtNot";
            txtNot.Size = new Size(150, 31);
            txtNot.TabIndex = 5;
            txtNot.TextChanged += txtNot_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(19, 176);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(141, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Ekle / Güncelle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(166, 176);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(112, 34);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Sil";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnListStudent
            // 
            btnListStudent.Location = new Point(19, 216);
            btnListStudent.Name = "btnListStudent";
            btnListStudent.Size = new Size(259, 34);
            btnListStudent.TabIndex = 8;
            btnListStudent.Text = "Öğrencinin Derslerini Listele";
            btnListStudent.UseVisualStyleBackColor = true;
            btnListStudent.Click += btnListStudent_Click;
            // 
            // btnListCourse
            // 
            btnListCourse.Location = new Point(19, 256);
            btnListCourse.Name = "btnListCourse";
            btnListCourse.Size = new Size(259, 34);
            btnListCourse.TabIndex = 9;
            btnListCourse.Text = "Dersin Öğrencilerini Listele";
            btnListCourse.UseVisualStyleBackColor = true;
            // 
            // lstOutput
            // 
            lstOutput.FormattingEnabled = true;
            lstOutput.ItemHeight = 25;
            lstOutput.Location = new Point(344, 65);
            lstOutput.Name = "lstOutput";
            lstOutput.Size = new Size(713, 304);
            lstOutput.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 484);
            Controls.Add(lstOutput);
            Controls.Add(btnListCourse);
            Controls.Add(btnListStudent);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(txtNot);
            Controls.Add(txtDers);
            Controls.Add(txtOgrNo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtOgrNo;
        private TextBox txtDers;
        private TextBox txtNot;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnListStudent;
        private Button btnListCourse;
        private ListBox lstOutput;
    }
}
