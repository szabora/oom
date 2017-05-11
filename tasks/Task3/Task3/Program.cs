using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface hardware
    {
        
        void print();
    }
    class telefon:hardware
    {
        private static int anzahl;
        private string hersteller;
        private string type;
        public telefon(string newHersteller, string newType)
        {
            if (string.IsNullOrWhiteSpace(newHersteller))throw new ArgumentException("Name ungültig");
            if (string.IsNullOrWhiteSpace(newType)) throw new ArgumentException("Name ungültig");
            hersteller = newHersteller;
            type = newType;
            anzahl++;

        }
        public void print()
        {
            Console.WriteLine("");
        }
    }
    //   class pc:hardware { }
    //  class bildschirm:hardware { }

    class Program
    {
        static void Main(string[] args)
        {
          //public telefon[] = new telefon;
        }
    }
}
