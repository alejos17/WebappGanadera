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
    public class VeterinarioModel : PageModel
    {
        private static IRepositorioVeterinario _repoVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());
        
        public IEnumerable<Veterinario> veterinarios { get; private set; }

        public void OnGet()
        {
            veterinarios = _repoVeterinario.GetAllVeterinarios();
        }
    }
}
