using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class Person
    {
        public int age;
        public string name;

        public Person(string s)
        {
            Random r = new Random();
            age = r.Next(0, 100);
            name = s;
        }
    }

    class ExpressionInitialisation
    {
        //https://msdn.microsoft.com/fr-fr/library/bb738566(v=vs.110).aspx
        public void TestOver18()
        {
            var v = new { Number = 108, Message = "Hello" };

            List<Person> persons = new List<Person>();
            persons.Add(new Person("Tom"));
            persons.Add(new Person("Toto"));
            persons.Add(new Person("Luc"));
            persons.Add(new Person("Lucies"));


            var NamesOver18 =
                from p in persons
                where p.age >= 18 
                select new { p.name };

            foreach (var name in NamesOver18)
                Console.WriteLine(name);
        }
    }
}
