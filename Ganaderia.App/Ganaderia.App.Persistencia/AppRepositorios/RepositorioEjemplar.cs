using System.Collections.Generic;
using System.Linq;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class RepositorioEjemplar:IRepositorioEjemplar
    {

        private readonly AppContext _appContext;

        public RepositorioEjemplar(AppContext appContext)
        {
            _appContext=appContext;
        }

        Ejemplar IRepositorioEjemplar.AddEjemplar(Ejemplar ejemplar)
        {
            var ejemplarAdicionado= _appContext.Ejemplares.Add(ejemplar);
            _appContext.SaveChanges();
            return ejemplarAdicionado.Entity;
        }

        void IRepositorioEjemplar.DeleteEjemplar(int idEjemplar)
        {
            var ejemplarEncontrado= _appContext.Ejemplares.FirstOrDefault(g => g.Id==idEjemplar);
            if(ejemplarEncontrado==null)
                return;
            _appContext.Ejemplares.Remove(ejemplarEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Ejemplar> IRepositorioEjemplar.GetAllEjemplar()
        {
            return _appContext.Ejemplares;
        }

        Ejemplar IRepositorioEjemplar.GetEjemplar(int idEjemplar)
        {
            return _appContext.Ejemplares.FirstOrDefault(g => g.Id==idEjemplar);
        }
        
        Ejemplar IRepositorioEjemplar.UpdateEjemplar(Ejemplar ejemplar)
        {
            var ejemplarEncontrado= _appContext.Ejemplares.FirstOrDefault(g => g.Id==ejemplar.Id);
            if (ejemplarEncontrado!=null)
            {
                ejemplarEncontrado.idGanado=ejemplar.idGanado;
                ejemplarEncontrado.fechaCompra=ejemplar.fechaCompra;
                ejemplarEncontrado.fechaVacuna=ejemplar.fechaVacuna;
                ejemplarEncontrado.observaciones=ejemplar.observaciones;
                ejemplarEncontrado.estadoSalud=ejemplar.estadoSalud;
                
                _appContext.SaveChanges();
            }

            return ejemplarEncontrado;
        }
    }
}