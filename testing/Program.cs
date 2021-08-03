using System;
using System.Drawing;
using SharpText.UI;
using Vector = SharpText.Vector;

namespace testing {
    internal class Program {
        private static void Main(string[] args) {
            Window w = SharpText.SharpText.ConsoleWindow();
            w.Root = new BorderedBox(new Vector(0, 0), new Vector(60, 60), Color.Black, Color.White, Border.Normal);
            w.Root.Children.Add(new BorderedBox(new Vector(1, 1), new Vector(20, 20), Color.Black, Color.White, Border.Round));
            w.Root.Children.Add(new BorderedBox(new Vector(1, 21), new Vector(20, 20), Color.Black, Color.White, Border.Ascii));
            w.Root.Children.Add(new BorderedBox(new Vector(21, 1), new Vector(20, 20), Color.Black, Color.White, Border.Double));

            w.Draw();
            Console.ReadKey();
        }
    }
}