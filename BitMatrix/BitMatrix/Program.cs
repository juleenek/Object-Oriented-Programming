using System;
using System.Collections;

namespace BitMatrix
{
    class Program
    {
        public partial class BitMatrix
        {
            private BitArray data;
            public int NumberOfRows { get; }
            public int NumberOfColumns { get; }
            public bool IsReadOnly => false;

            // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
            public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
            {
                if (numberOfRows < 1 || numberOfColumns < 1)
                    throw new ArgumentOutOfRangeException("Incorrect size of matrix");
                data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
                NumberOfRows = numberOfRows;
                NumberOfColumns = numberOfColumns;
            }

            public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
            public static bool BitToBool(int bit) => bit != 0;

            public override string ToString()
            {
                string result = "";

                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfColumns; j++)
                    {
                        result += BoolToBit(data[(i * NumberOfColumns) + j]);
                    }
                   result += Environment.NewLine;
                }

                return result;
            }
        }
        static void Main(string[] args)
        {
            // macierz bitów 4x3 wypełniona
            // domyślną wartością
            var m = new BitMatrix(4, 3);
            Console.WriteLine(m.ToString());

            // macierz bitów 3x4 wypełniona 1
            m = new BitMatrix(3, 4, 1);
            Console.WriteLine(m);
        }
    }
}
