using System.ComponentModel;

namespace sıra_uygulama
{
    public class MyQueue
    {
        public Node head { get; private set; }
        public Node tail { get; private set; }
        public int queueID { get; private set; }
        public BindingList<string> Items { get; } = new BindingList<string>();
        public int Count { get; private set; }

        private int nextTicket;


        public MyQueue(int id)
        {
            head = null;
            tail = null;
            queueID = id;
            Count = 0;
            nextTicket = queueID * 100;
        }

        public void Enqueue()
        {
            Node newNode = new Node(nextTicket, queueID);
            newNode.Next = null;
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Items.Add(newNode.ToString());
            nextTicket++;
            Count++;
        }

        public string Dequeue()
        {
            if (head == null) return "-1";

            var removed = head;
            string value = removed.ToString();

            head = head.Next;
            if (head == null) tail = null;

            if (Items.Count > 0) Items.RemoveAt(0);
            Count--;

            removed.Next = null;
            return value;
        }

        public string PeekHead()
        {
            return head == null ? "-1" : head.ToString();
        }

        public string PeekTail()
        {
            return tail == null ? "-1" : tail.ToString();
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Items.Clear();
            Count = 0;
        }
    }
}
