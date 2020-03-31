using Infraestrutura;
using Negocios.Model.Entities;
using Negocios.Model.Interfaces.Repositories;
using Negocios.Model.Interfaces.Services;
using Negocios.Service.Factory;
using System;
using System.Collections.Generic;

namespace Negocios.Service
{
    public class AmigosService : IAmigosService
    {
        readonly IAmigosRepository repository = AmigosRepositoryFactory.Create();

        public void AddAmigo(Amigos amigo)
        {
            repository.AddAmigo(amigo);

        }

        public void DeleteAmigo(Amigos amigo)
        {
            repository.DeleteAmigo(amigo);
        }

        public List<Amigos> SearchAmigo(string parametroBusca)
        {
            return repository.SearchAmigo(parametroBusca);
        }

        public void UpdateAmigo(Amigos amigo)
        {
            repository.UpdateAmigo(amigo);

        }

         public int RetornarId()
         {
            int ultimoId = 0;
            var listaAmigo = repository.GetAll();

             for (int i = 0; i < listaAmigo.Count; i++)
             {
                 ultimoId = listaAmigo[i].IdAmigo;
             }
        
             return ultimoId + 1;
         }

        public List<Amigos> GetAniversariantesDia()
        {
            return repository.GetAniversariantesDia();
        }

        public string CalcularDiasParaAniversario(Amigos amigos)
        {
            var dataAtual = DateTime.Now;

            var diaNascimento = amigos.DataNascimentoAmigo.Day;
            var MesNascimento = amigos.DataNascimentoAmigo.Month;
            var AnoAtual = dataAtual.Year;

            DateTime dataAniversarioAnoAtual = new DateTime(AnoAtual, MesNascimento, diaNascimento);

            if (diaNascimento == dataAtual.Day & MesNascimento == dataAtual.Month)
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
    }
}
