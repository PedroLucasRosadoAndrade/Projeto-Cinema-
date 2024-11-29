using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCinema.Models
{
    internal class Ingresso
    {
        public double Valor { get; set; }
        public string Horario { get; set; }
        public string Data { get; set; }
        public string Tipo { get; set; }
        

        

        public double getValorn()
        {
            return this.Valor;

        }
        public double setValor(double valIng)
        {
            return this.Valor = valIng;
        }

        public string getHorario()
        {
            return this.Horario;

        }
        public string setHorario(string horIng)
        {
            return this.Horario = horIng;
        }

        public string getDate()
        {
            return this.Data;

        }
        public string setDate(string datIng)
        {
            return this.Data = datIng;
        }

        public string getTipo()
        {
            return this.Data;

        }
        public string setTipo(string tipIng)
        {
            return this.Tipo = tipIng;
        }

        //public int getQuat()
        //{
        //    return this.QuantiIngre;

        //}
        //public int setQuat(int quanIng)
        //{
        //    return this.QuantiIngre = quanIng;
        //}

        public Ingresso(double valIng, string horaIng, string datIng)
        {
            this.Valor = valIng;
            this.Horario = horaIng;
            this.Data = datIng;

        }

        public void CadastrarIngresso()
        {

            Console.Write("Digite o valor do ingresso: ");
            Valor = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o horario que sera o filme: ");
            Horario = Console.ReadLine();

            Console.Write("Digite a data que ira assitir o filme: ");
            Data = Console.ReadLine();

            Console.Write("Digite o tipo de ingresso: ");
            Tipo = Console.ReadLine();

            //Console.Write("Digite a quantidade de ingressos disponiveis: ");
            //QuantiIngre = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nFilme cadastrado com sucesso!");


        }
        public void ExibirIngresso()
        {
            //Console.WriteLine("Listagem dos filmes");
            Console.WriteLine("\n");
            Console.WriteLine($"Valor : {Valor}");
            Console.WriteLine($"Horario do filme: {Horario}");
            Console.WriteLine($"Data do filme: {Data}");
            Console.WriteLine($"tipo de ingresso: {Tipo}");
            //Console.WriteLine($"Quantidade de ingressos: {QuantiIngre}");
            
            Console.WriteLine("\n");
        }

        

    }
}
