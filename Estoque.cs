public class Estoque : Produto
{
    public int QuantidadeEmEstoque { get; set; }
    public int Capacidade { get; set; }

    public Estoque(string nome, DateTime dataVali, string tipo, string marca, int quantidade, double valor, int quantidadeEmEstoque, int capacidade)
        : base(nome, dataVali, tipo, marca, quantidade, valor)
    {
        QuantidadeEmEstoque = quantidadeEmEstoque;
        Capacidade = capacidade;
    }

    public void ExibirDadosEstoque()
    {
        Console.WriteLine($"Estoque do produto: {Nome}");
        Console.WriteLine($"Quantidade em estoque: {QuantidadeEmEstoque}");
        Console.WriteLine($"Capacidade do estoque: {Capacidade}");
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (QuantidadeEmEstoque + quantidade <= Capacidade)
        {
            QuantidadeEmEstoque += quantidade;
            Console.WriteLine($"Estoque atualizado. Quantidade atual: {QuantidadeEmEstoque}");
        }
        else
        {
            Console.WriteLine("Não é possível adicionar mais unidades, capacidade máxima atingida.");
        }
    }

    public void ReduzirEstoque(int quantidade)
    {
        if (QuantidadeEmEstoque >= quantidade)
        {
            QuantidadeEmEstoque -= quantidade;
            Console.WriteLine($"Estoque atualizado. Quantidade atual: {QuantidadeEmEstoque}");
        }
        else
        {
            Console.WriteLine("Quantidade insuficiente no estoque.");
        }
    }

    public void VerificarCapacidade()
    {
        Console.WriteLine($"Capacidade total do estoque: {Capacidade}");
        Console.WriteLine($"Quantidade disponível no estoque: {QuantidadeEmEstoque}");
    }
}