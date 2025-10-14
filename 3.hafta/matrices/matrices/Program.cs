using System;

namespace MatrisCarpimi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== MATRİS ÇARPIMI İÇİN MATRİS GİRİŞİ ===\n");

            // --- 1. matris ---
            Console.WriteLine("1. Matris boyutlarını girin:");
            int m1 = ReadInt("Satır sayısı (m1): ", min: 1);
            int n1 = ReadInt("Sütun sayısı (n1): ", min: 1);
            var A = InputMatrixInteractive("1. Matris", m1, n1);

            // --- 2. matris ---
            Console.WriteLine("\n2. Matris boyutlarını girin:");
            int m2 = n1;
            Console.WriteLine("Satır sayısı (m2) A matrisinin sütun sayısıyla aynı olmak zorundadır");
            int n2 = ReadInt("Sütun sayısı (n2): ", min: 1);
            var B = InputMatrixInteractive("2. Matris", m2, n2);

            // --- sonuç ---
            Console.Clear();
            Console.WriteLine("\n=== A VE B MATRİSLERİ VE ÇARPIMI ===");
            Console.WriteLine("\n1. Matris (A):");
            PrintMatrix(A);

            Console.WriteLine("\n2. Matris (B):");
            PrintMatrix(B);

            // --- ÇARPIM ---
            Console.WriteLine("\nA × B =");
            int[,] C = MultiplyMatrices(A, B);
            PrintMatrix(C);

            Console.WriteLine("\nEnter'a basarak çıkın...");
            Console.ReadLine();
        }

        // ---- MATRİS ÇARPIM FONKSİYONU ----
        static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            int m1 = A.GetLength(0);
            int n1 = A.GetLength(1);
            int m2 = B.GetLength(0);
            int n2 = B.GetLength(1);

            if (n1 != m2)
                throw new Exception("Matrisler çarpılamaz! A'nın sütun sayısı B'nin satır sayısına eşit olmalı.");

            int[,] C = new int[m1, n2];

            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    int toplam = 0;
                    for (int k = 0; k < n1; k++)
                        toplam += A[i, k] * B[k, j];
                    C[i, j] = toplam;
                }
            }

            return C;
        }

        // ---- MATRİS GİRİŞİ ----
        static int[,] InputMatrixInteractive(string title, int m, int n)
        {
            int[,] M = new int[m, n];

            Console.Clear();
            Console.WriteLine($"=== {title} ===");
            PrintMatrix(M);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int val = ReadInt($"\n[{i + 1},{j + 1}] elemanını girin: ");
                    M[i, j] = val;

                    Console.Clear();
                    Console.WriteLine($"=== {title} ===");
                    PrintMatrix(M);
                }
            }

            return M;
        }

        // ---- MATRİS YAZDIRMA ----
        static void PrintMatrix(int[,] M)
        {
            int m = M.GetLength(0);
            int n = M.GetLength(1);
            int width = 1;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    width = Math.Max(width, M[i, j].ToString().Length);

            for (int i = 0; i < m; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(M[i, j].ToString().PadLeft(width));
                    if (j < n - 1) Console.Write("  ");
                }
                Console.WriteLine(" |");
            }
        }

        // ---- TAM SAYI OKUMA ----
        static int ReadInt(string prompt, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();

                if (int.TryParse(s, out int v))
                {
                    if (min.HasValue && v < min.Value)
                    {
                        Console.WriteLine($"Değer en az {min.Value} olmalı.");
                        continue;
                    }
                    if (max.HasValue && v > max.Value)
                    {
                        Console.WriteLine($"Değer en fazla {max.Value} olmalı.");
                        continue;
                    }
                    return v;
                }
                Console.WriteLine("Geçersiz giriş. Lütfen tam sayı girin.");
            }
        }
    }
}
