using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Presentacion.Pages
{
    public class ListaModel : PageModel
    {
        //Llamamos instancia del Repo Ejemplar para traer datos de la BD
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());
        private static IRepositorioGanado _repoGanado= new RepositorioGanado(new Persistencia.AppContext());

        //Lista de Ejemplares
        public IEnumerable<Ejemplar> ejemplares { get; private set; }

        public IEnumerable<Ganado> ganado { get; private set; }
        public int idGanado { get; private set; }
        
        public void OnGet()
        {
            ganado = _repoGanado.GetAllGanado();
        }

        public void OnPostLista(int idGanado)
        {
            ganado = _repoGanado.GetAllGanado();
            ejemplares = _repoEjemplar.GetEjemplarxGanado(idGanado);
        }

        //Para Eliminar un Lote de Ganado
        public void OnPostDel(int idGanado)
        {
            if(idGanado >0)  //Si es mayor a cero es porque existe
            {
                _repoGanado.DeleteGanado(idGanado);
            }
            ganado = _repoGanado.GetAllGanado();
        }

        public void OnPostDelEjemplar(int idEjemplar)
        {
            if(idEjemplar >0)  //Si es mayor a cero es porque existe
            {
                _repoEjemplar.DeleteEjemplar(idEjemplar);
            }
            ganado = _repoGanado.GetAllGanado();
            ejemplares = _repoEjemplar.GetEjemplarxGanado(idGanado);
        }
    }
}
