using System;
using System.Drawing;
using System.Threading;
using SharpText;
using SharpText.UI;

namespace testing {
    internal class Program {
        private static void Main() {
            Window w = SharpText.SharpText.ConsoleWindow();
            w.Root = new BorderedBox(new Vector(128, 60), new Vector(60, 0), Color.DarkGray, Color.White, Border.Normal,
                                     "Root box");

            BigText bt = new(new Vector(124, 6), new Vector(0, 0), Color.DarkGray, Color.Aqua, "SHARPTEXT");
            bt.Center(Centering.Center);
            BorderedBox bbbt = new(new Vector(126, 8), new Vector(0, 0), Color.DarkGray, Color.White);

            bbbt.AddChild(bt);
            w.Root.AddChild(bbbt);


            w.Draw();
            
            bt.Center(Centering.Up | Centering.Center);
            Thread.Sleep(200);
            w.Draw();
            bt.Center(Centering.Right | Centering.Center);
            Thread.Sleep(200);
            w.Draw();
            bt.Center(Centering.Down | Centering.Center);
            Thread.Sleep(200);
            w.Draw();
            bt.Center(Centering.Left | Centering.Center);
            Thread.Sleep(200);
            w.Draw();
            Console.ReadKey();
        }
    }
}