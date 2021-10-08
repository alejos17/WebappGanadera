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
    public class VacunaModel : PageModel
    {
        private static IRepositorioVacuna _repoVacuna = new RepositorioVacuna(new Persistencia.AppContext());

        public IEnumerable<Vacuna> vacunas { get; private set; }
        
        public void OnGet()
        {
            vacunas = _repoVacuna.GetAllVacunas();
        }
    }
}
