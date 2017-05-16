using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Object Array hinzugefügt
//interface Methode
//zweite Klasse "Konsole" hinzugefügt

namespace Task3
{
    public interface Posten
    {
        void PrintAll(); 
        
        /*interface Methode -> bildet Vorlage
         In interfaces kann man keine Felder deklarieren. Für diese Anwendung wird eine abstract Class benötigt.
         Jede Klasse die von diesem Interface erbt muss alle definierten Methoden ebenfalls implementiert haben
         Scheint so als müßte die Signatur ebenfalls die gleiche sein?!*/
                           
    }
    public class Game:Posten
    {
        private string titel;
        private string Ksystem;
        private int erscheinungsjahr;
        private decimal preis;

        public Game(string newTitel, string newSystem, int newErscheinungsjahr, decimal newPreis) // Constructor
        {
            Titel = newTitel;
            KSytem = newSystem;
            Erscheinungsjahr = newErscheinungsjahr;
            Preis = newPreis;
        }
        private string Titel //property
        {
            get { return titel; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel darf nicht leer sein");
                titel = value;
            }
        }
        private string KSytem   //property  
        {
            get { return Ksystem; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel darf nicht leer sein");
                Ksystem = value;
            }
        }
        private int Erscheinungsjahr //property
        {
            get { return erscheinungsjahr; }
            set
            {
                if (value <= 1970 || DateTime.Now.Year < value) throw new ArgumentException("Titel darf nicht leer sein");
                erscheinungsjahr = value;
            }
        }
        private decimal Preis  //property
        {
            get { return preis; }
            set
            {
                if (value <= 0) throw new ArgumentException("Ungültiger Preis");
                preis = value;
            }
        }
        public void ChangeName(string newTitle)
        {
            Titel = newTitle;
        }

        public void PrintAll()
        {
            Console.WriteLine("Game\n\nTitel: " + Titel + "\nSystem: " + KSytem + "\nErscheinungsjahr: " + Erscheinungsjahr + "\nPreis: " + Preis + "\n\n");
            Console.ReadKey();
        }
    }
    public class Konsole:Posten
    {
        private string name;
        private string hersteller;
        private decimal preis;
        public Konsole(string newName, string newHersteller, decimal newPreis)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("ungültiger Name");
            if (string.IsNullOrWhiteSpace(newHersteller)) throw new ArgumentException("ungültiger Hersteller");
            if (preis<0) throw new ArgumentException("OH NO");
            name = newName;
            hersteller = newHersteller;
            preis = newPreis;
        }
        public void PrintAll() {
            Console.WriteLine("Konsole\n\nName:" + name + "\nHersteller: " + hersteller + "\nPreis: " + preis+"\n\n");
            Console.ReadLine();
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            var array = new Posten[] //ein Array aus der Mutter Klasse kann alle Subclass Objekte fassen.
            {
                new Konsole("Playstation", "Sony", 329),
                new Konsole("2600", "Atari", 499),
                new Konsole("Mega Drive", "Sega", 229),
                new Konsole("NES", "Nintendo", 229),
                new Game("Pacman", "Atari", 1980, 10),
                new Game("Space Invaders", "Atari", 1978, 10),
                new Game("Pong", "Atari", 1972, 10),
                new Game("Mario Bros", "Atari", 1980, 10),
            };
            Game a = new Game("Metroid", "Nintendo", 1990, 19);
            int query = 1;
        while (query != 0)
        {
            Console.Write("Was wollen Sie tun?\n\n1) Daten ausgeben\n2) Daten ändern\n0) Beenden\n\nAuswahl: ");
                try { query = int.Parse(Console.ReadLine()); } catch (Exception) { continue; }
                switch (query)
                {

                    case 1:
                        foreach(var item in array) { item.PrintAll(); };
                    break;
                    case 2:
                        Console.WriteLine("Geben Sie einen neuen Titel für a ein: ");
                        try
                        {
                            a.ChangeName(Console.ReadLine());
                            a.PrintAll();
                            
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
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
