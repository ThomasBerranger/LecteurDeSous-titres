using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class Collections 
    {

        public int a;

        public Collections()
        {
            
            //Tab
            //https://msdn.microsoft.com/fr-fr/library/9b9dty7d.aspx

            int[] t1 = new int[2];
            t1[0] = 1; 
            t1[2] = 4;

            int[] t2 = new int[4] { 2, 4, 6, 8 };
            for (int i = 0; i < t2.Length; i++)
                t2[i] = i;

            //Multidimentional tab
            int[,] t3 = new int[10, 10];
            t3[0, 0] = 0;

            int[,] t4 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            //Jagged Array
            int[][] t5 = new int[][] { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };


            //List
            //https://msdn.microsoft.com/fr-fr/library/6sh2ey19(v=vs.110).aspx
            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(4);
            ints.Add(2);
            ints.Add(5);
            ints.Remove(5);

            ints.Sort();

            var IntsSorted = from s in ints
                       orderby s descending
                       select s;

            //Hashtable
            //https://msdn.microsoft.com/fr-fr/library/system.collections.hashtable(v=vs.110).aspx
            Hashtable hash = new Hashtable();
            hash.Add("txt", "Word");
            hash.Add("xls", "Exel");
            hash.Add("ppt", "PowerPoint");
            hash.Add(1, 1);

            Console.WriteLine(hash["txt"]);

            foreach (DictionaryEntry key in hash)
                Console.WriteLine(key.Key + " " + key.Value);

            //Dictionary
            //https://msdn.microsoft.com/fr-fr/library/xfhwa508(v=vs.110).aspx
            Dictionary<string, float> dico = new Dictionary<string, float>();
            dico.Add("Toto", 15);
            dico.Add("Tata", 18);
            dico.Add("Bob", 1);
            foreach (KeyValuePair<string, float> k in dico)
                Console.Write(k.Key + " " + k.Value);
        }
    }
}
