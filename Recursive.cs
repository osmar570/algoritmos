namespace algoritmos;

public class Recursive
{
    public static int ContarItens(List<int>? lista)
    {
        if (!lista.Any())
        {
            return 0;
        }
        else
        {
            return 1 + ContarItens(lista.Skip(1).ToList());
        }
    }


}