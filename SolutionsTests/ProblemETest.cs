using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemE;

namespace SolutionsTests
{
    [TestClass]
    public class ProblemETest
    {
        [TestMethod]
        public void Solve_ProblemText_Test()
        {
            int n = 20;
            int m = 5;
            int[] a = new int[20] { 25, 54, 19, 16, 83, 5,
                                    21, 99, 73, 74, 90, 71,
                                    17, 54, 61, 94, 36, 16,
                                    9, 16
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(247, maxCalories);
        }

        [TestMethod]
        public void Solve_AllZeroes_Test()
        {
            int n = 10;
            int m = 3;
            int[] a = new int[10] { 0, 0, 0,
                                    0, 0, 0,
                                    0, 0, 0,
                                    0
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(0, maxCalories);
        }

        [TestMethod]
        public void Solve_SingleIncompleteCycle_Test()
        {
            int n = 3;
            int m = 2;
            int[] a = new int[3] { 25, 54, 19 };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(54, maxCalories);
        }
               
        [TestMethod]
        public void Solve_SingleCompleteCycle_Test()
        {
            int n = 3;
            int m = 2;
            int[] a = new int[3] { 54, 25, 19 };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(54, maxCalories);
        }

        [TestMethod]
        public void SolveTest_TooBigM_NoSolutionTest()
        {
            int n = 3;
            int m = 5;
            int[] a = new int[3] { 25, 54, 19 };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(0, maxCalories);
        }

        [TestMethod]
        public void Solve_AllSameIndex_IncompleteLastCycleTest()
        {
            int n = 20;
            int m = 5;
            int[] a = new int[20] { 99, 54, 19, 16, 83, 5,
                                    99, 98, 73, 74, 90, 71,
                                    99, 54, 61, 94, 36, 16,
                                    99, 16
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(396, maxCalories);
        }

        [TestMethod]
        public void Solve_AllSameIndex_CompleteLastCycleTest()
        {
            int n = 20;
            int m = 5;
            int[] a = new int[20] { 11, 19, 99, 16, 83, 99,
                                    98, 99, 99, 74, 90, 71,
                                    21, 54, 99, 94, 36, 16,
                                    13, 16
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(297, maxCalories);
        }

        [TestMethod]
        public void Solve_SingleGreedyRow_CompleteLastCycleTest()
        {
            int n = 18;
            int m = 5;
            int[] a = new int[18] { 99, 19, 99, 16, 83, 99,
                                    1, 2, 3, 4, 5, 6,
                                    21, 54, 99, 94, 36, 7
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(201, maxCalories);
        }

        [TestMethod]
        public void Solve_SingleGreedyRow_IncompleteLastCycleTest()
        {
            int n = 20;
            int m = 5;
            int[] a = new int[20] { 99, 19, 99, 16, 83, 99,
                                    1, 2, 3, 4, 5, 6,
                                    21, 54, 99, 94, 36, 7,
                                    13, 99
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(254, maxCalories);
        }

        [TestMethod]
        public void Solve_MultipleGreedyRows_CompleteLastCycleTest()
        {
            int n = 24;
            int m = 5;
            int[] a = new int[24] { 99, 19, 99, 16, 83, 99,
                                    1, 2, 3, 4, 5, 6,
                                    1, 2, 3, 4, 5, 6,
                                    21, 54, 99, 94, 36, 7
            };

            Solution sln = new Solution(n, m, a);
            long maxCalories = sln.Solve();

            Assert.AreEqual(204, maxCalories);
        }
    }
}