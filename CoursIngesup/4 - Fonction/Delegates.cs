using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class Delegates
    {
        delegate int Del(int i);

        public void TestDel()
        {
            Del del2 = Write;

            Del del = x => x * x;
            int a = del(5);
        }

        public int Write(int i)
        {
            Console.WriteLine(i);
            return i;
        }



        private delegate void DelegateTri(int[] tableau);

        private void TriAscendant(int[] tableau)
        {
            Array.Sort(tableau);
        }

        private void TriDescendant(int[] tableau)
        {
            Array.Sort(tableau);
            Array.Reverse(tableau);
        }

        private void Tri1(int[] tableau)
        {
            DelegateTri tri = TriAscendant;
            tri(tableau);
        }

        private void Tri2(int[] tableau, DelegateTri methodeDeTri)
        {
            methodeDeTri(tableau);
        }

        public void Tri3(int[] tableau)
        {
            DelegateTri tri = TriAscendant;
            tri += TriDescendant;
            tri += (int[] tab) =>
            {
                Console.WriteLine(tab.Length);
            };
            tri(tableau);

        }
    }
}
