using Negocios;
using Negocios.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios.Model.Interfaces.Repositories
{
    public interface IAmigosRepository
    {
        List<Amigos> SearchAmigo(string parametroBusca);
        void AddAmigo(Amigos amigo);
        void DeleteAmigo(Amigos amigo);
        void UpdateAmigo(Amigos amigo);
        List<Amigos> GetAll();
        List<Amigos> GetAniversariantesDia();

    }
}
