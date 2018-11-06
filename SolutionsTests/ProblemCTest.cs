using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemC;

namespace SolutionsTests
{
    [TestClass]
    public class ProblemCTest
    {
        [TestMethod]
        public void Solve_ProblemText_Test()
        {
            int n = 3;

            char[,] map = new char[3, 3] {
                {'P', '.', '.'},
                {'.', 'K', 'K'},
                {'.', '.', '.'},
            };

            int[,] heights = new int[3, 3] {
                {3, 2, 4},
                {7, 4, 2},
                {2, 3, 1},
            };

            Solution sln = new Solution(n, map, heights);
            int heightDiff = sln.Solve();

            Assert.AreEqual(2, heightDiff);
        }

        [TestMethod]
        public void Solve_SingleHouse_Test()
        {
            int n = 50;

            char[,] map = GenerateFieldMap(n);
            map[3, 7] = 'P';
            map[47, 48] = 'K';

            int[,] heights = GenerateHeights(n, 10);
            heights[3, 7] = 1;
            heights[47, 48] = 7;

            Solution sln = new Solution(n, map, heights);
            int heightDiff = sln.Solve();

            Assert.AreEqual(9, heightDiff);
        }



        [TestMethod]
        public void Solve_CornerHousesSameLevel_Test()
        {
            int n = 3;

            char[,] map = GenerateFieldMap(n);
            map[0, 0] = 'P';
            map[0, 2] = 'K';
            map[2, 0] = 'K';
            map[2, 2] = 'K';

            int[,] heights = GenerateHeights(n, 1000000);
            heights[0, 0] = 1;
            heights[0, 1] = 1;
            heights[0, 2] = 1;
            heights[2, 0] = 1;
            heights[2, 1] = 1;
            heights[2, 2] = 1;
            heights[1, 0] = 1;
            heights[1, 2] = 1;

            Solution sln = new Solution(n, map, heights);
            int heightDiff = sln.Solve();

            Assert.AreEqual(0, heightDiff);
        }

        private char[,] GenerateFieldMap(int n)
        {
            char[,] map = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = '.';
                }
            }

            return map;
        }

        private int[,] GenerateHeights(int n, int defaultH)
        {
            int[,] heights = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    heights[i, j] = defaultH;
                }
            }

            return heights;
        }
    }
}