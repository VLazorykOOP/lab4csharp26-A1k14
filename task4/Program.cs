using System;

namespace Lab4CSharp
{
    public class MatrixDouble
    {
        protected double[,] data;
        protected uint rows;
        protected uint cols;
        protected int codeError;
        protected static uint matrixCount = 0; 

        public MatrixDouble()
        {
            rows = 1;
            cols = 1;
            data = new double[1, 1];
            data[0, 0] = 0;
            matrixCount++;
        }

        public MatrixDouble(uint r, uint c)
        {
            rows = r;
            cols = c;
            data = new double[rows, cols]; 
            matrixCount++;
        }

        public MatrixDouble(uint r, uint c, double initVal)
        {
            rows = r;
            cols = c;
            data = new double[rows, cols];
            for (uint i = 0; i < rows; i++)
            {
                for (uint j = 0; j < cols; j++)
                {
                    data[i, j] = initVal;
                }
            }
            matrixCount++;
        }

        public uint Rows { get { return rows; } }
        public uint Cols { get { return cols; } }
        public int CodeError { get { return codeError; } set { codeError = value; } }
        public static uint GetCount() { return matrixCount; }

   
        private double GetSafe(uint i, uint j, double defaultVal = 0)
        {
            if (i < rows && j < cols) return data[i, j];
            return defaultVal;
        }

        public double this[uint i, uint j]
        {
            get
            {
                if (i >= rows || j >= cols)
                {
                    codeError = -1; 
                    return 0;
                }
                codeError = 0;
                return data[i, j];
            }
            set
            {
                if (i >= rows || j >= cols) codeError = -1;
                else
                {
                    data[i, j] = value;
                    codeError = 0;
                }
            }
        }

        public double this[uint k]
        {
            get
            {
                uint i = k / cols; 
                uint j = k % cols; 
                return this[i, j]; 
            }
            set
            {
                uint i = k / cols;
                uint j = k % cols;
                this[i, j] = value;
            }
        }

        public void Output()
        {
            for (uint i = 0; i < rows; i++)
            {
                for (uint j = 0; j < cols; j++)
                {
                    Console.Write($"{data[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static MatrixDouble operator ++(MatrixDouble m)
        {
            MatrixDouble res = new MatrixDouble(m.rows, m.cols);
            for (uint i = 0; i < m.rows; i++)
                for (uint j = 0; j < m.cols; j++)
                    res.data[i, j] = m.data[i, j] + 1;
            return res;
        }

        public static bool operator true(MatrixDouble m)
        {
            if (m.rows == 0 || m.cols == 0) return false;
            for (uint i = 0; i < m.rows; i++)
                for (uint j = 0; j < m.cols; j++)
                    if (m.data[i, j] != 0) return true;
            return false;
        }

        public static bool operator false(MatrixDouble m)
        {
            if (m.rows == 0 || m.cols == 0) return true;
            for (uint i = 0; i < m.rows; i++)
                for (uint j = 0; j < m.cols; j++)
                    if (m.data[i, j] != 0) return false;
            return true;
        }

        public static MatrixDouble operator +(MatrixDouble m1, MatrixDouble m2)
        {
            uint maxRows = Math.Max(m1.rows, m2.rows);
            uint maxCols = Math.Max(m1.cols, m2.cols);
            MatrixDouble res = new MatrixDouble(maxRows, maxCols);

            for (uint i = 0; i < maxRows; i++)
            {
                for (uint j = 0; j < maxCols; j++)
                {
                    res.data[i, j] = m1.GetSafe(i, j, 0) + m2.GetSafe(i, j, 0);
                }
            }
            return res;
        }

        public static MatrixDouble operator /(MatrixDouble m1, MatrixDouble m2)
        {
            uint maxRows = Math.Max(m1.rows, m2.rows);
            uint maxCols = Math.Max(m1.cols, m2.cols);
            MatrixDouble res = new MatrixDouble(maxRows, maxCols);

            for (uint i = 0; i < maxRows; i++)
            {
                for (uint j = 0; j < maxCols; j++)
                {
                    res.data[i, j] = m1.GetSafe(i, j, 0) / m2.GetSafe(i, j, 1);
                }
            }
            return res;
        }

        public static MatrixDouble operator +(MatrixDouble m, double scalar)
        {
            MatrixDouble res = new MatrixDouble(m.rows, m.cols);
            for (uint i = 0; i < m.rows; i++)
                for (uint j = 0; j < m.cols; j++)
                    res.data[i, j] = m.data[i, j] + scalar;
            return res;
        }


        public static MatrixDouble operator |(MatrixDouble m1, MatrixDouble m2)
        {
            uint maxRows = Math.Max(m1.rows, m2.rows);
            uint maxCols = Math.Max(m1.cols, m2.cols);
            MatrixDouble res = new MatrixDouble(maxRows, maxCols);

            for (uint i = 0; i < maxRows; i++)
            {
                for (uint j = 0; j < maxCols; j++)
                {
                    long val1 = (long)m1.GetSafe(i, j, 0);
                    long val2 = (long)m2.GetSafe(i, j, 0);
                    res.data[i, j] = val1 | val2;
                }
            }
            return res;
        }

        public static bool operator ==(MatrixDouble m1, MatrixDouble m2)
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols) return false;
            for (uint i = 0; i < m1.rows; i++)
                for (uint j = 0; j < m1.cols; j++)
                    if (m1.data[i, j] != m2.data[i, j]) return false;
            return true;
        }

        public static bool operator !=(MatrixDouble m1, MatrixDouble m2)
        {
            return !(m1 == m2); 
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" MatrixDouble\n");

            MatrixDouble m1 = new MatrixDouble(2, 2, 5.0);
            Console.WriteLine("Матриця m1 (2x2):");
            m1.Output();

            MatrixDouble m2 = new MatrixDouble(3, 3, 2.0);
            Console.WriteLine("Матриця m2 (3x3):");
            m2.Output();

            MatrixDouble sum = m1 + m2;
            Console.WriteLine("Результат m1 + m2 :");
            sum.Output();

            m1++;
            Console.WriteLine("Матриця m1 після операції ++ :");
            m1.Output();

            Console.WriteLine($"Доступ до елемента через одновимірний індекс m1[2]: {m1[2]}");

            double wrongElement = m1[100, 100];
            Console.WriteLine($"Спроба доступу до m1[100, 100]. Значення: {wrongElement}, Код помилки: {m1.CodeError}");
        }
    }
}