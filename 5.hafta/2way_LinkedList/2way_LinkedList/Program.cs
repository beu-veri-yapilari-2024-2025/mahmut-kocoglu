using System;
using System.Collections.Generic;

namespace IkiYonluBagliListe
{
    public class Node
    {
        public int Data;
        public Node Next;
        public Node Prev;

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        // BAŞA EKLEME
        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
                head = tail = newNode;
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }

        // SONA EKLEME
        public void AddLast(int data)
        {
            Node newNode = new Node(data);
            if (tail == null)
                head = tail = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        // BELİRLİ BİR DEĞERDEN SONRA EKLEME
        public void AddAfter(int target, int data)
        {
            Node current = head;
            while (current != null && current.Data != target)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{target} bulunamadı. Eklenmedi.");
                return;
            }

            Node newNode = new Node(data);
            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode; // sona eklendiyse tail güncellenir

            current.Next = newNode;
        }

        // BELİRLİ BİR DEĞERDEN ÖNCE EKLEME
        public void AddBefore(int target, int data)
        {
            Node current = head;
            while (current != null && current.Data != target)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{target} bulunamadı. Eklenmedi.");
                return;
            }

            Node newNode = new Node(data);
            newNode.Next = current;
            newNode.Prev = current.Prev;

            if (current.Prev != null)
                current.Prev.Next = newNode;
            else
                head = newNode; // başa eklendiyse head güncellenir

            current.Prev = newNode;
        }

        // BAŞTAN SİLME
        public void RemoveFirst()
        {
            if (head == null)
            {
                Console.WriteLine("Liste zaten boş.");
                return;
            }

            if (head.Next == null)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
        }

        // SONDAN SİLME
        public void RemoveLast()
        {
            if (tail == null)
            {
                Console.WriteLine("Liste zaten boş.");
                return;
            }

            if (tail.Prev == null)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
        }

        // ARADAN VERİYİ BULUP SİLME
        public void RemoveByValue(int data)
        {
            Node current = head;
            while (current != null && current.Data != data)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{data} bulunamadı. Silinmedi.");
                return;
            }

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                tail = current.Prev;
        }

        // ARAMA
        public bool Search(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                    return true;
                current = current.Next;
            }
            return false;
        }

        // LİSTELEME (BAŞTAN SONA)
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("[liste boş]");
                return;
            }

            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Next != null) Console.Write(" <-> ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // TÜM LİSTEYİ SİL
        public void Clear()
        {
            head = tail = null;
        }

        // LİSTEYİ DİZİYE AKTAR
        public int[] ToArray()
        {
            List<int> values = new List<int>();
            Node current = head;
            while (current != null)
            {
                values.Add(current.Data);
                current = current.Next;
            }
            return values.ToArray();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            while (true)
            {
                Console.WriteLine("\n=== İki Yönlü Bağlı Liste İşlemleri ===");
                Console.WriteLine("1) Başa ekle");
                Console.WriteLine("2) Sona ekle");
                Console.WriteLine("3) Belirli bir değerden SONRA ekle");
                Console.WriteLine("4) Belirli bir değerden ÖNCE ekle");
                Console.WriteLine("5) Baştan sil");
                Console.WriteLine("6) Sondan sil");
                Console.WriteLine("7) Değeri bularak sil");
                Console.WriteLine("8) Arama");
                Console.WriteLine("9) Listeyi yazdır");
                Console.WriteLine("10) Tümünü sil (Clear)");
                Console.WriteLine("11) Diziye aktar");
                Console.WriteLine("0) Çıkış");
                Console.Write("Seçimin: ");

                string secim = Console.ReadLine();
                Console.WriteLine();

                if (secim == "0")
                {
                    Console.WriteLine("Program sonlandırıldı.");
                    break;
                }

                switch (secim)
                {
                    case "1":
                        // Başa ekle
                        Console.Write("Eklenecek değeri gir: ");
                        if (int.TryParse(Console.ReadLine(), out int val1))
                        {
                            list.AddFirst(val1);
                            Console.WriteLine("Başa eklendi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz sayı.");
                        }
                        break;

                    case "2":
                        // Sona ekle
                        Console.Write("Eklenecek değeri gir: ");
                        if (int.TryParse(Console.ReadLine(), out int val2))
                        {
                            list.AddLast(val2);
                            Console.WriteLine("Sona eklendi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz sayı.");
                        }
                        break;

                    case "3":
                        // Belirli değerden SONRA ekle
                        Console.Write("Hangi değerden sonra? ");
                        int afterTarget;
                        if (!int.TryParse(Console.ReadLine(), out afterTarget))
                        {
                            Console.WriteLine("Geçersiz sayı.");
                            break;
                        }
                        Console.Write("Eklenecek yeni değer: ");
                        int afterVal;
                        if (!int.TryParse(Console.ReadLine(), out afterVal))
                        {
                            Console.WriteLine("Geçersiz sayı.");
                            break;
                        }
                        list.AddAfter(afterTarget, afterVal);
                        break;

                    case "4":
                        // Belirli değerden ÖNCE ekle
                        Console.Write("Hangi değerden önce? ");
                        int beforeTarget;
                        if (!int.TryParse(Console.ReadLine(), out beforeTarget))
                        {
                            Console.WriteLine("Geçersiz sayı.");
                            break;
                        }
                        Console.Write("Eklenecek yeni değer: ");
                        int beforeVal;
                        if (!int.TryParse(Console.ReadLine(), out beforeVal))
                        {
                            Console.WriteLine("Geçersiz sayı.");
                            break;
                        }
                        list.AddBefore(beforeTarget, beforeVal);
                        break;

                    case "5":
                        // Baştan sil
                        list.RemoveFirst();
                        Console.WriteLine("Baştan silme denendi.");
                        break;

                    case "6":
                        // Sondan sil
                        list.RemoveLast();
                        Console.WriteLine("Sondan silme denendi.");
                        break;

                    case "7":
                        // Değeri bularak sil
                        Console.Write("Silinecek değeri gir: ");
                        if (int.TryParse(Console.ReadLine(), out int delVal))
                        {
                            list.RemoveByValue(delVal);
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz sayı.");
                        }
                        break;

                    case "8":
                        // Arama
                        Console.Write("Aranacak değeri gir: ");
                        if (int.TryParse(Console.ReadLine(), out int searchVal))
                        {
                            bool bulundu = list.Search(searchVal);
                            Console.WriteLine(bulundu
                                ? $"{searchVal} listede VAR."
                                : $"{searchVal} listede YOK.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz sayı.");
                        }
                        break;

                    case "9":
                        // Listele
                        Console.WriteLine("Liste (baştan sona):");
                        list.Display();
                        break;

                    case "10":
                        // Clear
                        list.Clear();
                        Console.WriteLine("Liste tamamen silindi (Clear).");
                        break;

                    case "11":
                        // Diziye aktar
                        int[] arr = list.ToArray();
                        Console.WriteLine("Dizi içeriği: " + string.Join(", ", arr));
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }

                Console.WriteLine("\nMevcut Liste Durumu:");
                list.Display();
                Console.WriteLine();
                Console.WriteLine("Devam etmek için ENTER...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
