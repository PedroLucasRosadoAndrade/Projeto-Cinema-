using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCinema.Models
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Valor { get; set; }
        public string FormaPag { get; set; }
        public string DataPag { get; set; }
        public string HoraPag { get; set; }
        public string Banco { get; set; }

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

        public double getValor()
        {
            return this.Valor;

        }
        public double setValor(double valorCli)
        {
            return this.Valor = valorCli;
        }
    }
}
