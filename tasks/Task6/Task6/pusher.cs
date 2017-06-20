using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    public class Pusher
    {
        public static void PPusher()
        {
            var thread = new Thread(
                ()=>
              {
                  var prime = 0;
                while (true)
                  {
                    prime++;
                    if (prime < 2) continue;
					if (prime % 2 == 0) continue;
					  int root = (int)Math.Sqrt(prime);
					  for (int i = 3; i <= root; i += 2)
					  {
						  if (prime % i == 0)
                          {
                              continue;
                          }
                      }
                      Console.WriteLine($"[Is Prime]{prime}");
                  }
              }
              );
            thread.Start();

			//Promises/Futures/Tasks
            //Wenn ich schnelle/billige Dinge machen will dann verwende ich Tasks
            //Wenn ich eine lange/komplexe Berechnung habe sollte man Threads verwenden
			var task = new Task(
				() =>
			  {
				  var i = 0;
				  while (true)
				  {
					  Console.WriteLine($"[Task]{i++}");
					  Thread.Sleep((1000));
				  }
			  }
			  );
			task.Start(); 


		}



    }
}
