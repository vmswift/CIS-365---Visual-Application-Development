//Lab07 BubbleSort
//CIS365
//Dr. Lewis
//Summer 2017
//By John Knowles
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortTestApp
{
    class BubbleSortTestClass
    {
        static void Main(string[] args)
        {
            int[] anArrayOfIntegers = { 9, 7, 4, 10, 48, 1, 3, 5, 7 };
            double[] anArrayOfDoubles = { 9.0, 7.0, 3.5, 8.9, 8.3, 3.14, 42.0 };
            string[] anArrayOfStrings = { "Tom", "Dick", "Harry", "James", "Sam" };
            BubbleSortTestClass bSortTestObj = new BubbleSortTestClass();

            bSortTestObj.BubbleSortGeneric<int>(ref anArrayOfIntegers);
            bSortTestObj.PrintArrayGeneric<int>(anArrayOfIntegers);

            bSortTestObj.BubbleSortGeneric<double>(ref anArrayOfDoubles);
            bSortTestObj.PrintArrayGeneric<double>(anArrayOfDoubles);

            bSortTestObj.BubbleSortGeneric<string>(ref anArrayOfStrings);
            bSortTestObj.PrintArrayGeneric<string>(anArrayOfStrings);
        }

        // PrintArrayGeneric<T>(T [])
        // Assumes: An array has been initialized
        // Result: Outputs the array
        // NOTE: Overloaded method
        public void PrintArrayGeneric<T>(T[] arr)
        {
            foreach (T elem in arr)
            {
                Console.Write("{0} ", elem);
            }
            Console.WriteLine();
        }

        // BubbleSortGeneric<T)
        // Assumes: The type T supports the IComparable interface (implements CompareTo())
        // Returns: Nothing, but the array arr is sorted as a side effect
        public void BubbleSortGeneric<T>(ref T[] arr) where T : IComparable
        {
            int i;
            int j;
            for (i = (arr.Length - 1); i >= 0; i--)
            {
                int compareToResult = 0;
                for (j = 1; j <= i; j++)
                {
                    compareToResult = arr[j - 1].CompareTo(arr[j]);
                    if (compareToResult > 0)
                    {
                        T temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
