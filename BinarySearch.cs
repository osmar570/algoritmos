namespace algoritmos
{
    public class BinarySearch
    {
        public static int _binarySearch(int[] arr, int target)
        {
            var left = 0;
            var right = arr.Length - 1;

            while(left <= right)
            {
                var middle = (left + right)/2;
                if(arr[middle] == target)
                {
                    return middle;
                }
                else if(arr[middle] > target){
                  right = middle - 1;
                }
                else {
                  left = middle + 1;
                }
            }
            return -1;
        }
    }
}
