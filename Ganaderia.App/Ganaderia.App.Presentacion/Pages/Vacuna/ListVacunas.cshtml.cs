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
    public class ListVacunasModel : PageModel
    {
        private static IRepositorioVacuna _repoVacuna= new RepositorioVacuna(new Persistencia.AppContext());

        public IEnumerable<Vacuna> vacunas { get; private set; }
        
        public void OnGet()
        {
            vacunas = _repoVacuna.GetAllVacunas();
        }

        public void OnPostDel(int idVacuna)
        {
            if(idVacuna >0)  //Si es mayor a cero es porque existe
            {
                _repoVacuna.DeleteVacuna(idVacuna);
            }
            vacunas = _repoVacuna.GetAllVacunas();
        }


    }       
}
