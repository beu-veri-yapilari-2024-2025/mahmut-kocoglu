using System.Windows.Forms;

namespace sıra_uygulama
{
    public partial class Form1 : Form
    {
        private MyQueue q1;
        private MyQueue q2;
        private MyQueue q3;
        public Form1(MyQueue queue1, MyQueue queue2, MyQueue queue3)
        {
            InitializeComponent();
            siraNo.Text = "  ";
            q1 = queue1;
            q2 = queue2;
            q3 = queue3;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void giseSiraAl_Click(object sender, EventArgs e)
        {
            q1.Enqueue();
            siraNo.Text = q1.tail.ToString();
        }
        private void temsilciSiraAl_Click(object sender, EventArgs e)
        {
            q2.Enqueue();
            siraNo.Text = q2.tail.ToString();
        }

        private void ticariSiraAl_Click(object sender, EventArgs e)
        {
            q3.Enqueue();
            siraNo.Text = q3.tail.ToString();
        }
    }
}
