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

        public override string ToString()
        {
            return $"{IdAmigo},{NomeAmigo},{SobrenomeAmigo},{(DateTime)DataNascimentoAmigo}";
        }

    }
}
