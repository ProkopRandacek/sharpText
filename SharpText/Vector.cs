namespace SharpText {
    public struct Vector {
        public int X, Y;

        public Vector(int x, int y) {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
    }
}