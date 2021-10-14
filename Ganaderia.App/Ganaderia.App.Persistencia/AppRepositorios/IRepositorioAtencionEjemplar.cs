using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioAtencionEjemplar
    {
        IEnumerable<AtencionEjemplar> GetAllAtenciones();

        AtencionEjemplar AddAtencion(AtencionEjemplar atencion);

        AtencionEjemplar UpdateAtencion(AtencionEjemplar atencion);

        void DeleteAtencion(int idAtencion);

        AtencionEjemplar GetAtencion(int idAtencion);

        IEnumerable<AtencionEjemplar> GetAtencionxEjemplar(int idEjemplar);

        
    }
}