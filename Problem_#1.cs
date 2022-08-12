/*
 * Sort array when min and max number in the array is given.
 * e.g. min number: 1, max number: 8, array: [3,1,2,6,4,8,7]
 */
using BenchmarkDotNet.Attributes;
namespace Algo
{
    [MemoryDiagnoser]
    public partial class Problem1
    {
        public static int[] Sort(int min, int max, int[] numbers)
        {
            int[] indexes = new int[(max - min) + 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                indexes[numbers[i] - min]++;
            }
            int index = 0;
            for (int i = 0; i < max; i++)
            {
                if (indexes[i] > 0)
                {
                    numbers[index++] = i + min;
                }
            }
            return numbers;
        }

        public static int[] BubleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        int swap = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = swap;
                    }
                }
            }
            return numbers;
        }

        [Benchmark]
        public void BubleSort()
        {
            BubleSort(new int[] { 3, 1, 25, 2, 6, 29, 4, 8, 47, 14, 7, 5, 4, 6, 7, 57, 10, 34, 28, 32, 68, 45 });
        }

        [Benchmark]
        public void Sort()
        {
            Sort(1, 68, new int[] { 3, 1, 25, 2, 6, 29, 4, 8, 47, 14, 7, 5, 4, 6, 7, 57, 10, 34, 28, 32, 68, 45 });
        }
    }
}