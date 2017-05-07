using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Game
    {
        private string titel;
        private string system;
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
            get { return titel;}
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel darf nicht leer sein");
                titel = value;
            }
        }
        private string KSytem   //property  
        {
            get { return system; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel darf nicht leer sein");
                system = value;
            }
        }
        private int Erscheinungsjahr //property
        {
            get { return erscheinungsjahr; }
            set
            {
                if (value<=1970||DateTime.Now.Year<value) throw new ArgumentException("Titel darf nicht leer sein");
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
            Console.WriteLine("Titel: " + Titel + "\nSystem: " + KSytem + "\nErscheinungsjahr: " + Erscheinungsjahr + "\nPreis: " + Preis+ "\n\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game a = new Game("Pacman", "Atari", 1980, 10);
            Game b = new Game("Space Invaders", "Atari", 1978, 10);
            Game c = new Game("Pong", "Atari", 1972, 10);
            Game d = new Game("Mario Bros", "Atari", 1980, 10);
            int query = 1;
            while (query!=0)
            {
                Console.Write("Was wollen Sie tun?\n\n1) Daten ausgeben\n2) Daten ändern\n0) Beenden\n\nAuswahl: ");
                try { query = int.Parse(Console.ReadLine()); } catch (Exception) { continue; }
                switch (query)
                {
                   
                    case 1:
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        Console.Clear();
                        b.PrintAll();
                        Console.ReadKey();
                        Console.Clear();
                        c.PrintAll();
                        Console.ReadKey();
                        Console.Clear();
                        d.PrintAll();
                        break;
                    case 2: Console.WriteLine("Geben Sie einen neuen Titel für a ein: ");
                        try
                        {
                            a.ChangeName(Console.ReadLine());

                            break;
                        }
                        catch (Exception e) {
                            Console.WriteLine(e);
                            break;
                        }
                        
                    case 0: break;
                    default:    Console.WriteLine("Falsche Eingabe");
                                break;
                }
                
            }
                
                 
        }
    }
}
