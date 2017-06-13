using System;

namespace Task5
{
    public class Game : IPosten
    {
        private string titel;
        private int erscheinungsjahr;
        private decimal preis;

        public Game(string titel, Konsole ksystem, int erscheinungsjahr, decimal preis) // Constructor
        {
            Titel = titel;
            KSystem = ksystem;
            Erscheinungsjahr = erscheinungsjahr;
            Preis = preis;
        }
        public string Titel //property
        {
            get => titel;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel darf nicht leer sein");
                titel = value;
            }
        }
        public Konsole KSystem   //property  
        {
            get;
            set;
        }

        public int Erscheinungsjahr //property
        {
            get => erscheinungsjahr;
            set
            {
                if (value <= 1970 || DateTime.Now.Year < value) throw new ArgumentException("Titel darf nicht leer sein");
                erscheinungsjahr = value;
            }
        }
        public decimal Preis  //property
        {
            get => preis;
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
            Console.WriteLine("Game\n\nTitel: " + Titel + "\nSystem: " + KSystem.BuildString + "\nErscheinungsjahr: " + Erscheinungsjahr + "\nPreis: " + Preis + "\n\n");
            Console.ReadKey();
        }
        public string BuildString
        {
            get
            {
                return "Game\nTitel: " + Titel + "\nSystem: " + KSystem + "\nRelease: " + Erscheinungsjahr + "\nPreis: " + Preis + " Euro";
            }
        }
    }
}
