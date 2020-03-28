
using Negocios.Model.Interfaces.Services;
using Negocios.Service;


namespace Negocios.Service.Factory
{
    public class AmigosServicesFactory
    {
        public static IAmigosService Create()
        {
            return new AmigosService();
        }
    }
}
