using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup._4___Fonction
{
    class LectureText
    {

        string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

       

        public void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(mydocpath + @"\Stream.txt"))
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
