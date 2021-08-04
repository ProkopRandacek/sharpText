using System;
using System.Drawing;
using SharpText;
using SharpText.UI;

namespace testing {
    internal class Program {
        private static void Main(string[] args) {
            Window w = SharpText.SharpText.ConsoleWindow();
            w.Root = new BorderedBox(new Vector(60, 60), new Vector(60, 0), type: Border.Normal, title: "Root box");
            
            //w.Root.AddChild(new BorderedBox(new Vector(20, 20), new Vector(0, 0), type: Border.Round, title: "This title it too long so it will be cropped"));
            //w.Root.AddChild(new BorderedBox(new Vector(20, 20), new Vector(0, 20), type: Border.Ascii, title: "Ascii box!"));
            w.Root.AddChild(new BigText(new Vector(0, 0), new Vector(10, 4), Color.Blue, Color.Aqua, "SHARPTEXT"));

            
            w.Draw();
            Console.ReadKey();
        }
    }
}