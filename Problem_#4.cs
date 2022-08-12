/*
 * Given an array of integers, return a new array such that each element at index i of the new array is the product of all 
 * the numbers in the original array except the one at i.
 * For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. 
 * If our input was [3, 2, 1], the expected output would be [2, 3, 6].
 */
using System.Text;
using BenchmarkDotNet.Attributes;
namespace Algo
{
    [MemoryDiagnoser]
    public partial class Problem4
    {
        public static int[] FindProduct(int[] numbers)
        {
            int[] productList = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                int product = 1;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j != i)
                    {
                        product *= numbers[j];
                    }
                }
                productList[i] = product;
            }
            return productList;
        }

        public static int[] FindProduct_Divison(int[] numbers)
        {
            int[] productList = new int[numbers.Length];
            int product = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                productList[i] = product / numbers[i];
            }

            return productList;
        }


        [Benchmark]
        public void FindProduct()
        {
            FindProduct(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [Benchmark]
        public void FindProduct_Divison()
        {
            FindProduct_Divison(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }
    }
}