using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
namespace TestConsole_shw
{
    class Program
    {
        static List<int> Merge(List<int> low, List<int> high)
        {
            List<int> returnList = new List<int>();
            while (low.Count > 0 || high.Count > 0)
            {
                if (low.Count > 0 && high.Count > 0)
                {
                    if (low.First() <= high.First())
                    {
                        returnList.Add(low.First());
                        low.Remove(low.First()); //since we added it to the list
                    }
                    else
                    {
                        returnList.Add(high.First());
                        high.Remove(high.First());
                    }
                }
                else if (low.Count > 0)
                {
                    returnList.Add(low.First());
                    low.Remove(low.First());
                }
                else if (high.Count > 0)
                {
                    returnList.Add(high.First());
                    high.Remove(high.First());
                }
            }

            return returnList; //holds a list
        }

        static List<int> MergeSort(List<int> usList)
        {
            if (usList == null)
            {
                Console.WriteLine("Error: List is empty");
                return null;

            }
            if (usList.Count == 1)
            {
                return usList;
            }
            List<int> low = new List<int>();
            List<int> high = new List<int>();
            int mid = usList.Count / 2;
            for (int i = 0; i < mid; i++)
            {
                low.Add(usList[i]);
            }
            for (int i = mid; i < usList.Count; i++)
            {
                high.Add(usList[i]);
            }
            low = MergeSort(low);
            high = MergeSort(high);

            return Merge(low, high);
        }

        static List<int> ThreadedMS(List<int> usList)
        {
            int i = 0;
            int mid = 0;
            int j = mid;
            List<int> low = new List<int>();
            List<int> high = new List<int>();
            mid = usList.Count / 2;

           //if (usList == null)
           // {
           //     throw new ArgumentNullException("usList");

           // }
            if (usList.Count <= 1)
            {
                //there is only element-->>sorted
                return usList;
            }



            while (i < mid)
            {
                low.Add(usList[i]);
                i++;
            }

            while (j < usList.Count)
            {
                high.Add(usList[j]);
                j++;
            }
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
            Thread t_low = new Thread(new ThreadStart(() => { low = ThreadedMS(low); }));
            Thread t_high = new Thread(new ThreadStart(() => { high = ThreadedMS(high); }));

            t_low.Start(); //start both threads
            t_high.Start();
            t_low.Join(); //join them
            t_high.Join();

            return Merge(low, high);
        }

        static void TimeCheck(int NumElements)
        {
            int n = 0;
            long milliseconds;
            Random rand = new Random();
            List<int> inputMS = new List<int>();
            List<int> inputTMS = new List<int>();

            for (int i = 0; i < NumElements; i++)
            {
                n = rand.Next(0, Int32.MaxValue); //long list of nums
                inputMS.Add(n);
                inputTMS.Add(n); //populating the lists


            }

            milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            inputMS = MergeSort(inputMS);
            Console.WriteLine("The time for Merge Sort to execute {0} numbers is {1} milliseconds \n", NumElements,
                milliseconds);

            milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            inputTMS = MergeSort(inputTMS);
            Console.WriteLine("The time for Threaded Merge Sort to execute {0} numbers is {1} milliseconds \n", NumElements,
                milliseconds);
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo key_click;
            Console.WriteLine(
                "Press a key to start the program. \nYou may press the esc key to stop program execution\n\n");
            do
            {
                key_click = Console.ReadKey();
                Console.Write(" --- You pressed "); //taken from MSDN console.readkey
                Console.WriteLine(key_click.Key.ToString());
                TimeCheck(8);
                TimeCheck(64);
                TimeCheck(256);
                TimeCheck(1024);
                TimeCheck(2048);
                TimeCheck(4096);
                TimeCheck(10000);
                TimeCheck(100000);
                TimeCheck(1000000);


            } while (key_click.Key != ConsoleKey.Escape);

        }
    }
}
