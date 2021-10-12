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
    public class GanadoController : ControllerBase
    {
        private static IRepositorioGanado _repoGanado= new RepositorioGanado(new Persistencia.AppContext());
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());

        public IEnumerable<Ejemplar> ejemplares { get; private set; }

        //Recepcion de informacion desde backend
        [HttpGet]
        public IEnumerable<Ganado> Get()
        {
            var ganado = _repoGanado.GetAllGanado();
            return ganado;

        }

        //Enviar datos al backend
        //Debe ser un unico POST por controllador que envie todo....
        [HttpPost]
        public IEnumerable<Ejemplar> Post(int idGanado)
        {
            ejemplares = _repoEjemplar.GetEjemplarxGanado(idGanado);
            return ejemplares;
        }
    }
}
