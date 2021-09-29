using System.Collections.Generic;
using System.Linq;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class RepositorioGanado:IRepositorioGanado
    {

        private readonly AppContext _appContext;

        public RepositorioGanado(AppContext appContext)
        {
            _appContext=appContext;
        }
        
        Ganado IRepositorioGanado.AddGanado(Ganado ganado)
        {
            var ganadoAdicionado= _appContext.Ganado.Add(ganado);
            _appContext.SaveChanges();
            return ganadoAdicionado.Entity;
        }

        void IRepositorioGanado.DeleteGanado(int idGanado)
        {
            var ganadoEncontrado= _appContext.Ganado.FirstOrDefault(g => g.Id==idGanado);
            if(ganadoEncontrado==null)
                return;
            _appContext.Ganado.Remove(ganadoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Ganado> IRepositorioGanado.GetAllGanado()
        {
            return _appContext.Ganado;
        }

        Ganado IRepositorioGanado.GetGanado(int idGanado)
        {
            return _appContext.Ganado.FirstOrDefault(g => g.Id==idGanado);
        }
        
        Ganado IRepositorioGanado.UpdateGanado(Ganado ganado)
        {
            var ganadoEncontrado= _appContext.Ganado.FirstOrDefault(g => g.Id==ganado.Id);
            if (ganadoEncontrado!=null)
            {
                ganadoEncontrado.idGanadero=ganado.idGanadero;
                ganadoEncontrado.raza=ganado.raza;
                ganadoEncontrado.fechaIngreso=ganado.fechaIngreso;
                ganadoEncontrado.cantidad=ganado.cantidad;

                _appContext.SaveChanges();
            }

            return ganadoEncontrado;
        }
    }
}