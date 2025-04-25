namespace _2DGameFramework
{
    public struct Vector2
    {
        public int x {  get; set; } 
        public int y { get; set; }
        /// <summary>
        /// Sets x and y to 0
        /// </summary>
        public Vector2() 
        { 
            x = 0; 
            y = 0; 
        }
        /// <summary>
        /// Sets this.x to x, and this.y to y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(int x, int y) 
        { 
            this.x = x; 
            this.y = y; 
        }
        /// <summary>
        /// Returns "x : y"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (x + " : " + y);
        }
        /// <summary>
        /// Returns the length of this vector squared
        /// </summary>
        /// <returns></returns>
        public int LengthSqr() 
        {
            int xSqr = x * x;
            int ySqr = y * y;
            return xSqr + ySqr;
        }
        /// <summary>
        /// Returns a.x==bx and a.y==b.y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }
        /// <summary>
        /// Returns a.x != bx or a.y != b.y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return a.x != b.x || a.y != b.y;
        }
        /// <summary>
        /// Returns a new vector with x = a.x + b.x and y = a.y + b.y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new vector with x = a.x + b.x and y = a.y + b.y</returns>
        public static Vector2 operator +(Vector2 a, Vector2 b)
        { 
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        /// <summary>
        /// Returns a new vector with x = a.x - b.x and y = a.y - b.y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new vector with x = a.x - b.x and y = a.y - b.y</returns>
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        /// <summary>
        /// Returns a new vector with x = a.x * b.x and y = a.y * b.y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new vector with x = a.x * b.x and y = a.y * b.y</returns>
        public static Vector2 operator *(Vector2 a, int b)
        {
            return new Vector2(a.x * b, a.y * b);
        }

        /// <summary>
        /// Returns a new vector with x = a.x / b.x and y = a.y / b.y
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new vector with x = a.x / b.x and y = a.y / b.y</returns>
        public static Vector2 operator /(Vector2 a, int b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
    }
}
