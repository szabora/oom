using System;

namespace Task6
{
    abstract class Person:IPerson
    {
        public string Vorname;
        public string Nachname;
        public DateTime Gebturtsdatum;

        public string VollerName => $"{Vorname} {Nachname}";
        public abstract string BuildString();
    }

    interface IPerson
    {
        string BuildString();
    }
}
