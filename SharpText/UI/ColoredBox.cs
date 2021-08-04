using System.Drawing;

namespace SharpText.UI {
    public class ColoredBox : Element {
        private Box    _box;
        private Vector _size;

        public Color Bg;
        public Color Fg;

        public ColoredBox(Vector offset, Vector size, Color bg, Color fg) : base(offset) {
            Bg               = bg;
            Fg               = fg;
            Size             = size;
            Offset = offset;
        }

        public Vector Size {
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
            for (int x = 0; x < _box.Grid.GetLength(0); x++)
                for (int y = 0; y < _box.Grid.GetLength(1); y++)
                    _box.Grid[x, y] = new Pixel(bg: Bg);
        }
    }
}