using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DisplayCurrentInfoAsync();
        }
        public static async Task<int> GetUrlContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask =
                client.GetStringAsync("https://docs.microsoft.com/dotnet");

            DoIndependentWork();

            string contents = await getStringTask;

            return contents.Length;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
        public static async Task DisplayCurrentInfoAsync()
        {
            await WaitAndApologizeAsync();

            Console.WriteLine($"Today is {DateTime.Now:D}");
            Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
            Console.WriteLine("The current temperature is 76 degrees.");
        }

        public static async Task WaitAndApologizeAsync()
        {
            await Task.Delay(2000);

            Console.WriteLine("Sorry for the delay...\n");

        }
    }
}
