using System;
using System.Drawing;
using SharpText.Fonts;

namespace SharpText.UI {
    [Flags]
    public enum Centering {
        Up     = 1,
        Right  = 2,
        Down   = 4,
        Left   = 8,
        Center = 16
    }

    public class BigText : ColoredBox {
        private readonly Vector _fontSize;
        private          Vector _fontOffset;
        private          string _text;

        public BigText(Vector size, Vector offset, Color bg, Color fg, string text) : base(offset, size, bg, fg) {
            _fontSize   = new Vector(3, 4);
            _fontOffset = new Vector(0, 0);

            Offset = offset;
            Size   = size;
            Bg     = bg;
            Fg     = fg;
            Text   = text;
        }

        public string Text {
            get { return _text; }
            set {
                _text = (value.Length * (_fontSize.X + 1)) > Size.X
                    ? value[.. (Size.X / (_fontSize.X + 1))]
                    : value;
            }
        }

        public override Vector Size {
            set {
                if (value.Y < _fontSize.Y) throw new Exception("BigText height cannot be smaller that the font height");
                base.Size = value;
            }
            get { return base.Size; }
        }

        public override Box DrawMe() {
            Box box = new(Size);

            for (int i = 0; i < _text.Length; i++) {
                Box letter = LineFont.GetLetter(Bg, Fg, _text[i]);
                box.AddBox(letter, new Vector((_fontSize.X + 1) * i, 0) + _fontOffset);
            }

            box.SetColors(Bg, Fg);

            return box;
        }

        public void Center(Centering c) {
            Vector s = new(Text.Length * (_fontSize.X + 1), _fontSize.Y);

            if ((c & Centering.Center) > 0) {
                _fontOffset.Y = (Size.Y - s.Y) / 2;
                _fontOffset.X = (Size.X - s.X) / 2;
            }

            if ((c & Centering.Up) > 0) _fontOffset.Y    = 0;
            if ((c & Centering.Left) > 0) _fontOffset.X  = 0;
            if ((c & Centering.Right) > 0) _fontOffset.X = (Size.X - s.X) + 1;
            if ((c & Centering.Down) > 0) _fontOffset.Y  = Size.Y - s.Y;
        }
    }
}