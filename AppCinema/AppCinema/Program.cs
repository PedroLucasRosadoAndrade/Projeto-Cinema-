using AppCinema.Models;
using Escola;
using System;
using System.Runtime.CompilerServices;

namespace Escola
{

    class Program
    {
        static void Main(string[] args)
        {
           


            List<Filme> filmes = new List<Filme>();
            List<Ingresso>ingressos = new List<Ingresso>();
            

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Cadastrar Filmes");
                Console.WriteLine("1 - Cadastrar Filme");
                Console.WriteLine("2 - Listar Filmes");
                Console.WriteLine("3 - Verificar Restrição de Idade");
                Console.WriteLine("4 - Cadastrar Ingresso");
                Console.WriteLine("5 - Listar Ingressos");
                Console.WriteLine("6 - Comprar Ingresso");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // chamando o metodo construtor 
                        Filme filmeObri = new Filme("", "", "", 0);
                        filmeObri.CadastrarFilme();
                       
                        filmes.Add(filmeObri); 
                 
                        break;

                    case "2":
                        ListarFilmes(filmes);
                        break;

                   case "3":
                        VerificarRestricaoDeIdade(filmes);
                        break;
                   case "4":
                        // chamando o metodo construtor 
                        Console.WriteLine("consute os filmes disponiveis");
                        ListarFilmes(filmes);
                        Ingresso ingreso = new Ingresso(0, "", "");
                        ingreso.CadastrarIngresso();

                        ingressos.Add(ingreso);

                        break;

                    case "5":
                        ListIngresso(ingressos);
                        break;

                    case "6":
                        Console.Write("Digite seu nome: ");
                        string nomeCliente = Console.ReadLine();

                        Console.Write("Digite sua idade: ");
                        int idadeCliente;
                        while (!int.TryParse(Console.ReadLine(), out idadeCliente))
                        {
                            Console.Write("Digite uma idade válida: ");
                        }

                        Cliente cliente = new Cliente(nomeCliente, idadeCliente, "");
                        cliente.ComprarIngresso(filmes);
                        break;

                    case "0":
                        Console.WriteLine("Fechando...");
                        return;

                    default:
                        Console.WriteLine("Tente novamente!");
                        break;
                }
            }
        }

        static void ListarFilmes(List<Filme> filmes)
        {
            Console.WriteLine("\n Listagem de Filmes");

            if (filmes.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
            }
            else
            {
                foreach (var filme in filmes)
                {
                    // para exibir o filme
                    filme.ExibirFilme();
                    Console.WriteLine("\n");
                }
            }

        }

        static void ListIngresso(List<Ingresso> ingressos)
        {
            Console.WriteLine("\n Listagem dos ingressos");

            if (ingressos.Count == 0)
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum ingresso cadastrado.");
            }
            else
            {
                foreach (var ingresso in ingressos)
                {
                    // exibe os ingressos
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    ingresso.ExibirIngresso();
                    Console.WriteLine("\n");
                }
            }

        }

        static void VerificarRestricaoDeIdade(List<Filme> filmes)
        {
            if (filmes.Count == 0)
            {
                Console.WriteLine("\n Nenhum filme cadastrado. Cadastre filmes primeiro.");
                return;
            }

            Console.WriteLine("\n Verificar Restrição de Idade");
            Console.Write("Digite o nome do filme: ");
            string nomeFilme = Console.ReadLine();

            // Procura o filme na lista
            Filme filmeEncontrado = filmes.Find(f => f.Nome.Equals(nomeFilme, StringComparison.OrdinalIgnoreCase));

            if (filmeEncontrado == null)
            {
                Console.WriteLine("Filme não encontrado.");
                return;
            }

            Console.Write("Digite a idade da pessoa: ");
            int idade;
            while (!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.Write(" Digite uma idade valida!: ");
            }

            // Verifica a restrição de idade
            if (filmeEncontrado.CalcularRestricaoDeIdade(idade))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Você pode assistir o filme.");
                Console.WriteLine("\n");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você não pode assistir o filme.");
                Console.WriteLine("\n");

            }
        }
    }

}
