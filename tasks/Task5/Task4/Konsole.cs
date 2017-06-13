using System;

namespace Task5
{
    public class Konsole : IPosten
    {
        private string name;
        private string hersteller;
        private decimal preis;
        public Konsole(string Name, string Hersteller, decimal Preis)
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("ungültiger Name");
            if (string.IsNullOrWhiteSpace(Hersteller)) throw new ArgumentException("ungültiger Hersteller");
            if (Preis < 0) throw new ArgumentException("OH NO");
            name = Name;
            hersteller = Hersteller;
            preis = Preis;
        }
        public string Name { get => name; }
        public string Hersteller { get => hersteller; }
        public decimal Preis { get => preis; }
        public void PrintAll()
        {
            Console.WriteLine("Konsole\n\nName:" + name + "\nHersteller: " + hersteller + "\nPreis: " + preis + "\n\n");
            Console.ReadLine();
        }
        public string BuildString
        {
            get
            {
                return "Konsole\nName: " + name + "\nHersteller: " + hersteller + "\nPreis: " + Preis + " Euro";
            }
        }
    }
}
