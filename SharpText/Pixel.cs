using System.Drawing;

namespace SharpText {
    public class Pixel {
        public Color Bg;
        public char  C;
        public Color Fg;

        public Pixel(char c = ' ', Color fg = default, Color bg = default) {
            if (fg == default) fg = Color.White;
            if (bg == default) bg = Color.Black;

            C  = c;
            Fg = fg;
            Bg = bg;
        }
    }
}