using Negocios.Model.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace Negocios.Model.Entities
{
    public class Amigos
    {
        public int IdAmigo { get; private set; }
        public string NomeAmigo { get; private set; }
        public string SobrenomeAmigo { get; private set; }

        public DateTime DataNascimentoAmigo { get; private set; }

        public Amigos(int id,string nome, string sobrenome, DateTime dataNascimento)
        {
            IdAmigo = id;
            NomeAmigo = nome;
            SobrenomeAmigo = sobrenome;
            DataNascimentoAmigo = dataNascimento;
        }

        public string CalcularDiasParaAniversario()
        {
            var dataAtual = DateTime.Now;

            var diaNascimento = DataNascimentoAmigo.Day;
            var MesNascimento = DataNascimentoAmigo.Month;
            var AnoAtual = dataAtual.Year;

            DateTime dataAniversarioAnoAtual = new DateTime(AnoAtual, MesNascimento, diaNascimento);

            if(diaNascimento == dataAtual.Day & MesNascimento == dataAtual.Month)
            {
                return "Parabens, o aniversario do seu amigo é hoje";
            }
            else
            {
                if (dataAniversarioAnoAtual.CompareTo(dataAtual) < 0)
                {
                    return "Amigo já fez aniversario esse ano";
                }
                else if (dataAniversarioAnoAtual.CompareTo(DateTime.Now) > 0)
                {
                    return (dataAniversarioAnoAtual.AddDays(1).Subtract(dataAtual)).ToString("%d");
                }
            }

            return "Não foi possivel calcular!";
        }

        public override string ToString()
        {
            return $"{IdAmigo},{NomeAmigo},{SobrenomeAmigo},{(DateTime)DataNascimentoAmigo}";
        }

    }
}
