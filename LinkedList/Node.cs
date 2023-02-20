using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class Node
    {
        private int? value; // Nullable int variable
        private Node next; // Next element pointer

        public Node()
        {
            this.value = null;
            this.next = null;
        }

        public Node(int? value) { 
            this.value = value;
            this.next = null;
        }

        public Node Next {
            get { return this.next; }
            set { this.next = value;}
        }
        public int? Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

    }
}
