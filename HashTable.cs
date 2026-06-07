using System.Collections.Concurrent;

namespace algoritmos;

public class HashTable
{
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> hashTable = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (hashTable.ContainsKey(complement))
            {
                return new int[] { hashTable[complement], i };
            }

            hashTable[nums[i]] = i;
        }

        throw new ArgumentException("No two sum solution found.");
    }

    public static decimal ReturnProductValue(List<Products> produtos, string nomeProduto)
    {
        ConcurrentDictionary<string, decimal> produtoValor = new ConcurrentDictionary<string, decimal>();

        foreach (var produto in produtos)
        {
            produtoValor[produto.Name] = produto.Price;
        }

        return produtoValor[nomeProduto];
    }
}