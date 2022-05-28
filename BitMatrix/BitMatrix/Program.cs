using System;
using System.Collections;
using System.Collections.Generic;

namespace BitMatrix
{
    class Program
    {
        public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>, ICloneable
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
            public int this[int i, int j]
            {
                get
                {
                    if (i < 0 || j < 0 || i >= NumberOfColumns || j >= NumberOfColumns) throw new IndexOutOfRangeException();
                    return BoolToBit(data[i * NumberOfColumns + j]);
                }
                set
                {
                    try
                    {
                        data[i * NumberOfColumns + j] = BitToBool(value);
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                        throw new IndexOutOfRangeException();
                    }
                
                }
            }

            public IEnumerator<int> GetEnumerator()
            {
                foreach (bool item in data)
                {
                    yield return BoolToBit(item);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public object Clone()
            {
                BitMatrix copy = new BitMatrix(NumberOfRows, NumberOfColumns);
                for (int i = 0; i < data.Length; i++)
                {
                    copy.data[i] = data[i];
                }
                return copy;
            }

            public static BitMatrix Parse(string s)
            {
                if (string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException();

                List<int> bits = new List<int>();
                string[] splitted = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                var rowNum = 0;
                var colNum = -1;
                for (int i = 0; i < splitted.Length; i++)
                {
                    for (int j = 0; j < splitted[i].Trim().Length; j++)
                    {
                        if ((int)char.GetNumericValue(splitted[i].Trim()[j]) != 0 
                            && (int)char.GetNumericValue(splitted[i].Trim()[j]) != 1) throw new FormatException();
                        bits.Add((int)char.GetNumericValue(splitted[i].Trim()[j]));
                    }                 
                    if (colNum != -1 && colNum != splitted[i].Trim().Length) throw new FormatException();

                    colNum = splitted[i].Trim().Length;
                    rowNum++;
                }
                return new BitMatrix(rowNum, colNum, bits.ToArray());
            }

            public static bool TryParse(string s, out BitMatrix result)
            {
                result = null;
                if (string.IsNullOrWhiteSpace(s)) return false;

                List<int> bits = new List<int>();
                string[] splitted = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                var rowNum = 0;
                var colNum = -1;
                for (int i = 0; i < splitted.Length; i++)
                {
                    for (int j = 0; j < splitted[i].Trim().Length; j++)
                    {
                        if ((int)char.GetNumericValue(splitted[i].Trim()[j]) != 0
                            && (int)char.GetNumericValue(splitted[i].Trim()[j]) != 1) return false;

                        bits.Add((int)char.GetNumericValue(splitted[i].Trim()[j]));
                    }
                    if (colNum != -1 && colNum != splitted[i].Trim().Length) return false;

                    colNum = splitted[i].Trim().Length;
                    rowNum++;
                }

                result = new BitMatrix(splitted.Length, splitted[0].Length, bits.ToArray());
                return true;
            }

            public static explicit operator BitMatrix(int[,] bits)
            {
                if (bits == null) throw new NullReferenceException();
                if (bits.Length == 0) throw new ArgumentOutOfRangeException();
                return new BitMatrix(bits);
            }
            public static explicit operator BitMatrix(bool[,] values)
            {
                if (values == null) throw new NullReferenceException();
                if (values.Length == 0) throw new ArgumentOutOfRangeException();
                return new BitMatrix(values);
            }

            public static implicit operator int[,](BitMatrix bitMatrix)
            {
                int[,] result = new int[bitMatrix.NumberOfRows, bitMatrix.NumberOfColumns];

                for (int i = 0; i < bitMatrix.NumberOfRows; i++)
                {
                    for (int j = 0; j < bitMatrix.NumberOfColumns; j++)
                    {
                        result[i, j] = bitMatrix[i, j];
                    }
                }

                return result;
            }

            public static implicit operator bool[,](BitMatrix bitMatrix)
            {
                bool[,] result = new bool[bitMatrix.NumberOfRows, bitMatrix.NumberOfColumns];

                for (int i = 0; i < bitMatrix.NumberOfRows; i++)
                {
                    for (int j = 0; j < bitMatrix.NumberOfColumns; j++)
                    {
                        result[i, j] = BitToBool(bitMatrix[i, j]);
                    }
                }

                return result;
            }

            public static explicit operator BitArray(BitMatrix matrix) => new BitArray(matrix.data);

            public BitMatrix And(BitMatrix other)
            {
                if (ReferenceEquals(other, null)) throw new ArgumentNullException();
                if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows) throw new ArgumentException();

                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfColumns; j++)
                    {
                        if(this[i, j] == 1 && other[i, j] == 1)
                        {
                            this[i, j] = 1;
                        } else
                        {
                            this[i, j] = 0;
                        }
                    }
                }

                return this;
            }

            public BitMatrix Or(BitMatrix other)
            {
                if (ReferenceEquals(other, null)) throw new ArgumentNullException();
                if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows) throw new ArgumentException();

                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfColumns; j++)
                    {
                        if (this[i, j] == 1 || other[i, j] == 1)
                        {
                            this[i, j] = 1;
                        }
                        else
                        {
                            this[i, j] = 0;
                        }
                    }
                }

                return this;
            }

            public BitMatrix Xor(BitMatrix other)
            {
                if (ReferenceEquals(other, null)) throw new ArgumentNullException();
                if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows) throw new ArgumentException();

                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfColumns; j++)
                    {
                        if ((this[i, j] == 1 || other[i, j] == 1) && !(this[i, j] == 1 && other[i, j] == 1))
                        {
                            this[i, j] = 1;
                        }
                        else
                        {
                            this[i, j] = 0;
                        }
                    }
                }

                return this;
            }

            public BitMatrix Not()
            {
                if (ReferenceEquals(this, null)) throw new ArgumentNullException();

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = !data[i];
                }
                return this;
            }

            public static BitMatrix operator &(BitMatrix firstBitMatrix, BitMatrix secondBitMatrix)
            {
                if (ReferenceEquals(firstBitMatrix, null) || ReferenceEquals(secondBitMatrix, null)) throw new ArgumentNullException();
                if (firstBitMatrix.NumberOfColumns != secondBitMatrix.NumberOfColumns ||
                    firstBitMatrix.NumberOfRows != secondBitMatrix.NumberOfRows) throw new ArgumentException();

                BitMatrix clonedMatrix = (BitMatrix)firstBitMatrix.Clone();
                return clonedMatrix.And(secondBitMatrix);
            }
            public static BitMatrix operator |(BitMatrix firstBitMatrix, BitMatrix secondBitMatrix)
            {
                if (ReferenceEquals(firstBitMatrix, null) || ReferenceEquals(secondBitMatrix, null)) throw new ArgumentNullException();
                if (firstBitMatrix.NumberOfColumns != secondBitMatrix.NumberOfColumns ||
                    firstBitMatrix.NumberOfRows != secondBitMatrix.NumberOfRows) throw new ArgumentException();

                BitMatrix clonedMatrix = (BitMatrix)firstBitMatrix.Clone();
                return clonedMatrix.Or(secondBitMatrix);
            }
            public static BitMatrix operator ^(BitMatrix firstBitMatrix, BitMatrix secondBitMatrix)
            {
                if (ReferenceEquals(firstBitMatrix, null) || ReferenceEquals(secondBitMatrix, null)) throw new ArgumentNullException();
                if (firstBitMatrix.NumberOfColumns != secondBitMatrix.NumberOfColumns ||
                    firstBitMatrix.NumberOfRows != secondBitMatrix.NumberOfRows) throw new ArgumentException();

                BitMatrix clonedMatrix = (BitMatrix)firstBitMatrix.Clone();
                return clonedMatrix.Xor(secondBitMatrix);
            }
            public static BitMatrix operator !(BitMatrix bitMatrix)
            {
                if (ReferenceEquals(bitMatrix, null)) throw new ArgumentNullException();

                BitMatrix clonedMatrix = (BitMatrix)bitMatrix.Clone();
                return clonedMatrix.Not();
            }

        }
        static void Main(string[] args)
        {
            // operator &
            // poprawne dane
            var m1 = new BitMatrix(2, 3, 1, 0, 1, 1, 1, 0);
            var m2 = new BitMatrix(2, 3, 1, 1, 0, 1, 1, 0);
            //czy & jest symetryczny
            if ((m1 & m2).Equals(m2 & m1))
                Console.WriteLine("Correct data, symmetry: Pass");

            //czy wykonany poprawnie &
            var expected = new BitMatrix(2, 3, 1, 0, 0, 1, 1, 0);
            var m3 = m1 & m2;
            if (expected.Equals(m3))
                Console.WriteLine("Correct data: Pass");

            //czy wynik jest niezależną kopią
            if (!ReferenceEquals(m1, m3) && !ReferenceEquals(m2, m3))
                Console.WriteLine("Correct data, ReferenceEquals: Pass");
            m1[0, 1] = 1; Console.WriteLine(m1[0, 1] != m3[0, 1]);
            m1[1, 2] = 1; Console.WriteLine(m1[1, 2] != m3[1, 2]);

            // argument `null & null`
            try
            {
                var m = (BitMatrix)null & (BitMatrix)null;
                Console.WriteLine(m);
                Console.WriteLine("Arguments null: Fail");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Arguments null: Pass");
            }

            // right argument `null`
            try
            {
                var m = (BitMatrix)null & new BitMatrix(2, 2);
                Console.WriteLine(m);
                Console.WriteLine("Right argument null: Fail");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Right argument null: Pass");
            }

            // left argument `null`
            try
            {
                var m = new BitMatrix(2, 2) & (BitMatrix)null;
                Console.WriteLine(m);
                Console.WriteLine("Left argument null: Fail");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Left argument null: Pass");
            }

            // incorrect dimensions
            try
            {
                var m = new BitMatrix(2, 3) & new BitMatrix(2, 2);
                Console.WriteLine(m);
                Console.WriteLine("Incorrect dimensions: Fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect dimensions: Pass");
            }
        }
    }
}
