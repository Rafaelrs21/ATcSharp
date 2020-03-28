using Infraestrutura;
using Negocios.Model.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios.Service.Factory
{
    public class AmigosRepositoryFactory
    {
        public static IAmigosRepository Create()
        {
            return new AmigosRepository();
        }

    }
}
