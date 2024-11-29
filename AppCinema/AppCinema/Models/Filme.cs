using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCinema.Models
{
    internal class Filme
    {
        public string Nome;
        private string DataLanc;
        private string DataFecha;
        public string Produtora;
        public int Classificacao;
        public string Idioma;
        public string Atores;


        // get obtem valor
        public string getNome()
        {
            return this.Nome;

        }
        // set colocar valor 
        public string setNome(string nomFil)
        {
            return this.Nome = nomFil;
        }

        public string getDataLan()
        {
            return this.DataLanc;

        }
        public string setDataLan(string datalanFil)
        {
            return this.DataLanc = datalanFil;
        }
        public string getDataFech()
        {
            return this.DataFecha;

        }
        public string setDataFech(string datafechFil)
        {
            return this.DataFecha = datafechFil;
        }
        public string getProd()
        {
            return this.Produtora;

        }
        public string setProd(string produFil)
        {
            return this.Produtora = produFil;
        }
        public int getClassi()
        {
            return this.Classificacao;

        }
        public int setClassi(int classFil)
        {
            return this.Classificacao = classFil;
        }
        public string getIdioma()
        {
            return this.Idioma;

        }
        public string setIdioma(string idioFil)
        {
            return this.Idioma = idioFil;
        }
        public string getAtores()
        {
            return this.Atores;

        }
        public string setAtores(string atoFil)
        {
            return this.Atores = atoFil;
        }

        public  Filme(string nomeFilm, string datalanFil, string datafechFil, int classiFil)
        {
            this.Nome = nomeFilm;
            this.DataLanc = datalanFil;
            this.DataFecha = datafechFil;
            this.Classificacao = classiFil;
            


        }
        public void CadastrarFilme()
        {

            Console.Write("Digite o nome do filme: ");
            Nome = Console.ReadLine();

            Console.Write("Digite a data que sera lançado o filme: ");
            DataLanc = Console.ReadLine();

            Console.Write("Digite a data que sera fechado o filme: ");
            DataFecha = Console.ReadLine();

            Console.Write("Digite a produtora do filme: ");
            Produtora = Console.ReadLine();

            Console.Write("Digite a classificação de idade do filme: ");
            Classificacao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o idioma do filme: ");
            Idioma = Console.ReadLine();

            Console.Write("Digite dois atores no minimo: ");
            Atores = Console.ReadLine();

            Console.WriteLine("\nFilme cadastrado com sucesso!");


        }
        public void ExibirFilme()
        {
            //Console.WriteLine("Listagem dos filmes");
            Console.WriteLine("\n");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Data de Lançamento: {DataLanc}");
            Console.WriteLine($"Data de Fechamento: {DataFecha}");
            Console.WriteLine($"Produtora: {Produtora}");
            Console.WriteLine($"Classificação: {Classificacao}");
            Console.WriteLine($"Idioma: {Idioma}");
            Console.WriteLine($"Atores: {Atores}");
            Console.WriteLine("\n");
        }

        public bool CalcularRestricaoDeIdade(int idade)
        {
            return idade >= Classificacao;
        }
    }
}
