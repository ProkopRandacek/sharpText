using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SharpText {
    /// <summary>
    ///     Console to IScreen binding
    /// </summary>
    public class DefaultConsole : IScreen {
        private static bool _created;

        private readonly Dictionary<Color, ConsoleColor> _mapColorToConsoleColor = new() {
            { Color.Black, ConsoleColor.Black },
            { Color.Blue, ConsoleColor.Blue },
            { Color.Cyan, ConsoleColor.Cyan },
            { Color.Gray, ConsoleColor.Gray },
            { Color.Green, ConsoleColor.Green },
            { Color.Magenta, ConsoleColor.Magenta },
            { Color.Red, ConsoleColor.Red },
            { Color.White, ConsoleColor.White },
            { Color.Yellow, ConsoleColor.Yellow },
            { Color.DarkBlue, ConsoleColor.DarkBlue },
            { Color.DarkCyan, ConsoleColor.DarkCyan },
            { Color.DarkGray, ConsoleColor.DarkGray },
            { Color.DarkGreen, ConsoleColor.DarkGreen },
            { Color.DarkMagenta, ConsoleColor.DarkMagenta },
            { Color.DarkRed, ConsoleColor.DarkRed },
            { Color.FromArgb(128, 128, 0), ConsoleColor.DarkYellow }
        };

        public DefaultConsole() {
            if (_created) throw new Exception("There can be only one DefaultConsole");
            _created = true;
        }

        public int Height {
            get { return Console.WindowHeight; }
        }

        public int Width {
            get { return Console.WindowWidth; }
        }

        public void Init() {
            Console.Clear();
            Console.CursorVisible = false;
        }

        public void SetPixel(Color bg, Color fg, Vector pos, char c) {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.BackgroundColor = ColorToConsoleColor(bg);
            Console.ForegroundColor = ColorToConsoleColor(fg);
            Console.Write(c);
            Console.ResetColor();
        }

        public void Clear() {
            Console.Clear();
        }

        private ConsoleColor ColorToConsoleColor(Color inputColor) {
            // Try if the color has a ConsoleColor equivalent
            if (_mapColorToConsoleColor.ContainsKey(inputColor)) return _mapColorToConsoleColor[inputColor];

            // Otherwise find closes color based on the vector distance and return that
            Vector3 ideal = new(inputColor.R, inputColor.G, inputColor.B);

            ConsoleColor bestCc   = ConsoleColor.Black;
            float        bestDist = float.PositiveInfinity;

            foreach ((Color c, ConsoleColor cc) in _mapColorToConsoleColor) {
                Vector3 rgb  = new(c.R, c.G, c.B);
                float   dist = Vector3.Distance(ideal, rgb);

                if (dist < bestDist) {
                    bestCc   = cc;
                    bestDist = dist;
                }
            }

            return bestCc;
        }
    }
}