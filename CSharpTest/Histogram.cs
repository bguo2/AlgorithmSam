using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class Histogram
    {
        //calaculate largest rectangle in Histogram
        public static int LargestRectangleArea(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();

            int max = 0;
            int i = 0;

            while (i < height.Length)
            {
                //push index to stack when the current height is larger than the previous one
                if (stack.Count == 0 || height[i] >= height[stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    //calculate max value when the current height is less than the previous one
                    int p = stack.Pop();
                    int h = height[p];
                    int w = (stack.Count == 0) ? i : i - stack.Peek() - 1;
                    max = Math.Max(h * w, max);
                }
            }

            while (stack.Count > 0)
            {
                int p = stack.Pop();
                int h = height[p];
                int w = (stack.Count == 0) ? i : i - stack.Peek() - 1;
                max = Math.Max(h * w, max);
            }

            return max;
        }

        public static int MaximalRectangle(int[][] matrix)
        {
            int m = matrix.Length;
            int n = m == 0 ? 0 : matrix.GetLength(0);
            int[][] height = new int[m][];

            for (int i = 0; i < m; i++)
            {
                height[i] = new int[n];
            }

            int maxArea = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        height[i][j] = 0;
                    }
                    else
                    {
                        height[i][j] = i == 0 ? 1 : height[i - 1][j] + 1;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                int area = LargestRectangleArea(height[i]);
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

            return maxArea;
        }

        public static void Test()
        {
            int[] h = new int[] { 2, 1, 5, 6, 2, 3 };
            var maxArea = Histogram.LargestRectangleArea(h);

            int[][] hh = new int[][] {
                new int[] { 0, 1, 1, 0},
                new int[] { 0, 1, 1, 0},
                new int[] { 1, 1, 1, 0},
                new int[] { 1, 1, 1, 0}
            };
            maxArea = Histogram.MaximalRectangle(hh);
        }
    }
}
