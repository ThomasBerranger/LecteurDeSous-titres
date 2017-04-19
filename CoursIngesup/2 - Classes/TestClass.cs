using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class TestClass
    {

        #region variables
        // https://msdn.microsoft.com/fr-fr/library/ba0a1yw2.aspx
        public static float NumeroDeSerie = 0;

        public int Integer;
        public float Float;
        public string Str;

        protected double d;

        internal decimal deci;

        private string name;

        
        //ctrl+r+e
        public double Hours
        {
            get { return Seconds / 3600; }
            set { Seconds = value * 3600; }
        }

        private int days;
        public int Days { get; set; }

        private double seconds;
        public double Seconds
        {
            get
            {
                return seconds;
            }

            set
            {
                seconds = value;
            }
        }

        #endregion

        #region constructeurs
        public TestClass( int Integer, float f, string s)
        {
            this.Integer = Integer;
            Float = f;
            Str = s;

        }

        //Optionnel
        public TestClass()
        { }

        #endregion

    }
}
