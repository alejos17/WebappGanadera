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

        public int valor { get; private set; }
        
        public void OnGet(int idGanado)
        {
            ganado = _repoGanado.GetAllGanado();
            ejemplares = _repoEjemplar.GetEjemplarxGanado(idGanado);
            
        }
    }
}
