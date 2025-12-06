using System;
using System.Collections.Generic;

namespace FormaNumarasiKayitSistemi
{
    public class Oyuncu
    {
        public int FormaNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Oyuncu Sol { get; set; }
        public Oyuncu Sag { get; set; }

        public Oyuncu(int formaNo, string ad, string soyad)
        {
            FormaNo = formaNo;
            Ad = ad;
            Soyad = soyad;
            Sol = null;
            Sag = null;
        }

        public override string ToString()
        {
            return $"#{FormaNo} - {Ad} {Soyad}";
        }
    }

    public class FormaNumarasiSistemi
    {
        public Oyuncu Kok { get; private set; }
        public int OyuncuSayisi { get; private set; }

        public FormaNumarasiSistemi()
        {
            Kok = null;
            OyuncuSayisi = 0;
        }

        public bool Ekle(int formaNo, string ad, string soyad, bool kaleciMi = false)
        {
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                Console.WriteLine("✗ Hata: Ad ve soyad boş olamaz!");
                return false;
            }

            Oyuncu yeniOyuncu = new Oyuncu(formaNo, ad, soyad);

            if (Kok == null)
            {
                Kok = yeniOyuncu;
                OyuncuSayisi++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ {(kaleciMi ? "Kaleci eklendi (ROOT)" : "İlk oyuncu eklendi")}: {yeniOyuncu}");
                Console.ResetColor();
                return true;
            }

            if (Ara(formaNo) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✗ Hata: {formaNo} numaralı forma zaten kullanılıyor!");
                Console.ResetColor();
                return false;
            }

            EkleYardimci(Kok, yeniOyuncu);
            OyuncuSayisi++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ Oyuncu eklendi: {yeniOyuncu}");
            Console.ResetColor();
            return true;
        }

        private void EkleYardimci(Oyuncu mevcut, Oyuncu yeni)
        {
            if (yeni.FormaNo < mevcut.FormaNo)
            {
                if (mevcut.Sol == null)
                    mevcut.Sol = yeni;
                else
                    EkleYardimci(mevcut.Sol, yeni);
            }
            else
            {
                if (mevcut.Sag == null)
                    mevcut.Sag = yeni;
                else
                    EkleYardimci(mevcut.Sag, yeni);
            }
        }

        public Oyuncu Ara(int formaNo)
        {
            return AraYardimci(Kok, formaNo);
        }

        private Oyuncu AraYardimci(Oyuncu mevcut, int formaNo)
        {
            if (mevcut == null)
                return null;

            if (formaNo == mevcut.FormaNo)
                return mevcut;
            else if (formaNo < mevcut.FormaNo)
                return AraYardimci(mevcut.Sol, formaNo);
            else
                return AraYardimci(mevcut.Sag, formaNo);
        }

        public bool Sil(int formaNo)
        {
            if (Kok == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ Takımda oyuncu yok!");
                Console.ResetColor();
                return false;
            }

            Oyuncu oyuncu = Ara(formaNo);
            if (oyuncu == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✗ {formaNo} numaralı oyuncu bulunamadı!");
                Console.ResetColor();
                return false;
            }

            Kok = SilYardimci(Kok, formaNo);
            OyuncuSayisi--;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {formaNo} numaralı oyuncu takımdan çıkarıldı.");
            Console.ResetColor();
            return true;
        }

        private Oyuncu SilYardimci(Oyuncu mevcut, int formaNo)
        {
            if (mevcut == null)
                return null;

            if (formaNo < mevcut.FormaNo)
            {
                mevcut.Sol = SilYardimci(mevcut.Sol, formaNo);
            }
            else if (formaNo > mevcut.FormaNo)
            {
                mevcut.Sag = SilYardimci(mevcut.Sag, formaNo);
            }
            else
            {
                if (mevcut.Sol == null && mevcut.Sag == null)
                    return null;

                if (mevcut.Sol == null)
                    return mevcut.Sag;
                if (mevcut.Sag == null)
                    return mevcut.Sol;

                Oyuncu halef = EnKucukBul(mevcut.Sag);
                mevcut.FormaNo = halef.FormaNo;
                mevcut.Ad = halef.Ad;
                mevcut.Soyad = halef.Soyad;
                mevcut.Sag = SilYardimci(mevcut.Sag, halef.FormaNo);
            }

            return mevcut;
        }

        private Oyuncu EnKucukBul(Oyuncu dugum)
        {
            Oyuncu mevcut = dugum;
            while (mevcut.Sol != null)
                mevcut = mevcut.Sol;
            return mevcut;
        }

        public void Preorder()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("PREORDER TRAVERSAL (Kök -> Sol -> Sağ)");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            if (Kok == null)
            {
                Console.WriteLine("Takımda oyuncu yok!");
                return;
            }

            PreorderYardimci(Kok);
            Console.WriteLine();
        }

        private void PreorderYardimci(Oyuncu dugum)
        {
            if (dugum != null)
            {
                Console.WriteLine($"  {dugum}");
                PreorderYardimci(dugum.Sol);
                PreorderYardimci(dugum.Sag);
            }
        }

        public void Inorder()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("INORDER TRAVERSAL (Sol -> Kök -> Sağ) - SIRALI LİSTE");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            if (Kok == null)
            {
                Console.WriteLine("Takımda oyuncu yok!");
                return;
            }

            InorderYardimci(Kok);
            Console.WriteLine();
        }

        private void InorderYardimci(Oyuncu dugum)
        {
            if (dugum != null)
            {
                InorderYardimci(dugum.Sol);
                Console.WriteLine($"  {dugum}");
                InorderYardimci(dugum.Sag);
            }
        }

        public void Postorder()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("POSTORDER TRAVERSAL (Sol -> Sağ -> Kök)");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            if (Kok == null)
            {
                Console.WriteLine("Takımda oyuncu yok!");
                return;
            }

            PostorderYardimci(Kok);
            Console.WriteLine();
        }

        private void PostorderYardimci(Oyuncu dugum)
        {
            if (dugum != null)
            {
                PostorderYardimci(dugum.Sol);
                PostorderYardimci(dugum.Sag);
                Console.WriteLine($"  {dugum}");
            }
        }

        public void LevelOrder()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("LEVEL ORDER TRAVERSAL (Seviye Seviye - BFS)");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            if (Kok == null)
            {
                Console.WriteLine("Takımda oyuncu yok!");
                return;
            }

            Queue<Oyuncu> kuyruk = new Queue<Oyuncu>();
            kuyruk.Enqueue(Kok);
            int seviye = 0;

            while (kuyruk.Count > 0)
            {
                int seviyeBoyutu = kuyruk.Count;
                Console.WriteLine($"\nSeviye {seviye}:");

                for (int i = 0; i < seviyeBoyutu; i++)
                {
                    Oyuncu mevcut = kuyruk.Dequeue();
                    Console.WriteLine($"  {mevcut}");

                    if (mevcut.Sol != null)
                        kuyruk.Enqueue(mevcut.Sol);
                    if (mevcut.Sag != null)
                        kuyruk.Enqueue(mevcut.Sag);
                }

                seviye++;
            }
            Console.WriteLine();
        }

        public Oyuncu EnBuyukForma()
        {
            if (Kok == null)
            {
                Console.WriteLine("Takımda oyuncu yok!");
                return null;
            }

            Oyuncu mevcut = Kok;
            while (mevcut.Sag != null)
                mevcut = mevcut.Sag;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n✓ En büyük forma numarası: {mevcut}");
            Console.ResetColor();
            return mevcut;
        }

        public Oyuncu EnKucukForma()
        {
            if (Kok == null)
            {
                Console.WriteLine("Takımda oyuncu yok!");
                return null;
            }

            Oyuncu mevcut = Kok;
            while (mevcut.Sol != null)
                mevcut = mevcut.Sol;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n✓ En küçük forma numarası: {mevcut}");
            Console.ResetColor();
            return mevcut;
        }

        public void TakimBilgisi()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("TAKIM BİLGİSİ");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"Toplam Oyuncu Sayısı: {OyuncuSayisi}");
            if (Kok != null)
                Console.WriteLine($"Kaleci (ROOT): {Kok}");
            else
                Console.WriteLine("Kaleci: Yok");
            Console.WriteLine(new string('=', 60));
        }

        public void AgacGorsellestir()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("AĞAÇ YAPISI");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            if (Kok == null)
            {
                Console.WriteLine("Ağaç boş!");
                return;
            }

            AgacYazdir(Kok, "", true);
            Console.WriteLine();
        }

        private void AgacYazdir(Oyuncu dugum, string prefix, bool isTail)
        {
            if (dugum != null)
            {
                Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + dugum.ToString());

                if (dugum.Sol != null || dugum.Sag != null)
                {
                    if (dugum.Sol != null)
                    {
                        AgacYazdir(dugum.Sol, prefix + (isTail ? "    " : "│   "), false);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(prefix + (isTail ? "    " : "│   ") + "├── [Boş]");
                        Console.ResetColor();
                    }

                    if (dugum.Sag != null)
                    {
                        AgacYazdir(dugum.Sag, prefix + (isTail ? "    " : "│   "), true);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(prefix + (isTail ? "    " : "│   ") + "└── [Boş]");
                        Console.ResetColor();
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            FormaNumarasiSistemi sistem = new FormaNumarasiSistemi();

            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("SPOR KULÜBÜ FORMA NUMARASI KAYIT SİSTEMİ");
            Console.WriteLine("İkili Arama Ağacı (BST) Uygulaması");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\n>>> İlk oyuncu (KALECİ) bilgilerini giriniz <<<");

            while (true)
            {
                try
                {
                    Console.Write("Kaleci Forma Numarası: ");
                    int formaNo = int.Parse(Console.ReadLine());

                    Console.Write("Kaleci Adı: ");
                    string ad = Console.ReadLine()?.Trim();

                    Console.Write("Kaleci Soyadı: ");
                    string soyad = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(ad) && !string.IsNullOrWhiteSpace(soyad))
                    {
                        sistem.Ekle(formaNo, ad, soyad, kaleciMi: true);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("✗ Ad ve soyad boş olamaz!");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("✗ Geçerli bir forma numarası giriniz!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"✗ Bir hata oluştu: {ex.Message}");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                MenuGoster();

                try
                {
                    Console.Write("\nSeçiminiz: ");
                    string secim = Console.ReadLine()?.Trim();

                    switch (secim)
                    {
                        case "1":
                            OyuncuEkle(sistem);
                            break;

                        case "2":
                            OyuncuAra(sistem);
                            break;

                        case "3":
                            OyuncuSil(sistem);
                            break;

                        case "4":
                            sistem.Preorder();
                            break;

                        case "5":
                            sistem.Inorder();
                            break;

                        case "6":
                            sistem.Postorder();
                            break;

                        case "7":
                            sistem.LevelOrder();
                            break;

                        case "8":
                            sistem.EnBuyukForma();
                            break;

                        case "9":
                            sistem.EnKucukForma();
                            break;

                        case "10":
                            sistem.TakimBilgisi();
                            break;

                        case "11":
                            sistem.AgacGorsellestir();
                            break;

                        case "0":
                            Console.WriteLine("\n" + new string('=', 60));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Programdan çıkılıyor... Görüşmek üzere!");
                            Console.ResetColor();
                            Console.WriteLine(new string('=', 60));
                            return;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n✗ Geçersiz seçim! Lütfen 0-11 arası bir değer giriniz.");
                            Console.ResetColor();
                            break;
                    }

                    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n✗ Bir hata oluştu: {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
            }
        }

        static void MenuGoster()
        {
            Console.Clear();
            Console.WriteLine("\n" + new string('=', 60));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FORMA NUMARASI KAYIT SİSTEMİ - ANA MENÜ");
            Console.ResetColor();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("1.  Oyuncu Ekle");
            Console.WriteLine("2.  Oyuncu Ara");
            Console.WriteLine("3.  Oyuncu Sil");
            Console.WriteLine("4.  Preorder Traversal");
            Console.WriteLine("5.  Inorder Traversal (Sıralı Liste)");
            Console.WriteLine("6.  Postorder Traversal");
            Console.WriteLine("7.  Level Order Traversal");
            Console.WriteLine("8.  En Büyük Forma Numarasını Bul");
            Console.WriteLine("9.  En Küçük Forma Numarasını Bul");
            Console.WriteLine("10. Takım Bilgisi");
            Console.WriteLine("11. Ağaç Yapısını Göster");
            Console.WriteLine("0.  Çıkış");
            Console.WriteLine(new string('=', 60));
        }

        static void OyuncuEkle(FormaNumarasiSistemi sistem)
        {
            try
            {
                Console.Write("\nForma Numarası: ");
                int formaNo = int.Parse(Console.ReadLine());

                Console.Write("Oyuncu Adı: ");
                string ad = Console.ReadLine()?.Trim();

                Console.Write("Oyuncu Soyadı: ");
                string soyad = Console.ReadLine()?.Trim();

                sistem.Ekle(formaNo, ad, soyad);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ Geçerli bir forma numarası giriniz!");
                Console.ResetColor();
            }
        }

        static void OyuncuAra(FormaNumarasiSistemi sistem)
        {
            try
            {
                Console.Write("\nAranacak Forma Numarası: ");
                int formaNo = int.Parse(Console.ReadLine());

                Oyuncu oyuncu = sistem.Ara(formaNo);

                if (oyuncu != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n✓ Oyuncu bulundu: {oyuncu}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n✗ {formaNo} numaralı oyuncu bulunamadı!");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ Geçerli bir forma numarası giriniz!");
                Console.ResetColor();
            }
        }

        static void OyuncuSil(FormaNumarasiSistemi sistem)
        {
            try
            {
                Console.Write("\nSilinecek Forma Numarası: ");
                int formaNo = int.Parse(Console.ReadLine());

                sistem.Sil(formaNo);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ Geçerli bir forma numarası giriniz!");
                Console.ResetColor();
            }
        }
    }
}