using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var t = DisplayCurrentInfoAsync();
            t.GetAwaiter().GetResult();
        }

        public static async Task DisplayCurrentInfoAsync()
        {
            var t1 = WaitAndApologizeAsync();
            var t2 = WaitAndApologizeAsync2();

            await Task.WhenAll(t1, t2);


            Console.WriteLine($"Today is {DateTime.Now:D}");
            await Task.Delay(1000);
            Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
            Console.WriteLine("The current temperature is 76 degrees.");
        }

        public static async Task WaitAndApologizeAsync()
        {
            await Task.Delay(5000);

            Console.WriteLine("Sorry for the delay...\n");
        }
        public static async Task WaitAndApologizeAsync2()
        {
            await Task.Delay(6000);

            Console.WriteLine("Sorry again for the delay...\n");
        }
    }
}
