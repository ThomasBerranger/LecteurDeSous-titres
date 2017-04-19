using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class StreamReaders
    {
        
        public void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"\WriteLines.txt"))
                {
                    string l;
                    while ((l = sr.ReadLine()) != null)
                        Console.WriteLine(l);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
