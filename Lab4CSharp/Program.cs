using System;

namespace Lab4CSharp
{
    public class ATriangle
    {
        protected int a;
        protected int b;
        protected int color;

        public ATriangle(int a, int b, int color)
        {
            this.a = a;
            this.b = b;
            this.color = color;
        }

        public int A
        {
            get { return a; }
            set { if (value > 0) a = value; }
        }

        public int B
        {
            get { return b; }
            set { if (value > 0) b = value; }
        }

        public int Color
        {
            get { return color; }
            set { color = value; }
        }

        public int this[int index]
        {
            get
            {
                if (index == 0) return a;
                if (index == 1) return b;
                if (index == 2) return color;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index == 0)
                {
                    if (value > 0) a = value;
                }
                else if (index == 1)
                {
                    if (value > 0) b = value;
                }
                else if (index == 2)
                {
                    color = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public static ATriangle operator ++(ATriangle t)
        {
            return new ATriangle(t.a + 1, t.b + 1, t.color);
        }

        public static ATriangle operator --(ATriangle t)
        {
            return new ATriangle(t.a - 1, t.b - 1, t.color);
        }

        public static bool operator true(ATriangle t)
        {
            return t.a > 0 && t.b > 0;
        }

        public static bool operator false(ATriangle t)
        {
            return t.a <= 0 || t.b <= 0;
        }

        public static ATriangle operator +(ATriangle t, int scalar)
        {
            return new ATriangle(t.a + scalar, t.b + scalar, t.color);
        }

        public static ATriangle operator +(int scalar, ATriangle t)
        {
            return new ATriangle(t.a + scalar, t.b + scalar, t.color);
        }

        public static implicit operator string(ATriangle t)
        {
            return $"{t.a};{t.b};{t.color}";
        }

        public static explicit operator ATriangle(string str)
        {
            string[] parts = str.Split(';');
            if (parts.Length == 3 &&
                int.TryParse(parts[0], out int a) &&
                int.TryParse(parts[1], out int b) &&
                int.TryParse(parts[2], out int c))
            {
                return new ATriangle(a, b, c);
            }
            throw new ArgumentException();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

  
            ATriangle triangle = new ATriangle(3, 4, 1);

            string triangleString = triangle;
            Console.WriteLine($"Початковий трикутник (через string): {triangleString}");

            Console.WriteLine($"Індексатор [0] (катет a): {triangle[0]}");
            Console.WriteLine($"Індексатор [1] (катет b): {triangle[1]}");
            Console.WriteLine($"Індексатор [2] (колір): {triangle[2]}");

            triangle[0] = 5;
            Console.WriteLine($"Після зміни a через індексатор: {(string)triangle}");

            triangle++;
            Console.WriteLine($"Після операції ++: {(string)triangle}");

            triangle--;
            Console.WriteLine($"Після операції --: {(string)triangle}");

            triangle = triangle + 10;
            Console.WriteLine($"Після додавання скаляра 10: {(string)triangle}");

            if (triangle)
            {
                Console.WriteLine("Трикутник існує.");
            }

            string stringData = "7;8;5";
            ATriangle parsedTriangle = (ATriangle)stringData;
            Console.WriteLine($"Трикутник, створений з рядка '{stringData}': {(string)parsedTriangle}");
        }
    }
}