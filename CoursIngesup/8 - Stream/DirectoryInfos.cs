using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class DirectoryInfos
    {
        public void Test()
        {
            //https://msdn.microsoft.com/fr-fr/library/system.io.directoryinfo(v=vs.110).aspx

            DirectoryInfo di = new DirectoryInfo(@"c:\Test");

            if (di.Exists)
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            di.Create();
            Console.WriteLine("The directory was created successfully.");

            
            di.Delete();
            Console.WriteLine("The directory was deleted successfully.");

            FileInfo[] files = di.GetFiles(); 
            foreach(FileInfo f in files)
            {
                Console.WriteLine(f.Name);
                Console.WriteLine(f.DirectoryName);
                
            }
            
     
        }
    }
}
