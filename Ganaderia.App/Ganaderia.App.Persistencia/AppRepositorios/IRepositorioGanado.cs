using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioGanado
    {
        IEnumerable<Ganado> GetAllGanado();

        Ganado AddGanado(Ganado ganado);

        Ganado UpdateGanado(Ganado ganado);

        void DeleteGanado(int idGanado);

        Ganado GetGanado(int idGanado);
    }
}