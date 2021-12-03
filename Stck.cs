using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1_AIS
{
    class Stck
    {
        public Item head;
        public int count;

        public Stck()
        {
            count = 0;
            head = null;
        }
        public Stck(int data)
        {
            head = new Item(data);
            count = 1;
        }
        public void Push(int data)
        {
            var item = new Item(data);
            item.previous = head;
            head = item;
            count++;
        }
        public int Pop()
        {
            var item = head;
            head = head.previous;
            count--;
            return item.data;
        }
        public int Peek()
        {
            return head.data;
        }
    }
}
