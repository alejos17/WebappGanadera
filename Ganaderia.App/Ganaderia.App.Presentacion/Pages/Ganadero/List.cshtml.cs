using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Presentacion.Pages
{
    public class ListModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());

        public IEnumerable<Ganadero> ganaderos { get; private set; }
        
        public void OnGet()
        {
            ganaderos = _repoGanadero.GetAllGanaderos();
        }

        public void OnPostDel(int idGanadero)
        {
            if(idGanadero >0)  //Si es mayor a cero es porque existe
            {
                _repoGanadero.DeleteGanadero(idGanadero);
            }
            ganaderos = _repoGanadero.GetAllGanaderos();
        }

    }
}
