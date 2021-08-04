using System;
using System.Drawing;
using SharpText.Fonts;

namespace SharpText.UI {
    public class BigText : ColoredBox {
        private string _text;

        private Vector _fontSize;

        public string Text {
            get { return _text; }
            set {
                _text = (value.Length * (_fontSize.X + 1)) > Size.X
                    ? value[.. (Size.X / _fontSize.X)]
                    : value;
            }
        }

        public override Vector Size {
            set {
                if (value.Y < _fontSize.Y) throw new Exception("BigText height cannot be smaller that the font height");
                base.Size = value;
            } get {
                return base.Size;
            }
        }

        public BigText(Vector offset, Vector size, Color bg, Color fg, string text) : base(offset, size, bg, fg) {
            Offset    = offset;
            Size      = size;
            Bg        = bg;
            Fg        = fg;
            Text      = text;
            _fontSize = new Vector(3, 4);
        }

        public override Box DrawMe() {
            Box box = new(Size);
            
            for (int i = 0; i < _text.Length; i++) {
                Box letter = LineFont.GetLetter(Bg, Fg, _text[i]);
                box.AddBox(letter, new Vector((_fontSize.X + 1) * i, 0));
            }
            
            box.SetColors(Bg, Fg);

            return box;
        }
    }
}