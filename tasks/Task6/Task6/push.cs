using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task6
{
    public static class Push
    {
        public static void Run()
        {
            //Array das Objekte beider Klassen enthält
            var personen = ArrayCreator.CreateGemischtesArray();


            //Getrennte Methoden da es mir nicht möglich war ;-)
            //Methode für Mitarbeiter
            RunMitarbeiter(personen);
            Continue();

            //Methode für Kunden
            RunKunden(personen);
            Continue();
        }

        private static void Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void RunMitarbeiter(IEnumerable<Person> personen)
        {
            Console.WriteLine("Mitarbeiter geboren im Jahr 1970 oder später:");

            var subject = new Subject<Person>();
            
           
            subject.Subscribe(m =>
            {
                Console.WriteLine();
                Console.WriteLine(m.BuildString());
                Thread.Sleep(1000);
            });


            //Mitarbeiter aus Array hereausfiltern mittels Linq
            var mitarbeiter = personen.Where(person =>
              {

                  //besser als typeof da im Fehlerfall etwas zurückgeliefert wird
                  //emp enthält jetzt ausschließlich Mitarbeiter vom Typ Mitarbeiter
                  var emp = person as Mitarbeiter;

                  //Filter auf Geburtsjahr 1970
                  return emp != null && emp?.Gebturtsdatum.Year >= 1970;
              });

            //publishing
            foreach (var ma in mitarbeiter)
            {
                
                subject.OnNext(ma);
            }

            //dispose aufrufen für unsubscribe und resourcen freigeben 
            subject.Dispose();
        }

        private static void RunKunden(IEnumerable<Person> personen)
        {
            Console.WriteLine("Kunden:");

            var subject = new Subject<Person>();

            //Subscribe kombiniert mit hereausfiltern der Kunden mittels Linq
            subject.Where(person =>
            {
                var ku = person as Kunde;

                return ku != null;
            }).Subscribe(k =>
            {
                Console.WriteLine();
                Console.WriteLine(k.BuildString());
                Thread.Sleep(1000);
            });

            //publishing
            foreach (var person in personen)
            {
                subject.OnNext(person);
            }

            //dispose aufrufen für unsubscribe und resourcen freigeben 
            subject.Dispose();
        }

    }
}
