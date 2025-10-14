using System;

namespace binary_search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dizi = BinarySearch.DiziAl();
            Array.Sort(dizi);
            Console.WriteLine("\nSıralı dizi:");
            Console.WriteLine(string.Join(" ", dizi));

            while (true)
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine("1) Bu dizide arama yap");
                Console.WriteLine("2) Bu dizideki elemanları topla");
                Console.WriteLine("3) Yeni bir dizi oluştur");
                Console.WriteLine("3) Çıkış");
                Console.WriteLine("------------------------");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    int hedef = ReadInt("\nAranacak eleman: ");

                    var (minIndis, maxIndis) = BinarySearch.GetMinMax(dizi, hedef);

                    if (minIndis == -1)
                    {
                        Console.WriteLine($"{hedef} dizide bulunamadı.");
                    }

                    else if (minIndis == maxIndis)
                    {
                        Console.WriteLine($"{hedef} sayısı {minIndis}. indiste bulunmaktadır.");
                    }

                    else
                    {
                        int adet = maxIndis - minIndis + 1;
                        Console.WriteLine($"{hedef} sayısının bulunduğu en küçük indis {minIndis}, en büyük indis {maxIndis}. Dizinizde {adet} adet bulunmaktadır.");
                    }
                }
                else if (secim == "2")
                {
                    int toplam = BinarySearch.DiziToplami(dizi);
                    Console.WriteLine($"\nDizi elemanlarının toplamı: {toplam}");
                }
                else if (secim == "3")
                {
                    Console.Clear();
                    dizi = BinarySearch.DiziAl();
                    Array.Sort(dizi);
                    Console.WriteLine("\nSıralı dizi:");
                    Console.WriteLine(string.Join(" ", dizi));
                }
                else if (secim == "4")
                {
                    Console.WriteLine("Güle güle...");
                    break;
                }

                else
                {
                    Console.WriteLine("Geçersiz seçim. 1, 2 veya 3 giriniz.");
                }
            }
        }

        // Güvenli tamsayı okuma
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val))
                    return val;
                Console.WriteLine("Geçerli bir tamsayı giriniz.");
            }
        }
    }

    class BinarySearch
    {
        public static int[] DiziAl()
        {
            int n = ReadPositiveInt("Kaç elemanlı bir dizi istiyorsunuz: ");
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
                d[i] = ReadInt($"{i + 1}. elemanı girin: ");
            return d;
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val))
                    return val;
                Console.WriteLine("Geçerli bir tamsayı giriniz.");
            }
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                int v = ReadInt(prompt);
                if (v >= 0) return v;
                Console.WriteLine("Negatif olamaz.");
            }
        }

        public static int DiziToplami(int[] a)
        {
            int toplam = 0;
            for (int i = 0; i < a.Length; i++)
                toplam += a[i];
            return toplam;
        }

        // Özyinelemeli ikili arama - min ve max indis için bir sonraki fonksiyonda kullanılacak
        private static int BinarySearchRecursive(int[] a, int sol, int sag, int hedef)
        {
            if (sol > sag) return -1;
            int orta = sol + (sag - sol) / 2;
            if (a[orta] == hedef) return orta;
            if (hedef < a[orta]) return BinarySearchRecursive(a, sol, orta - 1, hedef);
            return BinarySearchRecursive(a, orta + 1, sag, hedef);
        }

        // Tek recursive çağrı ve komşulara yürüyerek min & max
        public static (int minIndis, int maxIndis) GetMinMax(int[] a, int hedef)
        {
            if (a == null || a.Length == 0) return (-1, -1);

            int bulunan = BinarySearchRecursive(a, 0, a.Length - 1, hedef);
            if (bulunan == -1) return (-1, -1);

            int min = bulunan, max = bulunan;

            // sola doğru
            for (int i = bulunan - 1; i >= 0 && a[i] == hedef; i--) min = i;
            // sağa doğru
            for (int j = bulunan + 1; j < a.Length && a[j] == hedef; j++) max = j;

            return (min, max);
        }
    }
}
