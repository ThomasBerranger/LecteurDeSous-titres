using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class StreamWriters
    {
        public void Write(string s)
        {
            string[] lines = { "Coucou1", "Coucou2", "Coucou3" };

            string mydocpath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Crée un fichier
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt"))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            //Ajoute à un fichier
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt", true))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    }
}
