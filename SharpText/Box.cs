using System;

namespace SharpText {
    /// <summary>
    ///     Box of text.
    /// </summary>
    public class Box {
        public Pixel[,] Grid;

        public Vector Size;

        public Box(Vector size) {
            Size = size;
            Grid = new Pixel[size.X, size.Y];
        }

        public Box(int x, int y) {
            Size = new Vector(x, y);
            Grid = new Pixel[x, y];
        }

        public Pixel this[int x, int y] {
            get {
                if (x < 0) x += Size.X;
                if (y < 0) y += Size.Y;
                return Grid[x, y];
            }
            set { Grid[x, y] = value; }
        }

        public void AddBox(Box box, Vector offset) {
            if (((offset.X + box.Size.X) > Size.X) || ((offset.Y + box.Size.Y) > Size.Y)) {
                Size = offset + box.Size;
                Resize(Size);
            }

            for (int x = 0; x < box.Grid.GetLength(0); x++)
                for (int y = 0; y < box.Grid.GetLength(1); y++)
                    Grid[x + offset.X, y + offset.Y] = box.Grid[x, y];
        }

        private void Resize(Vector newSize) {
            if ((newSize.X < Size.X) || (newSize.Y < Size.Y)) throw new Exception("Cannot make a box smaller");

            Pixel[,] newGrid = new Pixel[newSize.X, newSize.Y];

            Array.Copy(Grid, newGrid, Grid.Length);

            Grid = newGrid;
        }
    }
}