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
    public class ListaEjemplaresModel : PageModel
    {
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());
        private static IRepositorioAplicacionVacuna _repoAplicacionVacuna = new RepositorioAplicacionVacuna(new Persistencia.AppContext());

        public IEnumerable<Ejemplar> ejemplares { get; private set; }
        //Trae lista de aplicaciones de Vacuna por Ejemplar
        public IEnumerable<AplicacionVacuna> aplicaciones { get; private set; }
        public int idEjemplar { get; private set; }

        public void OnGet()
        {
            ejemplares = _repoEjemplar.GetAllEjemplar();
        }

        public void OnPostDelEjemplar(int idEjemplar)
        {
            if(idEjemplar >0)  //Si es mayor a cero es porque existe
            {
                _repoEjemplar.DeleteEjemplar(idEjemplar);
            }
            ejemplares = _repoEjemplar.GetAllEjemplar();
        }

        public void OnPostDelAplicacion(int idAplicacion)
        {
            if(idAplicacion >0)  //Si es mayor a cero es porque existe
            {
                _repoAplicacionVacuna.DeleteAplicacionVacuna(idAplicacion);
            }
            ejemplares = _repoEjemplar.GetAllEjemplar();
            aplicaciones = _repoAplicacionVacuna.GetAplicacionVacunaxEjemplar(idEjemplar);
        }

        public void OnPostLista(int idEjemplar)
        {
            ejemplares = _repoEjemplar.GetAllEjemplar();
            aplicaciones = _repoAplicacionVacuna.GetAplicacionVacunaxEjemplar(idEjemplar);
        }
    }
}
