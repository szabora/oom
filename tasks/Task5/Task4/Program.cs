using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Object Array hinzugefügt
//interface Methode
//zweite Klasse "Konsole" hinzugefügt
//Tests hinzugefügt
//BuildString hinzugefügt.
//Json Backup Class hinzugefügt
//Klassen in Files unterteilt


namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new IPosten[] //ein Array aus der Mutter Klasse kann alle Subclass Objekte fassen.
            {
                new Konsole("Playstation", "Sony", 329),
                new Konsole("2600", "Atari", 499),
                new Konsole("Mega Drive", "Sega", 229),
                new Konsole("NES", "Nintendo", 229),
                new Game("Pacman", new Konsole("2600", "Atari", 499), 1980, 10),
                new Game("Space Invaders", new Konsole("2600", "Atari", 499), 1978, 10),
                new Game("Pong", new Konsole("2600", "Atari", 499), 1972, 10),
                new Game("Mario Bros", new Konsole("NES", "Nintendo", 229), 1980, 10),
            };
            var array2 = new IPosten[] //ein Array aus der Mutter Klasse kann alle Subclass Objekte fassen.
            {
                new Game("Pacman", (Konsole)array[1], 1980, 10),
                new Game("Space Invaders", (Konsole)array[1], 1978, 10),
                new Game("Pong", (Konsole)array[1], 1972, 10),
                new Game("Mario Bros",(Konsole)array[3], 1980, 10),
            };
            Game a = new Game("Metroid", new Konsole("NES", "Nintendo", 229), 1990, 19);
            int query = 1;
            while (query != 0)
            {
                Console.Clear();
                Console.Write("Was wollen Sie tun?\n\n1) Daten ausgeben\n2) Daten ändern\n3) Objekt speichern\n4) Objekte laden\n0) Beenden\n\nAuswahl: ");
                try { query = int.Parse(Console.ReadLine()); } catch (Exception) { continue; }
                switch (query)
                {

                    case 1:
                        foreach (var item in array) { item.PrintAll(); };
                        Console.WriteLine("\nArray2:");
                        foreach (var item in array2) { item.PrintAll(); };
                        break;
                    case 2:
                        Console.WriteLine("Geben Sie einen neuen Titel für a ein: ");
                        try
                        {
                            a.ChangeName(Console.ReadLine());
                            a.PrintAll();
                            Console.WriteLine(a.BuildString);

                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            break;
                        }
                    case 3:
                        {
                            var arraytostore = new IPosten[] //ein Array aus der Mutter Klasse kann alle Subclass Objekte fassen.
                            {
                                new Konsole("Mega Drive", "Sega", 229),
                                new Game("Pacman", new Konsole("2600", "Atari", 499), 1980, 10),
                            };
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Dateinamen eingeben: ");
                                JsonBackup.store(arraytostore, Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Namen der zu ladenden Datei eingeben: ");
                            try
                            {
                                var restored = JsonBackup.restore_stored_json(Console.ReadLine());
                                Console.Clear();
                                foreach (var item in restored) { item.PrintAll(); }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 0: break;
                    default:
                        Console.WriteLine("Falsche Eingabe");
                        break;
                }

            }


        }
    }
}
