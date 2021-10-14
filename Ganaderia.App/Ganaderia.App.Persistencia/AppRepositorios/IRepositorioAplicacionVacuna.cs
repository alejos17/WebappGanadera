using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioAplicacionVacuna
    {
        IEnumerable<AplicacionVacuna> GetAllAplicacionVacunas();

        AplicacionVacuna AddAplicacionVacuna(AplicacionVacuna aplicacionVacuna);

        AplicacionVacuna UpdateAplicacionVacuna(AplicacionVacuna aplicacionVacuna);

        void DeleteAplicacionVacuna(int idAplicacionVacuna);

        AplicacionVacuna GetAplicacionVacuna(int idAplicacionVacuna);

        IEnumerable<AplicacionVacuna> GetAplicacionVacunaxEjemplar(int idEjemplar);

        
    }
}