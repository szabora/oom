using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

/*namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test_Game_Konstruktor()
        {
            var a = new Game("Titel", "System", 1999, 99);
            Assert.IsTrue(a.Titel == "Titel");
            Assert.IsTrue(a.KSystem == "System");
            Assert.IsTrue(a.Erscheinungsjahr == 1999);
            Assert.IsTrue(a.Preis == 99);
        }
        [Test]
        public void Test_Konsole_Konstruktor()
        {
            var b = new Konsole("Titel", "System", 99);
            Assert.IsTrue(b.Name == "Titel");
            Assert.IsTrue(b.Hersteller == "System");
            Assert.IsTrue(b.Preis == 99);
        }
        [Test]
        public void Test_Konsole_Konstruktor_noTitle()
        {
            Assert.Catch(() => { var c = new Konsole(null, "System", 1999); });
            Assert.Catch(() => { var d = new Konsole("Titel", null, 1999); });
            Assert.Catch(() => { var e = new Konsole("Titel", "System", -1); });

        }
        [Test]
        public void Test_Game_Konstruktor_noTitle()
        {
            Assert.Catch(() => { var f = new Game(null, "System", 1999, 99); });
            Assert.Catch(() => { var g = new Game("Titel", null, 1999, 99); });
            Assert.Catch(() => { var g = new Game("Titel", "System", 2099, 99); });
            Assert.Catch(() => { var g = new Game("Titel", "System", 2018, -1); });
        }
        [Test]
        public void Test_Game_ChangeName()
        {
            var f = new Game("Test", "System", 1999, 99);
            f.ChangeName("Changed");
            Assert.IsTrue(f.Titel == "Changed");
        }
        [Test]
        public void Test_StringBuilder_Game()
        {
            var a = new Game("Titel", "System", 1999, 99);
            Assert.IsTrue(a.BuildString== "Game\nTitel: Titel\nSystem: System\nRelease: 1999\nPreis: 99 Euro");
        }
        [Test]
        public void Test_StringBuilder_Konsole()
        {
            var a = new Konsole("Titel", "System", 99);
            Assert.IsTrue(a.BuildString== "Konsole\nName: Titel\nHersteller: System\nPreis: 99 Euro");
        }
        [Test]
        public void Test_Json_Backup()
        {
            var array_to_test_store_method = new IPosten[]
            {
                new Konsole("Mega Drive", "Sega", 229),
            };
            JsonBackup.store(array_to_test_store_method,"testdatei");
            var array_to_test_restore_method = JsonBackup.restore_stored_json("testdatei");
            Assert.IsTrue(array_to_test_store_method[0].BuildString== array_to_test_restore_method[0].BuildString);
            File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "testdatei.json"));
        }
    }
}*/
