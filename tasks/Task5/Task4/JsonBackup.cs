using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Task5
{
    class JsonBackup
    {
        public static void store(IPosten[] obj,string filename)
        {
            //Json Settings definieren. Typen automatisch aus Klasse übernehmen
            var backupSettings = new JsonSerializerSettings() {Formatting=Formatting.Indented, TypeNameHandling=TypeNameHandling.Auto};
            //Backupstring erstellen -> in Json Format
            var backupString = JsonConvert.SerializeObject(obj, backupSettings);
            //Festlegen des Zielordners
            var backuplocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //.json zu filenamen hinzufügen und Backuppfad zusammensetzen
            var backuppath = Path.Combine(backuplocation, filename + ".json");
            if (File.Exists(backuppath)) throw new Exception("Datei existiert bereits " + backuppath);
            //in json File schrieben
            File.WriteAllText(backuppath, backupString);
            //Console.WriteLine("Objekte gesichert unter: "+backuppath);
            //Console.ReadKey();
        }
        public static IPosten[] restore_stored_json(string name)
        {
            //Festlegen des Quellordners
            var filelocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //.json zu Filenamen hinzufügen und Dateipfad zusammensetzen
            var filepath = Path.Combine(filelocation, name + ".json");
            //Check ob Dateipfad gültig
            if (!(File.Exists(filepath))) throw new Exception("Datei existiert nicht "+filepath);
            //String aus Datei wiederherstellen
            var restorestring = File.ReadAllText(filepath);
            //Json Settings definieren
            var restoreSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            //Object Array aus Json String wiederherstellen.
            var restoredArray = JsonConvert.DeserializeObject<IPosten[]>(restorestring, restoreSettings);
            //Rückgabe des neuen Arrays
            return restoredArray;   
        }
    }
}
    