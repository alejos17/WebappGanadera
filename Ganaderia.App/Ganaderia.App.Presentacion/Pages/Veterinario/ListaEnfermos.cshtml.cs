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
    public class ListaEnfermosModel : PageModel
    {
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());
        private static IRepositorioAtencionEjemplar _repoAtencionEjemplar = new RepositorioAtencionEjemplar(new Persistencia.AppContext());
        public IEnumerable<Ejemplar> ejemplaresenfermos { get; private set; }
        public IEnumerable<AtencionEjemplar> atenciones { get; private set;}
        public int idEjemplar { get; private set; }
        public void OnGet()
        {
            ejemplaresenfermos = _repoEjemplar.GetEjemplarEnfermo();
        }

        public void OnPostDelAtencion(int idAtencion)
        {
            if(idAtencion >0)  //Si es mayor a cero es porque existe
            {
                _repoAtencionEjemplar.DeleteAtencion(idAtencion);
            }
            ejemplaresenfermos = _repoEjemplar.GetEjemplarEnfermo();
            atenciones = _repoAtencionEjemplar.GetAtencionxEjemplar(idEjemplar);
        }

        public void OnPostLista(int idEjemplar)
        {
            ejemplaresenfermos = _repoEjemplar.GetEjemplarEnfermo();
            atenciones = _repoAtencionEjemplar.GetAtencionxEjemplar(idEjemplar);
        }

    }
}
