using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioVacuna
    {
        IEnumerable<Vacuna> GetAllVacunas();

        Vacuna AddVacuna(Vacuna vacuna);

        Vacuna UpdateVacuna(Vacuna vacuna);

        void DeleteVacuna(int idVacuna);

        Vacuna GetVacuna(int idVacuna);
    }
}