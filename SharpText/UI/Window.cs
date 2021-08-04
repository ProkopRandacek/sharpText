namespace SharpText.UI {
    public class Window {
        private Box     _prevDraw = new(0, 0);
        public  Element Root;
        public  IScreen Screen;

        public Window(IScreen screen) {
            Screen = screen;
            Screen.Init();
        }

        public int Width {
            get { return Screen.Width; }
        }

        public int Height {
            get { return Screen.Height; }
        }

        public void Draw() {
            Box box = Root.Draw();

            bool diffDraw = _prevDraw.Size == box.Size;

            for (int x = 0; x < box.Width; x++)
                for (int y = 0; y < box.Height; y++) {
                    Pixel p = box[x, y];
                    if (diffDraw && (p == _prevDraw[x, y]))
                        continue; // dont redraw pixels that didnt change from last time
                    Screen.SetPixel(p.Bg, p.Fg, new Vector(x, y), p.C);
                }

            _prevDraw = box;
        }
    }
}