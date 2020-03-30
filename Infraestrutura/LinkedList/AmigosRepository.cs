using Negocios.Model.Entities;
using Negocios.Model.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Infraestrutura.LinkedList
{
    public class AmigosRepository : IAmigosRepository
    {
        private static LinkedList<Amigos> amigosLista = new LinkedList<Amigos>();
        private const string LOCAL_ARQUIVO = @"C:\Users\Guilherme\Documents\GitHub\ATcSharp\App-Data\Lista_Amigos.txt";

        public AmigosRepository()
        {
            CarregarAmigosParaSistema();
        }

        private void CarregarAmigosParaSistema()
        {
            if (!File.Exists(LOCAL_ARQUIVO))
                File.Create(LOCAL_ARQUIVO).Close();

            var linhas = File.ReadAllLines(LOCAL_ARQUIVO);

            foreach (var linha in linhas)
            {
                var info = linha.Split(",");

                var id = int.Parse(info[0]);
                var nome = info[1];
                var sobrenome = info[2];
                var dataNascimento = DateTime.Parse(info[3]);

                var carro = new Amigos(id, nome, sobrenome, dataNascimento);

                amigosLista.AddLast(carro);
            }
        }

        public void AddAmigo(Amigos amigo)
        {

            amigosLista.AddLast(amigo);
            File.WriteAllLines(LOCAL_ARQUIVO, amigosLista.Select(amigo => amigo.ToString()));
        }

        public void DeleteAmigo(Amigos amigo)
        {
            amigosLista.Remove(amigo);

            File.WriteAllLines(LOCAL_ARQUIVO, amigosLista.Select(amigo => amigo.ToString()));
        }

        public List<Amigos> SearchAmigo(string parametroBusca)
        {
            return amigosLista.Where(x => (x.NomeAmigo.ToUpper().Contains(parametroBusca.ToUpper())) || 
            (x.SobrenomeAmigo.ToUpper().Contains(parametroBusca.ToUpper()))).ToList();

        }

        public void UpdateAmigo(Amigos amigo)
        {
            var amigoIndex = amigosLista.FirstOrDefault(x => x.IdAmigo == amigo.IdAmigo);
            amigosLista.Find(amigoIndex).Value = amigo;

            File.WriteAllLines(LOCAL_ARQUIVO, amigosLista.Select(amigo => amigo.ToString()));
        }

        public List<Amigos> GetAll()
        {
            return amigosLista.ToList();

        }

        public List<Amigos> GetAniversariantesDia()
        {
            return amigosLista.Where(x => (x.DataNascimentoAmigo.Month.Equals(DateTime.Now.Month)) && 
            (x.DataNascimentoAmigo.Day.Equals(DateTime.Now.Day))).ToList();

        }

    }
}
