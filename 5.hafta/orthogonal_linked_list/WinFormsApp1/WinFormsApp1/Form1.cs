using NotMatrisi;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private GradeMatrix matrix = new GradeMatrix();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = int.Parse(txtOgrNo.Text);
                string ders = txtDers.Text;
                string notu = txtNot.Text;

                matrix.AddOrUpdate(ogrNo, ders, notu);

                MessageBox.Show("Eklendi / Güncellendi 👍");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnListStudent_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();

            int ogrNo = int.Parse(txtOgrNo.Text);
            foreach (var item in matrix.ListCoursesOfStudent(ogrNo))
            {
                // item.Item1 = ders kodu, item.Item2 = harf notu
                lstOutput.Items.Add("Ders: " + item.Item1 + "  Not: " + item.Item2);
            }

            if (lstOutput.Items.Count == 0)
                lstOutput.Items.Add("Bu öğrencinin kaydı yok.");
        }

        private void txtOgrNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDers_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNot_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int ogrNo = int.Parse(txtOgrNo.Text);
            string ders = txtDers.Text;

            bool ok = matrix.Remove(ogrNo, ders);
            MessageBox.Show(ok ? "Silindi ❌" : "Bulunamadı");
        }

        private void btnListCourse_Click(object sender, EventArgs e)
        {
            lstOutput.Items.Clear();

            string ders = txtDers.Text;
            foreach (var item in matrix.ListStudentsOfCourse(ders))
            {
                // item.Item1 = öğrenci no, item.Item2 = harf notu
                lstOutput.Items.Add("Öğrenci: " + item.Item1 + "  Not: " + item.Item2);
            }

            if (lstOutput.Items.Count == 0)
                lstOutput.Items.Add("Bu ders için kayıt yok.");
        }

        private void lstOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
