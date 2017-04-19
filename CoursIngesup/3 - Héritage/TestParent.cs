using System;

namespace CoursIngesup.Class
{
    abstract class TestParent
    {
        #region Variables
        public int x;
        public int y;
        #endregion

        #region Constructeurs
        public TestParent()
        {
            x = 0;
            y = 0;
        }

        public TestParent(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Fonctions
        public virtual void ShowX()
        {
            Console.WriteLine(x);
        }
        #endregion
    }
}
