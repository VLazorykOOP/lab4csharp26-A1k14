using System;

namespace Lab4CSharp
{
    public class VectorDouble
    {
        protected double[] DArray;
        protected uint num;
        protected int codeError;
        protected static uint num_vd = 0;

        public VectorDouble()
        {
            num = 1;
            DArray = new double[1];
            DArray[0] = 0;
            num_vd++;
        }

        public VectorDouble(uint size)
        {
            num = size;
            DArray = new double[size];
            for (uint i = 0; i < size; i++) DArray[i] = 0;
            num_vd++;
        }

        public VectorDouble(uint size, double initVal)
        {
            num = size;
            DArray = new double[size];
            for (uint i = 0; i < size; i++) DArray[i] = initVal;
            num_vd++;
        }

        ~VectorDouble()
        {
            Console.WriteLine("Об'єкт VectorDouble знищено.");
        }

        public uint Size => num;

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public static uint GetVectorCount()
        {
            return num_vd;
        }

        public void Input()
        {
            for (uint i = 0; i < num; i++)
            {
                Console.Write($"Введіть DArray[{i}]: ");
                while (!double.TryParse(Console.ReadLine(), out DArray[i]))
                {
                    Console.Write("Помилка. Введіть дійсне число: ");
                }
            }
        }

        public void Output()
        {
            Console.Write("[ ");
            for (uint i = 0; i < num; i++) Console.Write($"{DArray[i]} ");
            Console.WriteLine("]");
        }

        public void AssignValue(double val)
        {
            for (uint i = 0; i < num; i++) DArray[i] = val;
        }

        public double this[uint index]
        {
            get
            {
                if (index >= num)
                {
                    codeError = -1;
                    return 0;
                }
                codeError = 0;
                return DArray[index];
            }
            set
            {
                if (index >= num)
                {
                    codeError = -1;
                }
                else
                {
                    DArray[index] = value;
                    codeError = 0;
                }
            }
        }

        public static VectorDouble operator ++(VectorDouble v)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] + 1;
            return res;
        }

        public static VectorDouble operator --(VectorDouble v)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] - 1;
            return res;
        }

        public static bool operator true(VectorDouble v)
        {
            if (v.num == 0) return false;
            foreach (double val in v.DArray)
            {
                if (val != 0) return true;
            }
            return false;
        }

        public static bool operator false(VectorDouble v)
        {
            if (v.num == 0) return true;
            foreach (double val in v.DArray)
            {
                if (val != 0) return false;
            }
            return true;
        }

        public static bool operator !(VectorDouble v)
        {
            return v.num != 0;
        }

        public static VectorDouble operator ~(VectorDouble v)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = Math.Truncate(v.DArray[i]);
            return res;
        }

        public static VectorDouble operator +(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 0;
                res.DArray[i] = val1 + val2;
            }
            return res;
        }

        public static VectorDouble operator -(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 0;
                res.DArray[i] = val1 - val2;
            }
            return res;
        }

        public static VectorDouble operator *(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 0;
                res.DArray[i] = val1 * val2;
            }
            return res;
        }

        public static VectorDouble operator /(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 1;
                res.DArray[i] = val1 / val2;
            }
            return res;
        }

        public static VectorDouble operator %(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 1;
                res.DArray[i] = val1 % val2;
            }
            return res;
        }

        public static VectorDouble operator +(VectorDouble v, double scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] + scalar;
            return res;
        }

        public static VectorDouble operator -(VectorDouble v, double scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] - scalar;
            return res;
        }

        public static VectorDouble operator *(VectorDouble v, double scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] * scalar;
            return res;
        }

        public static VectorDouble operator /(VectorDouble v, double scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] / scalar;
            return res;
        }

        public static VectorDouble operator %(VectorDouble v, double scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++) res.DArray[i] = v.DArray[i] % scalar;
            return res;
        }

        public static VectorDouble operator |(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 0;
                long bits1 = BitConverter.DoubleToInt64Bits(val1);
                long bits2 = BitConverter.DoubleToInt64Bits(val2);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits1 | bits2);
            }
            return res;
        }

        public static VectorDouble operator |(VectorDouble v, byte scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++)
            {
                long bits = BitConverter.DoubleToInt64Bits(v.DArray[i]);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits | scalar);
            }
            return res;
        }

        public static VectorDouble operator ^(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 0;
                long bits1 = BitConverter.DoubleToInt64Bits(val1);
                long bits2 = BitConverter.DoubleToInt64Bits(val2);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits1 ^ bits2);
            }
            return res;
        }

        public static VectorDouble operator ^(VectorDouble v, byte scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++)
            {
                long bits = BitConverter.DoubleToInt64Bits(v.DArray[i]);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits ^ scalar);
            }
            return res;
        }

        public static VectorDouble operator &(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                double val2 = i < v2.num ? v2.DArray[i] : 0;
                long bits1 = BitConverter.DoubleToInt64Bits(val1);
                long bits2 = BitConverter.DoubleToInt64Bits(val2);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits1 & bits2);
            }
            return res;
        }

        public static VectorDouble operator &(VectorDouble v, byte scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++)
            {
                long bits = BitConverter.DoubleToInt64Bits(v.DArray[i]);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits & scalar);
            }
            return res;
        }

        public static VectorDouble operator >>(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                int shiftVal = i < v2.num ? (int)Math.Truncate(v2.DArray[i]) : 0;
                long bits1 = BitConverter.DoubleToInt64Bits(val1);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits1 >> shiftVal);
            }
            return res;
        }

        public static VectorDouble operator >>(VectorDouble v, int scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++)
            {
                long bits = BitConverter.DoubleToInt64Bits(v.DArray[i]);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits >> scalar);
            }
            return res;
        }

        public static VectorDouble operator <<(VectorDouble v1, VectorDouble v2)
        {
            uint maxSize = Math.Max(v1.num, v2.num);
            VectorDouble res = new VectorDouble(maxSize);
            for (uint i = 0; i < maxSize; i++)
            {
                double val1 = i < v1.num ? v1.DArray[i] : 0;
                int shiftVal = i < v2.num ? (int)Math.Truncate(v2.DArray[i]) : 0;
                long bits1 = BitConverter.DoubleToInt64Bits(val1);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits1 << shiftVal);
            }
            return res;
        }

        public static VectorDouble operator <<(VectorDouble v, int scalar)
        {
            VectorDouble res = new VectorDouble(v.num);
            for (uint i = 0; i < v.num; i++)
            {
                long bits = BitConverter.DoubleToInt64Bits(v.DArray[i]);
                res.DArray[i] = BitConverter.Int64BitsToDouble(bits << scalar);
            }
            return res;
        }

        public static bool operator ==(VectorDouble v1, VectorDouble v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++)
            {
                if (v1.DArray[i] != v2.DArray[i]) return false;
            }
            return true;
        }

        public static bool operator !=(VectorDouble v1, VectorDouble v2)
        {
            return !(v1 == v2);
        }

        public static bool operator >(VectorDouble v1, VectorDouble v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++)
            {
                if (v1.DArray[i] <= v2.DArray[i]) return false;
            }
            return true;
        }

        public static bool operator <(VectorDouble v1, VectorDouble v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++)
            {
                if (v1.DArray[i] >= v2.DArray[i]) return false;
            }
            return true;
        }

        public static bool operator >=(VectorDouble v1, VectorDouble v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++)
            {
                if (v1.DArray[i] < v2.DArray[i]) return false;
            }
            return true;
        }

        public static bool operator <=(VectorDouble v1, VectorDouble v2)
        {
            if (v1.num != v2.num) return false;
            for (uint i = 0; i < v1.num; i++)
            {
                if (v1.DArray[i] > v2.DArray[i]) return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Ізольоване тестування класу VectorDouble ---");
            Console.WriteLine($"Векторів у пам'яті до створення: {VectorDouble.GetVectorCount()}");

            VectorDouble v1 = new VectorDouble(3, 7.5);
            Console.Write("Вектор v1 (3 елементи по 7.5): ");
            v1.Output();

            VectorDouble v2 = new VectorDouble(4);
            Console.WriteLine("\nЗаповнення Вектора v2 (4 елементи):");
            v2.Input();

            VectorDouble vSum = v1 + v2;
            Console.Write("\nРезультат додавання v1 + v2 (зверніть увагу на розширення розміру): ");
            vSum.Output();

            VectorDouble vDiv = v1 / v2;
            Console.Write("Результат ділення v1 / v2 (безпека відсутніх елементів збережена): ");
            vDiv.Output();

            VectorDouble vTruncated = ~v1;
            Console.Write("Результат унарної операції ~ (ціла частина v1): ");
            vTruncated.Output();

            Console.WriteLine($"\nДоступ до v2[1]: {v2[1]}");
            double checkError = v2[99];
            Console.WriteLine($"Спроба доступу до неіснуючого індексу v2[99]. Код помилки: {v2.CodeError}");

            if (v1)
            {
                Console.WriteLine("\nВектор v1 валідний (спрацював operator true).");
            }
        }
    }
}