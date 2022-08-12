/*
 * Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
 * For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
 */
using System.Text;
using BenchmarkDotNet.Attributes;
namespace Algo
{
    [MemoryDiagnoser]
    public partial class Problem3
    {
        public static bool FindNumbersThatAddup_Sub(int[] numbers, int addition)
        {
            bool found = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int second = addition - numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (second == numbers[j])
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        public static (bool found, string pairs) FindNumbersThatAddup_Add(int[] numbers, int addition)
        {

            StringBuilder pairs = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] <= addition)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] + numbers[j] == addition)
                        {
                            pairs.Append($"{numbers[i]},{numbers[j]}; ");
                        }
                    }
                }
            }
            return (pairs.Length > 1, pairs.ToString());
        }

        public static (bool found, string pairs) FindNumbersThatAddup_SingleIteration(int[] numbers, int sum)
        {
            var store = new int[sum + 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] <= sum)
                {
                    store[numbers[i]] = 1;
                }
            }

            StringBuilder pairs = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                int n = numbers[i];
                if (n <= sum)
                {
                    int a = sum - n;
                    if (a != n)
                    {
                        store[a]++;
                    }
                    store[n]++;

                    if (store[n] == 3 && store[a] == 3)
                    {
                        pairs.Append($"{(a)},{n}; ");
                    }
                }
            }
            return (pairs.Length > 1, pairs.ToString());
        }

        [Benchmark]
        public void FindNumbersThatAddup_Sub()
        {
            FindNumbersThatAddup_Sub(new int[] { 3, 1, 2, 6, 4, 8, 7, 6, 9, 10, 15, 21 }, 25);
        }

        [Benchmark]
        public void FindNumbersThatAddup_Add()
        {
            FindNumbersThatAddup_Add(new int[] { 3, 1, 2, 6, 4, 8, 5, 4, 3, 78, 4, 12, 14, 15, 16, 17, 11, 23, 22, 1, 2, 5, 7, 6, 9, 10, 15, 21 }, 25);
        }

        [Benchmark]
        public void FindNumbersThatAddup_SingleIteration()
        {
            FindNumbersThatAddup_SingleIteration(new int[] { 3, 1, 2, 6, 4, 8, 5, 4, 3, 78, 4, 12, 14, 15, 16, 17, 11, 23, 22, 1, 2, 5, 7, 6, 9, 10, 15, 21 }, 25);
        }
    }
}