using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCinema.Models
{
    internal class Cliente : Filme
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        
        public string getNome()
        {
            return this.Nome;

        }
        public string setNome(string nomCli)
        {
            return this.Nome = nomCli;
        }

        public int getIdade()
        {
            return this.Idade;

        }
        public int setID(int idadeCli)
        {
            return this.Idade = idadeCli;
        }


        public Cliente(string nomeCli, int idadeCli, string nomeFilm) : base(nomeFilm)
        {
            this.Nome = nomeCli;
            this.Idade = idadeCli;
        }

        public void ComprarIngresso(List<Filme> filmes)
        {
            if (filmes.Count == 0)
            {
                Console.WriteLine("\n Nenhum filme cadastrado. Cadastre filmes primeiro.");
                return;
            }

            Console.WriteLine("\nComprar Ingresso");
            Console.WriteLine("consute os filmes disponiveis");
            ExibirFilme();
            Console.Write("Digite o nome do filme: ");
            string nomeFi = Console.ReadLine();

            // metodo para encontrar o filme
            Filme filmeEscolhido = filmes.Find(f => f.Nome.Equals(nomeFi, StringComparison.OrdinalIgnoreCase));

            if (filmeEscolhido == null)
            {
                Console.WriteLine("Filme não encontrado.");
                return;
            }

            // Verificar restrição de idade
            if (!filmeEscolhido.CalcularRestricaoDeIdade(this.Idade))
            {
                Console.WriteLine("Você não tem idade suficiente para assistir este filme.");
                return;
            }

            Console.Write($"Quantidade de ingressos disponíveis: {filmeEscolhido.QuantiIngre}\n");
            Console.Write("Digite a quantidade de ingressos que deseja comprar: ");
            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
            {
                Console.Write("Digite uma quantidade válida: ");
            }

            // Verificar disponibilidade de ingressos
            if (quantidade > filmeEscolhido.QuantiIngre)
            {
                Console.WriteLine("Ingressos insuficientes para atender sua solicitação.");
                return;
            }

            // Calcular valor total
            double valorTotal = quantidade * filmeEscolhido.Classificacao; // Supondo o valor do ingresso como Classificação para simplificar.
            Console.WriteLine($"Valor total da compra: R$ {valorTotal:F2}");

            // Atualizar quantidade de ingressos disponíveis
            filmeEscolhido.QuantiIngre -= quantidade;
            Console.WriteLine("Compra realizada com sucesso!");
        }
    }
}
