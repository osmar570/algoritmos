namespace algoritmos;

public class Sum
{
    public static int Soma(List<int> nums)
    {
        if (nums.Count == 0)
        {
            return 0;
        }
        else
        {
            return nums[0] + Soma(nums.Skip(1).ToList());
        }
    }
}