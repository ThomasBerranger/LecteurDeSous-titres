using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class Program
    {
        static void Test(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));
            c.LimitReached += OverLimit1;
            c.LimitReached += OverLimit2;
            c.LimitReached += OverLimit3;
        }

        static void OverLimit1(object sender, EventArgs e)
        {
            Counter c = (Counter)sender;
            LimitReachedEventArgs eve = (LimitReachedEventArgs)e;
            Console.WriteLine("Warning !!!!");
        }

        static void OverLimit2(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        static void OverLimit3(object sender, EventArgs e)
        {
            Counter c = (Counter)sender;
            Console.WriteLine(c.total);
        }
    }

    class Counter
    {
        private int limit;
        public int total;

        public Counter(int limit)
        {
            this.limit = limit;
        }

        public void Add()
        {
            total++;
            if (total >= limit)
                OnLimitReached(EventArgs.Empty);
            /*
            {
                LimitReachedEventArgs args = new LimitReachedEventArgs();
                args.Limit = limit;
                args.TimeReached = DateTime.Now;
                OnLimitReached(args);
            }*/
        }

        protected virtual void OnLimitReached(EventArgs e)
        {
            LimitReached?.Invoke(this, e);
        }

        public event EventHandler LimitReached;
        //public event EventHandler<LimitReachedEventArgs> LimitReached;
        
    }
    
    
    public class LimitReachedEventArgs : EventArgs
    {
        public int Limit { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
