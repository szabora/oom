using System;

namespace Task6
{
    class Program
    {
        private static void Main(string[] args)
        {
            var kunden = ArrayCreator.CreateKundenArray();
            var mitarbeiter = ArrayCreator.CreateMitarbeiterArray();
            var gemischt = ArrayCreator.CreateGemischtesArray();
            foreach (var x in kunden) Console.WriteLine($"{x.BuildString()}\n\n");
            foreach (var x in mitarbeiter) Console.WriteLine($"{x.BuildString()}\n\n");
            foreach (var x in gemischt) Console.WriteLine($"{x.BuildString()}\n\n");
            //var showDialog = Prompt.ShowDialog("Test", "123");
            Pusher.Run();
        }
    }
}
