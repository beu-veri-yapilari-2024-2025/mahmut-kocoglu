using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sıra_uygulama
{
    public class Node
    {
        public int nodeID { get; private set; }
        public int Ticket { get; private set; }
        public Node Next { get; set; }
        public Node(int ticket, int id)
        {
            Ticket = ticket;
            Next = null;
            nodeID = id;
            
        }

        public override string ToString()
        {
            return Ticket.ToString();
        }
    }
}
