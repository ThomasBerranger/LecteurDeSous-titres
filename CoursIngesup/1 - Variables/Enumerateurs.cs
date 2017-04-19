using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class Enumerateurs
    {

        //https://msdn.microsoft.com/fr-fr/library/sbbt4032.aspx

        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }; //0,1,2,3,4,5,6

        public Enumerateurs()
        {

            Days S = Days.Sun;
            Days M = Days.Mon;

            int x = (int)Days.Sun; //0
            int y = (int)Days.Fri; //5

            
        }
    }
}
