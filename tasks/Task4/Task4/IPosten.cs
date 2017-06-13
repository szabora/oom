using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    interface IPosten
    {
        void PrintAll();
        string BuildString { get; }

        /*interface Methode -> bildet Vorlage
         In interfaces kann man keine Felder deklarieren. Für diese Anwendung wird eine abstract Class benötigt.
         Jede Klasse die von diesem Interface erbt muss alle definierten Methoden ebenfalls implementiert haben
         Scheint so als müßte die Signatur ebenfalls die gleiche sein?!*/
    }
}
