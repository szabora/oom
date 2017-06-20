using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    public class taskclass
    {
        public static void Tasker()
        {
            
            var t = Task.Run(() =>
            {
                Task.Delay(10000).Wait();
                Console.WriteLine("returning 42");
                return 42;
            });

            var t2 = t.ContinueWith(x=>{
                Console.WriteLine("[CONTINUATION]"+ x.Result);
            });

            //t2.ContinueWith();
            Console.Write("End of Task");


        }
        public static Task<bool> Task primer(int prime,CancellationToken CancelToken)
        {
            return Task.Run(() =>
            {
                if (prime < 2) return false;

                if (prime % 2 == 0) return false;

                int root = (int)Math.Sqrt((double)prime);

                for (int i = 3; i <= root; i += 2)
                {
                    if (prime % i == 0) return false;
                }
                if (prime > 100000) return true;
            }, CancelToken);

        }
		public static async Task Berechneetwas(CancellationToken CancelToken)
		{
			for (var i = 1; i < int.MaxValue; i++)
			{
				//Zum Abbrechen der Berechung, Könnte etwas länger dauern
				CancelToken.ThrowIfCancellationRequested();
				//Wartet auf Prime größer 100000
				if (await primer(i, CancelToken)) Console.WriteLine($"Zahl: {i}");
			}
		}
}
