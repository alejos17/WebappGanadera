using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EjemplarController : ControllerBase
    {
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());

        //Recepcion de informacion desde backend
        [HttpGet]
        public IEnumerable<Ejemplar> Get()
        {
            var ejemplares = _repoEjemplar.GetAllEjemplar();
            return ejemplares;

        }

        //Enviar datos al backend
        //Debe ser un unico POST por controllador que envie todo....
        [HttpPost]
        public ActionResult<string> Post(string metodo)
        {
            if (metodo.Equals("Agregar"))
            {
                
            } else if (metodo.Equals("Editar"))
            {
                
            }
            return Ok("Peticion recibida");
        }
    }
}
