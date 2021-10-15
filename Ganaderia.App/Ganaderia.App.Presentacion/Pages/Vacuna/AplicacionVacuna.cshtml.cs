
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
    public class AplicacionVacunaModel : PageModel
    {
        private static IRepositorioAplicacionVacuna _repoAplicacionVacuna = new RepositorioAplicacionVacuna(new Persistencia.AppContext());
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());

        private static IRepositorioVacuna _repoVacuna = new RepositorioVacuna(new Persistencia.AppContext());

        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());
        [BindProperty]
        public AplicacionVacuna aplicacion { get; set;}
        public Ejemplar ejemplar { get; set; }
        public IEnumerable<Ganadero> Listaganaderos { get; private set; }
        public IEnumerable<Vacuna> Listavacunas { get; private set; }
        public IEnumerable<Ejemplar> Listaejemplares { get; private set; }

        public int ejemplarId { get; set; }
        public string Mensaje { get; set; }
        public string Mensaje2 { get; set; }


        public IActionResult OnGet(int? aplicacionId)
        {
            if(aplicacionId.HasValue)
            {
                aplicacion = _repoAplicacionVacuna.GetAplicacionVacuna(aplicacionId.Value);
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                Listavacunas = _repoVacuna.GetAllVacunas();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
            }
            else
            {
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                Listavacunas = _repoVacuna.GetAllVacunas();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                aplicacion = new AplicacionVacuna();
            }

            if(aplicacion == null)
            {
                return RedirectToPage("./Error");
            }
            else{
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                return Page();
            }
            if(aplicacion.Id>0)
            {
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                Listavacunas = _repoVacuna.GetAllVacunas();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
            }
            else
            {
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                Listavacunas = _repoVacuna.GetAllVacunas();
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
            }

            return Page();
        }

        public void OnPostAdd(AplicacionVacuna aplicacionUp)
        {
            Console.WriteLine("Vacuna: "+aplicacionUp.idVacuna);
            Console.WriteLine("Ejemplar: "+aplicacionUp.idEjemplar);
            if(aplicacionUp != null)
            {
                if(aplicacionUp.Id>0)
                {
                    _repoAplicacionVacuna.UpdateAplicacionVacuna(aplicacionUp);
                    Mensaje = "*** Registro de Vacuna actualizada exitosamente ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
                else
                {
                    Console.WriteLine("Adicionar Aplicacion:");
                    _repoAplicacionVacuna.AddAplicacionVacuna(aplicacionUp);
                    _repoEjemplar.UpdateFechaVacuna(aplicacionUp.idEjemplar, aplicacionUp.Fecha);
                    Mensaje = "*** Registro de Vacuna creado exitosamente ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
            }
            Listaganaderos = _repoGanadero.GetAllGanaderos();
            Listavacunas = _repoVacuna.GetAllVacunas();
            Listaejemplares = _repoEjemplar.GetAllEjemplar();
        }


    }
}
