using System.Drawing;

namespace SharpText {
    public interface IScreen {
        public int Height { get; }
        public int Width  { get; }

        public void Init();
        public void SetPixel(Color bg, Color fg, Vector pos, char c);
        public void Clear();
    }
}