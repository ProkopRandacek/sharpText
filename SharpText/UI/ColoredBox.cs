using System.Drawing;

namespace SharpText.UI {
    public class ColoredBox: Element {
        private Vector _size;

        public Color Bg;
        
        public Vector Size {
            get { return _size; }
            set {
                _size = value;
                RefreshBox();
            }
        }

        private Box _box;
        
        public ColoredBox(Vector offsetFromParent, Vector size, Color bg) : base(offsetFromParent) {
            Bg               = bg;
            Size             = size;
            OffsetFromParent = offsetFromParent;
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