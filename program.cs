using System.Runtime.InteropServices;

namespace algoritmos
{
    public class program
    {
        public static void Main(string[] args)
        {
            int[] nums = [10,5,2,3,9];
            var sortedArr = Sort.QuickSort(nums);
            
            Console.WriteLine(String.Join(", ", sortedArr));
        }
    }
}