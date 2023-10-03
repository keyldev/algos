using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search.Search
{
    internal class BinarySearch
    {

        public int Recursive(int[] array, int digit, int startIndex, int lastIndex)
        {
            if (startIndex > lastIndex)
            {
                return -1;
            }
            int middleIndex = (startIndex + lastIndex) / 2;
            int middleValue = array[middleIndex];
            if (middleValue == digit)
            {
                return middleIndex;
            }
            if (middleValue > digit)
            {
                return Recursive(array, digit, startIndex, middleIndex - 1);
            }
            else
            {
                return Recursive(array, digit, middleIndex + 1, lastIndex);
            }
        }

        public void Iterative(int[,] array, int digit)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            int left = 0;
            int right = rows * cols - 1;
            while(left <= right)
            {
                int middle = (left + right) / 2;
                int midRow = middle / cols;
                int midCol = middle % cols;

                if (array[midRow, midCol] == digit)
                {
                    Console.WriteLine($"Row: {midRow}; Col: {midCol}");

                    break;
                }
                else if (array[midRow, midCol] <  digit)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
        }

        public int Iterative(int[] array, int digit)
        {
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int middleIndex = (left + right) / 2;
                if (array[middleIndex] == digit)
                {
                    return middleIndex;
                }
                else if (digit < array[middleIndex])
                {
                    right = middleIndex - 1;
                }
                else { left = middleIndex + 1; }
            }
            return -1;
        }


        public int Default(int[] array, int digit)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == digit)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
