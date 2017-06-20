using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    public class Taskclass
    {
        public static void Tasker()
        {

            var t = Task.Run(() =>
            {
                Task.Delay(10000).Wait();
                Console.WriteLine("returning 42");
                return 42;
            });

            var t2 = t.ContinueWith(x =>
            {
                Console.WriteLine("[CONTINUATION]" + x.Result);
            });

            //t2.ContinueWith();
            Console.Write("End of Task");


        }

        public static Task<bool> Primer(int prime, CancellationToken cancelToken)
        {
            return Task.Run(() =>
            {
                if (prime < 2)
                {
                    return false;
                }

                if (prime % 2 == 0)
                {
                    return false;
                }

                int root = (int) Math.Sqrt(prime);

                for (int i = 3; i <= root; i += 2)
                {
                    if (prime % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }, cancelToken);

        }

        public static async Task Asynctask(CancellationToken cancelToken)
        {
            for (var i = 1; i < int.MaxValue; i++)
            {
                //Zum Abbrechen der Berechung, Könnte etwas länger dauern
                cancelToken.ThrowIfCancellationRequested();
                //Wartet auf Prime größer 100000
                if (await Primer(i, cancelToken)) Console.WriteLine($"Primzahl: {i}");
            }
        }
    }
}
