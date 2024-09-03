using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practice2024
{
    internal class SquareWithMaximumSumDynamic
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size[0], size[1]];
            int bestSum = 0;
            int[] bestIndexes = new int[2];
            ReadMatrix(matrix);

            for (int r = 0; r < matrix.GetLength(0) - n + 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - n + 1; c++)
                {
                    int curR = r;
                    int curC = c;
                    int curSum = GetSumFromMatrix(matrix, curR, curC, n);

                    if (bestSum < curSum)
                    {
                        bestIndexes[0] = curR;
                        bestIndexes[1] = curC;
                        bestSum = curSum;
                    }
                }
            }

            PrintMatrix(matrix, bestIndexes, n);
            Console.WriteLine(bestSum);
        }

        private static void PrintMatrix(int[,] matrix, int[] bestIndexes, int n)
        {
            int row = bestIndexes[0];
            int col = bestIndexes[1];

            for (int r = row; r < row + n; r++)
            {
                for (int c = col; c < col + n; c++)
                {
                    Console.Write(matrix[r,c]+ " ");
                }

                Console.WriteLine();
            }
        }

        private static int GetSumFromMatrix(int[,] matrix, int curR, int curC, int n)
        {
            int sum = 0;

            for (int r = curR; r < n + curR; r++)
            {
                for (int c = curC; c < n + curC; c++)
                {
                    sum += matrix[r, c];
                }
            }

            return sum;
        }
        private static void ReadMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = data[c];
                }
            }
        }
    }
}



