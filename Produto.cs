using System;

public class Produto
{
    public string Nome { get; set; }
    public DateTime DataVali { get; set; }  
    public string Tipo { get; set; }        
    public string Marca { get; set; }       
    public int Quantidade { get; set; }     
    public double Valor { get; set; }      

    public Produto(string nome, DateTime dataVali, string tipo, string marca, int quantidade, double valor)
    {
        Nome = nome;
        DataVali = dataVali;
        Tipo = tipo;
        Marca = marca;
        Quantidade = quantidade;
        Valor = valor;
    }

    public void ExibirDadosProduto()
    {
        Console.WriteLine($"Nome: {Nome}, Tipo: {Tipo}, Marca: {Marca}, Quantidade: {Quantidade}, Valor: R${Valor:F2}, Data de Validade: {DataVali.ToShortDateString()}");
    }

    public double CalcularValorTotal()
    {
        return Quantidade * Valor;
    }

    public void AtualizarQuantidade(int novaQuantidade)
    {
        Quantidade = novaQuantidade;
        Console.WriteLine($"Quantidade do produto {Nome} atualizada para {Quantidade}.");
    }

    public void AtualizarValor(double novoValor)
    {
        Valor = novoValor;
        Console.WriteLine($"Valor do produto {Nome} atualizado para R${Valor:F2}.");
    }

    public bool VerificarValidade()
    {
        return DataVali >= DateTime.Now;
    }
}
