using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoursIngesup.Class2
{
    class Asyncs
    {

        //https://msdn.microsoft.com/fr-fr/library/mt674882.aspx
        public static void Main1()
        {
            AsyncAwaitDemo demo = new AsyncAwaitDemo();
            Task t = demo.DoStuff();
            Task<string> task = demo.AccessTheWebAsync();
            Console.WriteLine(task.Result);
            Console.Clear();
            Console.ReadLine();
        }

        public class AsyncAwaitDemo
        {

            public async Task DoStuff()
            {
                await Task.Run(() =>
                {
                    Task<string> task = LongRunningOperation();
                });
            }

            private static async Task<string> LongRunningOperation()
            {
                int counter;

                for (counter = 0; counter < 500000; counter++)
                {
                    Console.Clear();
                    Console.WriteLine(counter);
                }
                return "Counter = " + counter;
            }

            public async Task<string> AccessTheWebAsync()
            {

                HttpClient client = new HttpClient();
                Task<string> getStringTask = client.GetStringAsync("http://www.pouet.net/");
                string urlContents = await getStringTask;
                return urlContents;
            }

            public async Task<int> test()
            {
                int rand = await GetRandomNumberAsync();

                return rand;
            }

            public async Task<int> GetRandomNumberAsync()
            {
                await Task.Delay(2000);
                return (new Random()).Next();
            }

            public async Task<string> GetSpecialStringAsync(string message)
            {
                await Task.Delay(2000);
                return string.IsNullOrEmpty(message) ? "<RIEN>" : message.ToUpper();
            }
        }

      
    }
}
