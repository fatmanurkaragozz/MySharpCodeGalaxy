using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeRecoveryWithRobots
{
    class Program
    {
        public static int CalculateSavedNodes(int[][] grid, int[][] robotPositions)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            bool[,] visited = new bool[rows, cols];
            int totalSavedNodes = 0;

            foreach (int[] robotPosition in robotPositions)
            {
                int row = robotPosition[0];
                int col = robotPosition[1];

                if (grid[row][col] == 1 && !visited[row, col])
                {
                    totalSavedNodes += DFS(grid, visited, row, col);
                }
            }

            return totalSavedNodes;
        }

        private static int DFS(int[][] grid, bool[,] visited, int row, int col)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == 0 || visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;


            int count = 1;
            count += DFS(grid, visited, row - 1, col); // Üst
            count += DFS(grid, visited, row + 1, col); // Alt
            count += DFS(grid, visited, row, col - 1); // Sol
            count += DFS(grid, visited, row, col + 1); // Sağ

            return count;
        }


    }
}
