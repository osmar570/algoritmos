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



    public static void Dijkstra()
    {
        // Implementação do algoritmo de Dijkstra
        Dictionary<string, Dictionary<string,int>> grafo = new Dictionary<string, Dictionary<string,int>>();

        // grafo["Livro"] = new Dictionary<string, int>{ {"LP", 5}, {"Poster",0} };
        // grafo["LP"] = new Dictionary<string, int>{ {"Baixo",15}, {"Bateria",20} };
        // grafo["Baixo"] = new Dictionary<string, int>{ {"Piano", 20} };
        // grafo["Poster"] = new Dictionary<string, int>{ {"Baixo",30}, {"Bateria", 35} };
        // grafo["Bateria"] = new Dictionary<string, int>{ {"Piano", 10} };
        // grafo["Piano"] = new Dictionary<string, int>{ };

        grafo["inicio"] = new Dictionary<string, int>{ };
        grafo["a"] = new Dictionary<string, int>{ };
        grafo["b"] = new Dictionary<string, int>{ };
        grafo["final"] = new Dictionary<string, int>{ };
        grafo["inicio"]["a"] = 6;
        grafo["inicio"]["b"] = 2;
        grafo["a"]["final"] = 1;
        grafo["b"]["a"] = 3;
        grafo["b"]["final"] = 5;

        Dictionary<string, int> custos = new Dictionary<string, int>();
        custos["a"] = 6;
        custos["b"] = 2;
        custos["final"] = int.MaxValue;
        // custos["LP"] = 5;
        // custos["Poster"] = 0;
        // custos["Baixo"] = int.MaxValue;
        // custos["Bateria"] = int.MaxValue;
        // custos["Piano"] = int.MaxValue;

        Dictionary<string, string> pais = new Dictionary<string, string>();
        pais["a"] = "inicio";
        pais["b"] = "inicio";
        pais["final"] = null;
        // pais["LP"] = "Livro";
        // pais["Poster"] = "Livro";
        // pais["Baixo"] = null;
        // pais["Bateria"] = null;
        // pais["Piano"] = null;

        HashSet<string> processados = new HashSet<string>();
        string nodo = ObterNodoMaisBarato(custos, processados);

        while(nodo != null)
        {
            int custo = custos[nodo];
            var vizinhos = grafo[nodo];

            foreach(var vizinho in vizinhos)
            {
                int novoCusto = custo + vizinho.Value;
                if (custos[vizinho.Key] > novoCusto)
                {
                    custos[vizinho.Key] = novoCusto;
                    pais[vizinho.Key] = nodo;
                }
            }
            processados.Add(nodo);
            nodo = ObterNodoMaisBarato(custos, processados);
        }

        // Console.WriteLine($"Custo do caminho mais barato para o destino: {custos["Piano"]}");
        Console.WriteLine($"Custo do caminho mais barato para o destino: {custos["final"]}");
        

        
    }

    private static string ObterNodoMaisBarato(Dictionary<string, int> custos, HashSet<string> processados)
    {
        string nodoMaisBarato = null;
        int custoMaisBarato = int.MaxValue;

        foreach (var nodo in custos)
        {
            if (!processados.Contains(nodo.Key) && nodo.Value < custoMaisBarato)
            {
                nodoMaisBarato = nodo.Key;
                custoMaisBarato = nodo.Value;
            }
        }

        return nodoMaisBarato;
    }
}