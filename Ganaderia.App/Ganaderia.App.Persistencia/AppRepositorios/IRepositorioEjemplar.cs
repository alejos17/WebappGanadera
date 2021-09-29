using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioEjemplar
    {
        IEnumerable<Ejemplar> GetAllEjemplar();

        Ejemplar AddEjemplar(Ejemplar ejemplar);

        Ejemplar UpdateEjemplar(Ejemplar ejemplar);

        void DeleteEjemplar(int idEjemplar);

        Ejemplar GetEjemplar(int idEjemplar);
    }
}