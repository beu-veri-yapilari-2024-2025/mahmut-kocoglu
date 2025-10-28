using System;

namespace HanoiKuleleri
{
    class Program
    {
        // Hanoi algoritması (özyinelemeli)
        static void Hanoi(int n, char kaynak, char hedef, char ara)
        {
            if (n == 1)
            {
                Console.WriteLine($"Disk 1: {kaynak} -> {hedef}");
                return;
            }

            // 1. Adım: n-1 diski kaynak çubuktan ara çubuğa taşı
            Hanoi(n - 1, kaynak, ara, hedef);

            // 2. Adım: En büyük diski (n. disk) doğrudan hedef çubuğa taşı
            Console.WriteLine($"Disk {n}: {kaynak} -> {hedef}");

            // 3. Adım: n-1 diski ara çubuktan hedef çubuğa taşı
            Hanoi(n - 1, ara, hedef, kaynak);
        }

        static void Main(string[] args)
        {
            Console.Write("Kaç disk olacağını giriniz: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Hanoi Kuleleri Çözümü ---");
            Hanoi(n, 'A', 'C', 'B');  // A: kaynak, C: hedef, B: ara çubuk

            int toplamAdim = (int)Math.Pow(2, n) - 1;
            Console.WriteLine($"\nToplam adım sayısı: {toplamAdim}");
        }
    }
}
