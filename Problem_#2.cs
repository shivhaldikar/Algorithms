/*
 * Find number of ways to climb stairs when given possible number of steps.
 * e.g. Number of steps on a stairs 2. Possible number of steps can be taken at a time: [1,2].
 * then number of ways stairs can be climbed are 2 [1,2] and [2]
 */
using BenchmarkDotNet.Attributes;
namespace Algo
{
    [MemoryDiagnoser]
    public partial class Problem2
    {
        public static int NumberOfWaysToClimb(int numberOfSteps, int[] possibleSteps)
        {
            if (numberOfSteps == 0)
            {
                return 1;
            }

            int[] num = new int[numberOfSteps + 1];
            num[0] = 1;
            for (int i = 1; i <= numberOfSteps; i++)
            {
                int total = 0;
                foreach (int j in possibleSteps)
                {
                    if (i - j >= 0)
                    {
                        total += num[i - j];
                    }
                }
                num[i] = total;
            }
            return num[numberOfSteps];
        }

        public static int NumberOfWaysToClimbRecursive(int numberOfSteps, int[] arrayPossibleSteps)
        {
            if (numberOfSteps == 0)
            {
                return 1;
            }

            int total = 0;
            foreach (int j in arrayPossibleSteps)
            {
                if (numberOfSteps - j >= 0)
                {
                    total += NumberOfWaysToClimbRecursive(numberOfSteps - j, arrayPossibleSteps);
                }
            }
            return total;
        }
    }
}