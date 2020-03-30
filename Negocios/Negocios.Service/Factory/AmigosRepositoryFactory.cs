using Negocios.Model.Interfaces.Repositories;
using System;

namespace Negocios.Service.Factory
{
    public class AmigosRepositoryFactory
    {
        public static IAmigosRepository Create()
        {
            return Create(TipoRepository.List);
        }

        public static IAmigosRepository Create(TipoRepository tipoRepository)
        {
            switch (tipoRepository)
            {
                case TipoRepository.List:
                    return new Infraestrutura.List.AmigosRepository();
                case TipoRepository.LinkedList:
                    return new Infraestrutura.LinkedList.AmigosRepository();
                default:
                    throw new NotImplementedException("Não existe repositório padrão!");
            }
        }

    }
}
