using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class
{
    class TestFils : TestParent
    {
        #region Variables
        public string name;
        #endregion

        #region Constructeurs
        public TestFils() : base()
        {
            name = "";
        }

        public TestFils(int x, int y, string name) : base(x, y)
        {
            this.name = name;
        }
        #endregion

        #region Fonctions
        public override void ShowX()
        {
            x++;
            base.ShowX();
        }
        #endregion
    }
}
