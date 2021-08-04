using System;
using System.Drawing;

namespace SharpText.UI {
    public class ColoredBox : Element {
        private Box    _box;
        private Vector _size;

        public Color Bg;
        public Color Fg;

        public ColoredBox(Vector offset, Vector size, Color bg, Color fg) : base(offset) {
            if ((offset.X < 0) || (offset.Y < 0)) throw new ArgumentException("Offset must be positive");
            if ((size.X <= 0) || (size.Y <= 0)) throw new ArgumentException("Size must be bigger that 1");
            Bg     = bg;
            Fg     = fg;
            Size   = size;
            Offset = offset;
        }

        public virtual Vector Size {
            get { return _size; }
            set {
                _size = value;
                RefreshBox();
            }
        }

        public override Box DrawMe() {
            return _box;
        }

        private void RefreshBox() {
            _box = new Box(Size);
            for (int x = 0; x < _box.Width; x++)
                for (int y = 0; y < _box.Height; y++)
                    _box[x, y] = new Pixel(bg: Bg);
        }
    }
}