namespace algoritmos;

public class Grafos
{
    public static void ProcuraVizinhoVendeManga()
    {
        Dictionary<string, List<string>> grafo = new Dictionary<string, List<string>>();

        grafo["Osmar"] = ["Alice", "Bob", "Claire"];
        grafo["Bob"] = ["Anuj", "Peggy"];
        grafo["Alice"] = ["Peggy"];
        grafo["Claire"] = ["Thom", "Jonny"];
        grafo["Anuj"] = [];
        grafo["Peggy"] = [];
        grafo["Thom"] = [];
        grafo["Jonny"] = [];

        var fila = new Queue<string>();
        fila.Enqueue("Osmar");
        HashSet<string> visitados = new HashSet<string>();
        while (fila.Count > 0)
        {
            string pessoa = fila.Dequeue();
            if (!visitados.Contains(pessoa))
            {
                if (VerificaSeVendeManga(pessoa))
                {
                    Console.WriteLine($"{pessoa} vende manga!");
                    return;
                }

                visitados.Add(pessoa);
                foreach(var vizinho in grafo[pessoa])
                {
                    fila.Enqueue(vizinho);
                }
            }

        }
    }


    public static bool VerificaSeVendeManga(string nome)
    {
        return nome.EndsWith("m");
    }
}