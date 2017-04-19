using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class RegexClass
    {
        //http://lgmorand.developpez.com/dotnet/regex/
        Regex r = new Regex("^a");
        Regex Email = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
        public string name;

        public RegexClass(string n)
        {
            if (r.Match(n).Success)
                name = n;
            else
                name = "";
        }

        public string ReplaceHello(string s)
        {
            Regex r = new Regex("(yo|salut|Hey)");
            return r.Replace(s, "bonjour"); 
        }

        public string ReplaceMailToHtml(string s)
        {
            Regex r = new Regex(@"([\w\-.]+@[\w\-.]+)");
            return r.Replace(s, "<a href=\"mailto:$1\" > $1 <a>");
        }


        private string[] SplitterTab(string s)
        {
            Regex r = new Regex(@"\t+");
            return r.Split(s);
        }
    }
}
