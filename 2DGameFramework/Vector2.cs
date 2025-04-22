namespace _2DGameFramework
{
    public struct Vector2
    {
        public int x {  get; set; } 
        public int y { get; set; }
        public Vector2() 
        { 
            x = 0; 
            y = 0; 
        }
        public Vector2(int x, int y) 
        { 
            this.x = x; 
            this.y = y; 
        }
        public override string ToString()
        {
            return (x + " : " + y);
        }

        public int LengthSqr() 
        {
            int xSqr = x * x;
            int ySqr = y * y;
            return xSqr + ySqr;
        }
        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return a.x != b.x || a.y != b.y;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        { 
            return new Vector2(a.x + b.x, a.y + b.y); 
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, int b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator /(Vector2 a, int b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
    }
}
