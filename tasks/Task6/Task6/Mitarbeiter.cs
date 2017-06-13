using System;
using System.Globalization;

namespace Task6
{
    class Mitarbeiter:Person
    {
        readonly string _abteilung;
        readonly string _posten;
        private DateTime _eintrittsdatum;
        private int Zugehoerigkeit => DateTime.Now.Year - _eintrittsdatum.Year;

        public Mitarbeiter(string newVorname, string newNachname, string newGeburtstag, string newAbteilung, string newPosten)
        {
            if (string.IsNullOrEmpty(newVorname)) throw new ArgumentException("Vorname ungueltig");
            if (string.IsNullOrWhiteSpace(newNachname)) throw new ArgumentException(("Nachname ist ungueltig"));
            if (string.IsNullOrWhiteSpace(newAbteilung)) throw new ArgumentException(("Abteilungsname ist ungueltig"));
            if (string.IsNullOrWhiteSpace(newPosten)) throw new ArgumentException(("Postenname ist ungueltig"));
            Vorname = newVorname;
            Nachname = newNachname;
            _eintrittsdatum = DateTime.Now;
            _posten = newPosten;
            _abteilung = newAbteilung;
            string[] formats = {"d/M/yyyy", "d/M/yyyy",
                "dd/MM/yyyy", "d/M/yyyy",
                "d/M/yyyy", "d/M/yyyy",
                "d/M/yyyy", "d/M/yyyy",
                "dd/MM/yyyy", "dd/M/yyyy"};
            DateTime value;
            if (DateTime.TryParseExact(newGeburtstag, formats,
                new CultureInfo("de-AT"),
                DateTimeStyles.None,
                out value))
            {
                if (DateTime.Now.Year <= (Gebturtsdatum.Year + 16))
                {
                    throw new ArgumentException("Ungueltiges Geburtsdatum oder Kinderarbeit");
                }

                Gebturtsdatum = value;
            }
            else
            {
                throw new ArgumentException("Datum ungültig");
            }
        }

        public override string BuildString()
        {
            return $"{VollerName}\nGeb: {Gebturtsdatum:dd.MM.yyyy}\nAbteilung: {_abteilung}\nPosten: {_posten}\nEintrittsdatum: {_eintrittsdatum:dd.MM.yyyy}";
        }
    }
}
