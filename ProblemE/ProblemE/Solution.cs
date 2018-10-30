namespace ProblemE
{
    public class Solution
    {
        private readonly int[] a;

        private readonly int m;

        private readonly int n;

        private readonly int maxCycles;

        private readonly long[,] memo;

        private const int initValue = int.MinValue;

        public Solution(int n, int m, int[] a)
        {
            this.n = n;
            this.m = m;
            this.a = a;

            maxCycles = (n / m) + 1;
            memo = new long[maxCycles, m];
        }

        public long Solve()
        {
            if (m > n)
            {
                return 0;
            }

            InitMemo();

            return Solve(0, 0);
        }

        private void InitMemo()
        {           
            for (int i = 0; i < maxCycles; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    memo[i, j] = initValue;
                }
            }
        }

        private long Solve(int cycle, int prevIndex)
        {
            if (cycle >= maxCycles)
            {
                return 0;
            }

            if (memo[cycle, prevIndex] != initValue)
            {
                return memo[cycle, prevIndex];
            }

            long cycleMaxCalories = -1;

            for (int i = prevIndex; i < m; i++)
            {
                long currentMaxCalories = 0;

                int aIndex = cycle * (m + 1) + i;

                if (aIndex < n)
                {
                    currentMaxCalories = a[aIndex];
                }

                currentMaxCalories += Solve(cycle + 1, i);

                if (currentMaxCalories > cycleMaxCalories)
                {
                    cycleMaxCalories = currentMaxCalories;
                }             
            }

            memo[cycle, prevIndex] = cycleMaxCalories;

            return cycleMaxCalories;
        }
    }
}