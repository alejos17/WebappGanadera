using System.Collections.Generic;
using Ganaderia.App.Dominio;
using System.Linq;
namespace Ganaderia.App.Persistencia
{
    public class RepositorioAtencionEjemplar : IRepositorioAtencionEjemplar
    {
        private readonly AppContext _appContext;

        public RepositorioAtencionEjemplar(AppContext appContext)
        {
            _appContext=appContext;
        }
        
        AtencionEjemplar IRepositorioAtencionEjemplar.AddAtencion(AtencionEjemplar atencion)
        {
            var atencionAdicionada= _appContext.Atenciones.Add(atencion);
            _appContext.SaveChanges();
            return atencionAdicionada.Entity;
        }

        void IRepositorioAtencionEjemplar.DeleteAtencion(int idAtencion)
        {
            var atencionEncontrada= _appContext.Atenciones.FirstOrDefault(a => a.Id==idAtencion);
            if(atencionEncontrada==null)
                return;
            _appContext.Atenciones.Remove(atencionEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<AtencionEjemplar> IRepositorioAtencionEjemplar.GetAllAtenciones()
        {
            return _appContext.Atenciones;
        }

        AtencionEjemplar IRepositorioAtencionEjemplar.GetAtencion(int idAtencion)
        {
            return _appContext.Atenciones.FirstOrDefault(a => a.Id==idAtencion);
        }
        
        AtencionEjemplar IRepositorioAtencionEjemplar.UpdateAtencion(AtencionEjemplar atencion)
        {
            var atencionEncontrada= _appContext.Atenciones.FirstOrDefault(a => a.Id==atencion.Id);
            if (atencionEncontrada!=null)
            {
                atencionEncontrada.idEjemplar=atencion.idEjemplar;
                atencionEncontrada.idVeterinario=atencion.idVeterinario;
                atencionEncontrada.Fecha=atencion.Fecha;
                atencionEncontrada.Observaciones=atencion.Observaciones;     
                atencionEncontrada.Estado=atencion.Estado;    

                _appContext.SaveChanges();
            }

            return atencionEncontrada;
        }
    }
}