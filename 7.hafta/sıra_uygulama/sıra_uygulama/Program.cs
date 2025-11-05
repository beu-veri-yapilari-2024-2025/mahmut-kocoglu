namespace sıra_uygulama
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var q1 = new MyQueue(1);
            var q2 = new MyQueue(2);
            var q3 = new MyQueue(3);

            var f1 = new Form1(q1, q2, q3);
            var f2 = new Form2(q1, q2, q3);

            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = new Point(100, 100);

            f1.Show(); // önce f1 göster, ölçüler alınsın

            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = new Point(f1.Right + 10, f1.Top);
            f2.Show();

            // Form1 kapanırsa program kapanır
            Application.Run(f1);

        }
    }
}