using System;
using System.Collections;

namespace BitMatrix
{
    class Program
    {
        public partial class BitMatrix : IEquatable<BitMatrix>
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

            public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
            {
                if (numberOfRows < 1 || numberOfColumns < 1)
                    throw new ArgumentOutOfRangeException("Incorrect size of matrix");

                if (bits == null || bits.Length == 0)
                {
                    data = new BitArray(numberOfRows * numberOfColumns, BitToBool(0));
                }
                if (bits != null && bits.Length != 0)
                {
                    data = new BitArray(numberOfRows * numberOfColumns, BitToBool(0));
                    for (int i = 0; i < bits.Length; i++)
                    {
                        if (i < data.Length)
                        {
                            if(bits[i] == 0)
                            {
                                data[i] = BitToBool(0);
                            }
                            else
                            {
                                data[i] = BitToBool(1);
                            }
                           
                        }
                    }
                }

                NumberOfRows = numberOfRows;
                NumberOfColumns = numberOfColumns;
            }

            public BitMatrix(int[,] bits)
            {
                if (bits == null) throw new NullReferenceException();
                if (bits.Length == 0) throw new ArgumentOutOfRangeException();

                NumberOfRows = bits.GetLength(0);
                NumberOfColumns = bits.GetLength(1);
                data = new BitArray(NumberOfRows * NumberOfColumns, BitToBool(0));
                int index = 0;

                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfColumns; j++)
                    {
                        if (bits[i, j] == 0)
                        {
                            data[index] = BitToBool(0);
                        }
                        else
                        {
                            data[index] = BitToBool(1);
                        }
                        index++;
                    }                  
                }

            }

            public BitMatrix(bool[,] bits)
            {
                if (bits == null) throw new NullReferenceException();
                if (bits.Length == 0) throw new ArgumentOutOfRangeException();

                NumberOfRows = bits.GetLength(0);
                NumberOfColumns = bits.GetLength(1);
                data = new BitArray(NumberOfRows * NumberOfColumns, BitToBool(0));
                int index = 0;

                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfColumns; j++)
                    {
                        if (data.Length >= bits.Length)
                        {
                            data[index] = bits[i, j];
                        }
                        index++;
                    }
                }
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

            public bool Equals(BitMatrix other)
            {
                if (ReferenceEquals(other, null)) return false;
                if (!(other is BitMatrix)) return false;

                if (NumberOfColumns == other.NumberOfColumns && NumberOfRows == other.NumberOfRows)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] == other.data[i]) return true;
                    }
                }
                return false;
            }
            public override bool Equals(object obj)
            {
                if (obj is BitMatrix) return base.Equals(obj);
                return false;
            }

            public static bool operator ==(BitMatrix first, BitMatrix second)
            {
                if (ReferenceEquals(first, null) && ReferenceEquals(second, null)) return true;
                if (ReferenceEquals(first, null)) return false;
                if (ReferenceEquals(second, null)) return false;
                return first.Equals(second);
            }
            public static bool operator !=(BitMatrix first, BitMatrix second) => !(first == second);

            public override int GetHashCode() => (data, NumberOfRows, NumberOfColumns).GetHashCode();

        }
        static void Main(string[] args)
        {
            // operator `==`, `!=`
            // jeden `null`
            BitMatrix m1 = new BitMatrix(1, 1);
            BitMatrix m2 = null;
            Console.WriteLine(m1 == m2);
            Console.WriteLine(m1 != m2);
            Console.WriteLine(m2 == m1);
            Console.WriteLine(m2 != m1);

        }
    }
}
