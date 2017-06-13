using System;
using System.Globalization;

namespace Task6
{
    class Kunde : Person
    {
        readonly int _plz;
        private int _anzahlEinkaufe;
        private int _umsatz;

        public Kunde(string newVorname, string newNachname, string newGeburtsdatum, int newPlz)
        {
            if (string.IsNullOrEmpty(newVorname)) throw new ArgumentException("Vorname ungueltig");
            if (string.IsNullOrWhiteSpace(newNachname)) throw new ArgumentException(("Nachname ist ungueltig"));
            if (newPlz < 1000 || newPlz > 9999) throw new ArgumentException("PLZ ungueltig");
            string[] formats = {"d/M/yyyy", "d/M/yyyy",
                "dd/MM/yyyy", "d/M/yyyy",
                "d/M/yyyy", "d/M/yyyy",
                "d/M/yyyy", "d/M/yyyy",
                "dd/MM/yyyy", "dd/M/yyyy"};
            DateTime value;
            if (DateTime.TryParseExact(newGeburtsdatum, formats,
                new CultureInfo("de-AT"),
                DateTimeStyles.None,
                out value))
            {
                Gebturtsdatum = value;
            }
            else
            {
                throw new ArgumentException("Datum ungültig");
            }
            Vorname = newVorname;
            Nachname = newNachname;
            _plz = newPlz;

        }

        public void AddEinkauf()
        {
            _anzahlEinkaufe++;
        }

        public void AddUmsatz(int umsatztoadd)
        {
            _umsatz += umsatztoadd;
        }
        public override string BuildString()
        {
            return $"{VollerName}\nGeb: {Gebturtsdatum:dd.MM.yyyy}\nPLZ: {_plz}\nAnzahl der Einkäufe: {_anzahlEinkaufe}\nUmsatz: {_umsatz}";
        }
    }
}
