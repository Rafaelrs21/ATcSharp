using Negocios.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios.Model.Interfaces.Services
{
    public interface IAmigosService
    {
        List<Amigos> SearchAmigo(string parametroBusca);
        void AddAmigo(Amigos amigo);
        void DeleteAmigo(Amigos amigo);
        void UpdateAmigo(Amigos amigo);
        int RetornarId();
        List<Amigos> GetAniversariantesDia();
        string CalcularDiasParaAniversario(Amigos amigos);
    }
}
