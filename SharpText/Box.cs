using System;
using System.Drawing;

namespace SharpText {
    /// <summary>
    ///     Box of text.
    /// </summary>
    public class Box {
        private Pixel[,] _grid;

        public Box(Vector size) {
            _grid = new Pixel[size.X, size.Y];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    _grid[x, y] = new Pixel();
        }

        public Box(int x, int y) {
            _grid = new Pixel[x, y];
        }

        public int Height {
            get { return _grid.GetLength(1); }
        }

        public int Width {
            get { return _grid.GetLength(0); }
        }

        public Vector Size {
            get { return new Vector(Width, Height); }
        }

        public Pixel this[int x, int y] {
            get {
                if (x < 0) x += Width;
                if (y < 0) y += Height;
                return _grid[x, y];
            }
            set { _grid[x, y] = value; }
        }

        public void AddBox(Box box, Vector offset) {
            if ((offset.X + box.Width) > Width)
                Resize(new Vector(offset.X + box.Width, Height));
            if ((offset.Y + box.Height) > Height)
                Resize(new Vector(Width, offset.Y + box.Height));

            for (int x = 0; x < box.Width; x++)
                for (int y = 0; y < box.Height; y++)
                    _grid[x + offset.X, y + offset.Y] = box._grid[x, y];
        }

        public void SetColors(Color bg, Color fg) {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++) {
                    this[x, y].Bg = bg;
                    this[x, y].Fg = fg;
                }
        }

        private void Resize(Vector newSize) {
            if ((newSize.X < Width) || (newSize.Y < Height)) throw new Exception("Cannot make a box smaller");

            Pixel[,] newGrid = new Pixel[newSize.X, newSize.Y];

            Array.Copy(_grid, newGrid, _grid.Length);

            _grid = newGrid;

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    this[x, y] ??= new Pixel();
        }
    }
}