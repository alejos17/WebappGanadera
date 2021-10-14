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
    public class EjemplarModel : PageModel
    {
        //Llamamos instancia del Repo Ejemplar para traer datos de la BD
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());
        private static IRepositorioGanado _repoGanado= new RepositorioGanado(new Persistencia.AppContext());
        [BindProperty]
        public Ejemplar ejemplar { get; set; }
        public IEnumerable<Ganado> Listaganado { get; private set; }
        public IEnumerable<Ejemplar> Listaejemplares { get; private set; }
        public int ejemplarId { get; set; }
        
        public IActionResult OnGet(int? ejemplarId)
        {
            if(ejemplarId.HasValue)
            {
                ejemplar = _repoEjemplar.GetEjemplar(ejemplarId.Value);
                Listaganado = _repoGanado.GetAllGanado();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
            }
            else
            {
                Listaganado = _repoGanado.GetAllGanado();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                ejemplar = new Ejemplar();
            }
            if(ejemplar==null)
            {
                return RedirectToPage("./Error");
            }else
            {
                return Page();
            }
        }

        //Para Editar o adicionar Ejemplares
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(ejemplar.Id>0)
            {
                Listaganado = _repoGanado.GetAllGanado();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                //ejemplar = _repoEjemplar.UpdateEjemplar(ejemplar);
            }
            else
            {
                Listaganado = _repoGanado.GetAllGanado();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                //_repoEjemplar.AddEjemplar(ejemplar);
            }

            return Page();
        }

        public void OnPostAdd(Ejemplar ejemplarUp)
        {
            Console.WriteLine("Ganado Raza: "+ejemplarUp.estadoSalud);
            if(ejemplarUp != null)
            {
                if(ejemplarUp.Id>0)
                {
                    _repoEjemplar.UpdateEjemplar(ejemplarUp);
                }
                else
                {
                    _repoEjemplar.AddEjemplar(ejemplarUp);
                }
            }
            Listaganado = _repoGanado.GetAllGanado();
            Listaejemplares = _repoEjemplar.GetAllEjemplar();

        }


    }
}
