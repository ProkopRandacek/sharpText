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

        public static bool operator ==(Pixel a, Pixel b) {
            return b is not null && a is not null && (a.Bg == b.Bg) && (a.Fg == b.Fg) && (a.C == b.C);
        }

        public static bool operator !=(Pixel a, Pixel b) {
            return !(a == b);
        }
    }
}