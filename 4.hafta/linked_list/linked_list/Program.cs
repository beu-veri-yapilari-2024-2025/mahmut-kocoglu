using System;

namespace linked_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var liste = new SınıfListesi();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n====== Sınıf Listesi ======");
                liste.Display();
                Console.WriteLine("===========================");
                Console.WriteLine("\n===== Liste İşlemleri =====");
                Console.WriteLine("1) Başa ekle");
                Console.WriteLine("2) Sona ekle");
                Console.WriteLine("3) Belirli SIRA'dan SONRA ekle");
                Console.WriteLine("4) Belirli SIRA'dan ÖNCE ekle");
                Console.WriteLine("5) Baştan sil");
                Console.WriteLine("6) Sondan sil");
                Console.WriteLine("7) Belirli SIRA'yı sil");
                Console.WriteLine("8) Belirli SIRA'dan SONRA'yı sil");
                Console.WriteLine("9) Belirli SIRA'dan ÖNCE'yi sil");
                Console.WriteLine("10) Ara (SIRA NO)");
                Console.WriteLine("11) Listele");
                Console.WriteLine("12) Temizle");
                Console.WriteLine("0) Çık");
                Console.WriteLine("===========================");
                Console.Write("Seçim: ");
                var secim = Console.ReadLine();

                try
                {
                    switch (secim)
                    {
                        case "1":
                            {
                                var o = OgrenciOku();
                                liste.AddFirst(o.OgrenciNo, o.OgrenciAd, o.OgrenciSoyad);
                                break;
                            }
                        case "2":
                            {
                                var o = OgrenciOku();
                                liste.AddLast(o.OgrenciNo, o.OgrenciAd, o.OgrenciSoyad);
                                break;
                            }
                        case "3":
                            {
                                Console.Write("Hangi SIRA'dan SONRA eklensin? ");
                                int sira = int.Parse(Console.ReadLine());
                                var o = OgrenciOku();
                                if (!liste.InsertAfterSira(sira, o))
                                    Console.WriteLine("→ Geçersiz Sıra No.");
                                break;
                            }
                        case "4":
                            {
                                Console.Write("Hangi SIRA'dan ÖNCE eklensin? ");
                                int sira = int.Parse(Console.ReadLine());
                                var o = OgrenciOku();
                                if (!liste.InsertBeforeSira(sira, o))
                                    Console.WriteLine("→ Geçersiz Sıra No.");
                                break;
                            }
                        case "5":
                            {
                                if (!liste.DeleteFirst()) Console.WriteLine("→ Liste boş.");
                                break;
                            }
                        case "6":
                            {
                                if (!liste.DeleteLast()) Console.WriteLine("→ Liste boş.");
                                break;
                            }
                        case "7":
                            {
                                Console.Write("Silinecek SIRA: ");
                                int sira = int.Parse(Console.ReadLine());
                                if (!liste.DeleteBySira(sira)) Console.WriteLine("→ Geçersiz Sıra No.");
                                break;
                            }
                        case "8":
                            {
                                Console.Write("Hangi SIRA'dan SONRA silinsin? ");
                                int sira = int.Parse(Console.ReadLine());
                                if (!liste.DeleteAfterSira(sira)) Console.WriteLine("→ Uygun düğüm yok.");
                                break;
                            }
                        case "9":
                            {
                                Console.Write("Hangi SIRA'dan ÖNCE silinsin? ");
                                int sira = int.Parse(Console.ReadLine());
                                if (!liste.DeleteBeforeSira(sira)) Console.WriteLine("→ Uygun düğüm yok.");
                                break;
                            }
                        case "10":
                            {
                                Console.Write("Ara (SIRA NO): ");
                                int sira = int.Parse(Console.ReadLine());
                                var bulunan = liste.FindBySira(sira);
                                Console.WriteLine(bulunan == null
                                    ? "→ Bulunamadı."
                                    : $"Bulundu: {bulunan.SiraNo}) {bulunan.OgrenciNo} - {bulunan.OgrenciAd} {bulunan.OgrenciSoyad}");
                                break;
                            }
                        case "11":
                            {
                                liste.Display();
                                Console.WriteLine($"\nToplam: {liste.Count()}");
                                break;
                            }
                        case "12":
                            {
                                liste.Clear();
                                Console.WriteLine("→ Temizlendi.");
                                break;
                            }
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Geçersiz seçim.");
                            break;
                    }
                    Console.Write("Devam etmek için bir tuşa basınız...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                    Console.Write("Devam için bir tuşa basın...");
                    Console.ReadKey();
                }
            }
        }

        static Ogrenci OgrenciOku()
        {
            Console.Write("Öğrenci No: ");
            int no = int.Parse(Console.ReadLine());
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            return new Ogrenci(no, ad, soyad);
        }
    }

    // ================== Node: Ogrenci ==================
    public class Ogrenci
    {
        public int SiraNo { get; set; }            // listedeki sıra (1..N) — otomatik güncellenir
        public int OgrenciNo { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public Ogrenci Next { get; set; }          // bağlantı (bir sonraki düğüm)

        public Ogrenci(int no, string ad, string soyad)
        {
            OgrenciNo = no;
            OgrenciAd = ad;
            OgrenciSoyad = soyad;
            Next = null;
        }
    }

    // ================== Linked List: SınıfListesi ==================
    public class SınıfListesi
    {
        private Ogrenci head; // listenin başı

        public SınıfListesi() => head = null;

        // ---- SIRA GÜNCELLEME ----
        private void SiraGuncelle()
        {
            int sira = 1;
            var temp = head;
            while (temp != null)
            {
                temp.SiraNo = sira++;
                temp = temp.Next;
            }
        }

        // ---- Yardımcılar ----
        public int Count()
        {
            int c = 0; var t = head;
            while (t != null) { c++; t = t.Next; }
            return c;
        }

        public Ogrenci FindBySira(int siraNo)
        {
            var t = head;
            while (t != null)
            {
                if (t.SiraNo == siraNo) return t;
                t = t.Next;
            }
            return null;
        }

        private bool IsValidSiraForExisting(int siraNo)
        {
            return siraNo >= 1 && siraNo <= Count();
        }

        private bool IsValidSiraForInsertAfter(int siraNo)
        {
            // After için 1..Count aralığı geçerli
            return siraNo >= 1 && siraNo <= Count();
        }

        private bool IsValidSiraForInsertBefore(int siraNo)
        {
            // Before için 1..Count aralığı geçerli
            return siraNo >= 1 && siraNo <= Count();
        }

        // ---- Ekleme ----
        public void AddFirst(int no, string ad, string soyad)
        {
            var n = new Ogrenci(no, ad, soyad) { Next = head };
            head = n;
            SiraGuncelle();
        }

        public void AddLast(int no, string ad, string soyad)
        {
            var n = new Ogrenci(no, ad, soyad);
            if (head == null) { head = n; SiraGuncelle(); return; }

            var t = head;
            while (t.Next != null)
            {
                t = t.Next;
                t.Next = n;
                SiraGuncelle();
            }
        }

        public bool InsertAfterSira(int siraNo, Ogrenci yeni)
        {
            if (!IsValidSiraForInsertAfter(siraNo)) return false;

            var hedef = FindBySira(siraNo);
            if (hedef == null) return false;

            yeni.Next = hedef.Next;
            hedef.Next = yeni;
            SiraGuncelle();
            return true;
        }

        public bool InsertBeforeSira(int siraNo, Ogrenci yeni)
        {
            if (!IsValidSiraForInsertBefore(siraNo)) return false;

            if (head == null) return false;

            if (head.SiraNo == siraNo)
            {
                yeni.Next = head;
                head = yeni;
                SiraGuncelle();
                return true;
            }

            Ogrenci prev = head;
            Ogrenci cur = head.Next;
            while (cur != null && cur.SiraNo != siraNo)
            {
                prev = cur;
                cur = cur.Next;
            }
            if (cur == null) return false;

            yeni.Next = cur;
            prev.Next = yeni;
            SiraGuncelle();
            return true;
        }

        // ---- Silme ----
        public bool DeleteFirst()
        {
            if (head == null) return false;
            head = head.Next;
            SiraGuncelle();
            return true;
        }

        public bool DeleteLast()
        {
            if (head == null) return false;
            if (head.Next == null) { head = null; SiraGuncelle(); return true; }

            var prev = head;
            var cur = head.Next;
            while (cur.Next != null)
            {
                prev = cur;
                cur = cur.Next;
            }
            prev.Next = null;
            SiraGuncelle();
            return true;
        }

        public bool DeleteBySira(int siraNo)
        {
            if (!IsValidSiraForExisting(siraNo)) return false;
            if (head == null) return false;

            if (head.SiraNo == siraNo)
            {
                head = head.Next;
                SiraGuncelle();
                return true;
            }

            Ogrenci prev = head;
            Ogrenci cur = head.Next;
            while (cur != null && cur.SiraNo != siraNo)
            {
                prev = cur;
                cur = cur.Next;
            }
            if (cur == null) return false;

            prev.Next = cur.Next;
            SiraGuncelle();
            return true;
        }

        public bool DeleteAfterSira(int siraNo)
        {
            // siraNo mevcut olmalı ve sonrası olmalı
            var hedef = FindBySira(siraNo);
            if (hedef == null || hedef.Next == null) return false;

            hedef.Next = hedef.Next.Next;
            SiraGuncelle();
            return true;
        }

        public bool DeleteBeforeSira(int siraNo)
        {
            if (!IsValidSiraForExisting(siraNo)) return false;
            if (head == null || head.SiraNo == siraNo) return false; // başın öncesi yok

            // hedef head'in hemen sonrası ise head'i kaydır
            if (head.Next != null && head.Next.SiraNo == siraNo)
            {
                head = head.Next;
                SiraGuncelle();
                return true;
            }

            Ogrenci pp = head;               // previous of previous
            Ogrenci p = head.Next;           // previous
            Ogrenci c = head.Next?.Next;     // current (hedef)
            while (c != null && c.SiraNo != siraNo)
            {
                pp = p;
                p = c;
                c = c.Next;
            }
            if (c == null) return false;

            // p, hedefin öncesi; onu çıkar
            pp.Next = c;
            SiraGuncelle();
            return true;
        }

        // ---- Gösterim ----
        public void Display()
        {
            if (head == null) { Console.WriteLine("(boş)"); return; }
            var t = head;
            while (t != null)
            {
                Console.WriteLine($"{t.SiraNo}) {t.OgrenciNo} - {t.OgrenciAd} {t.OgrenciSoyad}");
                if (t.Next != null) Console.WriteLine("|");
                t = t.Next;
            }
        }

        public void Clear()
        {
            head = null;
        }
    }
}
