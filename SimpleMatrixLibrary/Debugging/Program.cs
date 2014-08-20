using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMatrixLibrary;

namespace Debugging
{
    class Program
    {
        /// <summary>
        /// Simple console application for unit tests
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args)
        {
            // Calculate inverse of a matrix
            Matrix3x3 firstMatrix = new Matrix3x3(3, 2 ,-1, 5, 6, 8, -9, 3, 1);
            Matrix3x3 secondMatrix = firstMatrix.Inverse();

            Console.WriteLine("First matrix:");
            Console.WriteLine(firstMatrix.ToString());
            Console.WriteLine();

            Console.WriteLine("Second matrix (inverse):");
            Console.WriteLine(secondMatrix.ToString());
            Console.WriteLine();

            // Multiply orignal matrix and inverse to check if inverse is correct
            // Result should be identity matrix
            Console.WriteLine("Result (first matrix * second matrix):");
            Console.WriteLine((firstMatrix * secondMatrix).ToString());
            Console.WriteLine();

            // Test vector rotation
            Vector2 testVector = new Vector2(15, -10);

            Console.WriteLine("Vector2 (before rotation):");
            Console.WriteLine(testVector.ToString());
            Console.WriteLine();

            testVector = testVector.Rotate((float)(Math.PI) * 0.5f);    // == 90°

            Console.WriteLine("Vector2 (after rotation):");
            Console.WriteLine(testVector.ToString());
            Console.WriteLine();
        }
    }
}
