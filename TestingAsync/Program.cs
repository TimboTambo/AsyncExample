using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestingAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            Console.WriteLine("First - awaiting each task in order");
            stopWatch.Start();
            await Method1();
            await Method2();
            Console.WriteLine($"Finished - {stopWatch.Elapsed}");

            stopWatch.Reset();

            Console.WriteLine("Now awaiting each task when needed");
            stopWatch.Start();
            var task1 = Method1();
            await Method2();
            await task1;
            Console.WriteLine($"Finished - {stopWatch.Elapsed}");

            Console.ReadLine();
        }

        public static async Task Method1()
        {
            Console.WriteLine("Method 1 called");
            await Task.Delay(3000);
            Console.WriteLine("Method 1 returning");
        }

        public static async Task Method2()
        {
            Console.WriteLine("Method 2 called");
            await Task.Delay(2000);
            Console.WriteLine("Method 2 returning");
        }
    }
}
