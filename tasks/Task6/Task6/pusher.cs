using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task6
{
    public static class Pusher
    {
        public static void Run()
        {
            var array = ArrayCreator.CreateGemischtesArray();

            /*var list = new List<Person>()
            {
                new Mitarbeiter("Sepp", "Zimmer", "22/5/1987", "HR", "Verrechner"),
                new Mitarbeiter("Juergen", "Freiwild", "12/7/1999", "Lager", "Spediteur"),
                new Mitarbeiter("Christian", "Sost", "3/7/1960", "Einkauf", "Besteller"),
                new Mitarbeiter("Thomas", "Planner", "8/3/1950", "Empfang", "Portier"),
                new Kunde("Herbert", "Huber", "2/12/1988", 2020),
                new Kunde("Jimmy", "Fallon", "02/5/1999", 1010),
                new Kunde("Franz", "Fuerst", "30/08/1966", 5454),
                new Kunde("Georg", "Dundee", "12/9/2000", 3223)
            };*/

            var source = new Subject<Person>();

            Console.WriteLine("Personen");
            source.Subscribe(x =>
            {
                Console.WriteLine(x.BuildString());
                Thread.Sleep(250);

            });

            var filter = from x in array
                where x.Gebturtsdatum.Year >= 1999 && (x.GetType() == typeof(Mitarbeiter))
                select x;

            foreach (var count in filter)
            {
                array.OnNext(count);
            }

            var source2 = array.Where(y => y.GetType() == typeof(Kunde)).ToObservable();
            Console.WriteLine("Kunden in Array:");
            source2.Subscribe(y =>
                {
                    Console.WriteLine(y.BuildString());
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
            );
            
        }
    }
}
