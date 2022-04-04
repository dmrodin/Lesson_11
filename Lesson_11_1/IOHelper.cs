using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_1
{
    static class IOHelper
    {
        public static int[] GenerateIntArray(int size, int min, int max)
        {
            int[] array = new int[size];

            Random rnd = new Random();

            for(int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(min, max);
            }

            return array;
        }
        public static double[] GenerateDoubleArray(int size, double min, double max)
        {
            double[] array = new double[size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.NextDouble() * (max - min) + min;
            }

            return array;
        }
        public static int[,] GenerateIntMatrix(int rows, int cols, int min, int max)
        {
            int[,] arr = new int[rows, cols];

            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rnd.Next(min, max);
                }
            }

            return arr;
        }
        public static double[,] GenerateDoubleMatrix(int rows, int cols, double min, double max)
        {
            double[,] arr = new double[rows, cols];

            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rnd.NextDouble() * (max - min) + min; 
                }
            }

            return arr;
        }
        public static void PrintArray(int[,] arr, string separator = "\t")
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}{separator}");
                }
                Console.WriteLine();
            }
        }
        public static void PrintArray(double[,] arr, string separator = "\t")
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}{separator}");
                }
                Console.WriteLine();
            }
        }
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static void PrintArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
