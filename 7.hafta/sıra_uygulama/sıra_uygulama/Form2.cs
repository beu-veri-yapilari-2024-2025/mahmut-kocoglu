using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sıra_uygulama
{
    public partial class Form2 : Form
    {
        private MyQueue q1;
        private MyQueue q2;
        private MyQueue q3;


        private MyQueue SecilecekKuyruk()
        {
            const int TOL = 1;

            // 1) Sadece dolu kuyruklar
            var adaylar = new[] { q1, q2, q3 }
                .Where(q => q.Count > 0)
                .ToList();

            if (adaylar.Count == 0) return null;

            // 2) En büyük sayıyı bul
            int max = adaylar.Max(q => q.Count);

            // 3) Tolerans içinde kalanları al
            adaylar = adaylar.Where(q => (max - q.Count) <= TOL).ToList();

            // 4) Önce daha kalabalık, eşitse ID 3→2→1
            return adaylar
                .OrderByDescending(q => q.Count)
                .ThenByDescending(q => q.queueID)
                .First();
        }

        private void siradakiMusteri_Click(object sender, EventArgs e)
        {
            var kuyruk = SecilecekKuyruk();
            if (kuyruk == null)
            {
                MessageBox.Show("Bekleyen müşteri bulunmuyor...");
                return;
            }

            var cikan = kuyruk.Dequeue();             
            label2.Text = cikan.ToString();                


        }
        public Form2(MyQueue queue1, MyQueue queue2, MyQueue queue3)
        {
            InitializeComponent();
            q1 = queue1;
            q2 = queue2;
            q3 = queue3;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = q1.Items;
            listBox2.DataSource = q2.Items;
            listBox3.DataSource = q3.Items;
        }
    }
}
