using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class Exeptions 
    {
        private string name;

        public Exeptions(string s)
        {
            if (s == "")
            {
                throw new Exception("Name can't be empty");
            }
            name = s;

            try
            {
                int n = int.Parse(Console.ReadLine());
                int div = 10 / n;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Erreur : division par zéro.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Message");
            }


            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    //Do something with sr
                }
            }
            catch (Exception e)
            {
               //Handle exception
            }
        }
    }
}
