namespace algoritmos;

public class Sort
{
    private static int FindLowestValue(List<int> arr)
    {
        var menor = arr[0];
        var lowerIndex = 0;

        for(int i = 0; i < arr.Count; i++){
            if(arr[i] < menor){
                menor = arr[i];
                lowerIndex = i;
            }
        }
        return lowerIndex;
    }
    
    public static int FindBiggestValueIndex(List<int> lista)
    {
        int max = 0;
        int maxIndex = 0;

        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] > max)
            {
                max = lista[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    public static int[] SelectOrder(int[] arr)
    {
        List<int> newArr = [];
        List<int> arrToList = arr.ToList();
        for(int i = 0; i < arr.Length; i++){
            var menor = FindLowestValue(arrToList);
            newArr.Add(arrToList[menor]);
            arrToList.RemoveAt(menor);
        }
        return newArr.ToArray();
    }

    public static int[] QuickSort(int[] arr)
    {
        if (arr.Length < 2)
        {
            return arr;
        }
        else
        {
            int pivo = arr[arr.Length /2 ];
            List<int> menores = [];
            List<int> maiores = [];
            for (int i = 0; i < arr.Length ; i++)
            {
                if (arr[i] < pivo)
                {
                    menores.Add(arr[i]);
                }
                else if (arr[i] > pivo)
                {
                    maiores.Add(arr[i]);
                }
                
            }

            List<int> newArr = [];
            newArr.AddRange(QuickSort(menores.ToArray()));
            newArr.AddRange(pivo);
            newArr.AddRange(QuickSort(maiores.ToArray()));
            return newArr.ToArray();
        }
    }
}