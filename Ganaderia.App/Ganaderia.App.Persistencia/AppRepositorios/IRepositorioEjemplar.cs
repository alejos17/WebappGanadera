using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioEjemplar
    {
        /*Esta interfaz contiene la firma de los metodos a utilizar para gestionar
        los ejemplares, se implementan desde RepositorioEjemplar*/
        
        IEnumerable<Ejemplar> GetAllEjemplar();

        Ejemplar AddEjemplar(Ejemplar ejemplar);

        Ejemplar UpdateEjemplar(Ejemplar ejemplar);

        void DeleteEjemplar(int idEjemplar);

        Ejemplar GetEjemplar(int idEjemplar);

        IEnumerable<Ejemplar> GetEjemplarxGanado(int idGanado);
        IEnumerable<Ejemplar> GetEjemplarEnfermo();

        Ejemplar UpdateFechaVacuna(int idEjemplar, string fecha);
    }
}