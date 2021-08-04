using System;

namespace SharpText.UI {
    public class Window {
        public Element Root;
        public IScreen Screen;

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

            for (int x = 0; x < box.Width; x++)
                for (int y = 0; y < box.Height; y++) {
                    Pixel p = box[x, y];
                    Screen.SetPixel(p.Bg, p.Fg, new Vector(x, y), p.C);
                }
        }
    }
}