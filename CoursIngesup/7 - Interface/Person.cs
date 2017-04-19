using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class.Interface
{
    class Person : IPerson
    {
        private int age;

        public int Age { get { return age; } set { age = value; } }

        public Person(int age)
        {
            this.age = age;
        }

        public void Vieillir()
        {
            age++;
        }
    }
}
