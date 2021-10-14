using System.Collections.Generic;
using Ganaderia.App.Dominio;
using System.Linq;
namespace Ganaderia.App.Persistencia
{
    public class RepositorioAplicacionVacuna : IRepositorioAplicacionVacuna
    {
        private readonly AppContext _appContext;

        public RepositorioAplicacionVacuna(AppContext appContext)
        {
            _appContext=appContext;
        }
        AplicacionVacuna IRepositorioAplicacionVacuna.AddAplicacionVacuna(AplicacionVacuna aplicacionVacuna)
        {
            var aplicacionVacunaAdicionado= _appContext.AplicacionVacunas.Add(aplicacionVacuna);
            _appContext.SaveChanges();
            return aplicacionVacunaAdicionado.Entity;
        }

        void IRepositorioAplicacionVacuna.DeleteAplicacionVacuna(int idAplicacionVacuna)
        {
            var aplicacionVacunaEncontrado= _appContext.AplicacionVacunas.FirstOrDefault(a => a.Id==idAplicacionVacuna);
            if(aplicacionVacunaEncontrado==null)
                return;
            _appContext.AplicacionVacunas.Remove(aplicacionVacunaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<AplicacionVacuna> IRepositorioAplicacionVacuna.GetAllAplicacionVacunas()
        {
            return _appContext.AplicacionVacunas;
        }

        AplicacionVacuna IRepositorioAplicacionVacuna.GetAplicacionVacuna(int idAplicacionVacuna)
        {
            return _appContext.AplicacionVacunas.FirstOrDefault(a => a.Id==idAplicacionVacuna);
        }
        
        AplicacionVacuna IRepositorioAplicacionVacuna.UpdateAplicacionVacuna(AplicacionVacuna aplicacionVacuna)
        {
            var aplicacionVacunaEncontrado= _appContext.AplicacionVacunas.FirstOrDefault(a => a.Id==aplicacionVacuna.Id);
            if (aplicacionVacunaEncontrado!=null)
            {
                aplicacionVacunaEncontrado.idGanadero=aplicacionVacuna.idGanadero;
                aplicacionVacunaEncontrado.idVacuna=aplicacionVacuna.idVacuna;
                aplicacionVacunaEncontrado.idEjemplar=aplicacionVacuna.idEjemplar;
                aplicacionVacunaEncontrado.Fecha=aplicacionVacuna.Fecha;     

                _appContext.SaveChanges();
            }

            return aplicacionVacunaEncontrado;
        }
        
        IEnumerable<AplicacionVacuna> IRepositorioAplicacionVacuna.GetAplicacionVacunaxEjemplar(int idEjemplar)
        {
            return _appContext.AplicacionVacunas.Where(g => g.idEjemplar == idEjemplar);
        }

    }
}