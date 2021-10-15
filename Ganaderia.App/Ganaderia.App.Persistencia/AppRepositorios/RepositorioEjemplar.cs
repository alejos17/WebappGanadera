
using System;
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

        //Realiza consulta SQL donde indica la lista de ejemplares por ID de Ganado
        IEnumerable<Ejemplar> IRepositorioEjemplar.GetEjemplarxGanado(int idGanado)
        {
            return _appContext.Ejemplares.Where(g => g.idGanado == idGanado);
        }

        Ejemplar IRepositorioEjemplar.UpdateFechaVacuna(int idEjemplar, string fecha)
        {
            Console.WriteLine("ID: "+idEjemplar);
            Console.WriteLine("Fecha: "+fecha);
            var ejemplarEncontrado= _appContext.Ejemplares.FirstOrDefault(g => g.Id==idEjemplar);
            if (ejemplarEncontrado!=null)
            {
                Console.WriteLine("Encontrado: "+ ejemplarEncontrado.Id);
                ejemplarEncontrado.fechaVacuna=fecha;
                
                _appContext.SaveChanges();
            }
            return ejemplarEncontrado;
        }

    }
}