using System;

namespace Task6
{
    class ArrayCreator
    {
        public static Person[] CreateKundenArray()
        {
            return new Person[]
            {
                new Kunde("Herbert", "Huber","2/12/1988",2020),
                new Kunde("Jimmy", "Fallon","02/5/1999", 1010),
                new Kunde("Franz", "Fuerst","30/08/1966", 5454),
                new Kunde("Georg", "Dundee","12/9/2000", 3223)
            };
        }
        public static Person[] CreateMitarbeiterArray()
        {
            return new Person[]
            {
                new Mitarbeiter("Sepp", "Zimmer", "22/5/1987", "HR","Verrechner" ),
                new Mitarbeiter("Juergen", "Freiwild", "12/7/1999","Lager","Spediteur"),
                new Mitarbeiter("Christian", "Sost", "3/7/1960","Einkauf","Besteller"),
                new Mitarbeiter("Thomas", "Planner", "8/3/1950","Empfang","Portier")
            };
        }

        public static Person[] CreateGemischtesArray()
        {
            var tempKundenArray = CreateKundenArray();
            var tempMitarbeiterArray = CreateMitarbeiterArray();
            var gemischt = new Person[tempKundenArray.Length + tempMitarbeiterArray.Length];
            Array.Copy(tempKundenArray, gemischt, tempKundenArray.Length);
            Array.Copy(tempMitarbeiterArray, 0, gemischt, tempKundenArray.Length, tempMitarbeiterArray.Length);
            return gemischt;
        }
    }
}
