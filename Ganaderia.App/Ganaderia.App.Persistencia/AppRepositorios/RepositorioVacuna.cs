using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class RepositorioVacuna:IRepositorioVacuna
    {
        private readonly AppContext _appContext;

        public RepositorioVacuna(AppContext appContext)
        {
            _appContext = appContext;
        }


        Vacuna IRepositorioVacuna.AddVacuna(Vacuna vacuna){
            var vacunaAdicionada = _appContext.Vacunas.Add(vacuna);
            _appContext.SaveChanges();
            return vacunaAdicionada.Entity;
        }
        
        void IRepositorioVacuna.DeleteVacuna(int idVacuna){
            var vacunaEncontrada = _appContext.Vacunas.FirstOrDefault(v => v.Id == idVacuna);
            if(vacunaEncontrada == null)
                return;
            _appContext.Vacunas.Remove(vacunaEncontrada);
            _appContext.SaveChanges();

        }

        IEnumerable<Vacuna> IRepositorioVacuna.GetAllVacunas(){
            return _appContext.Vacunas;
        }

        Vacuna IRepositorioVacuna.GetVacuna(int idVacuna)
        {
            return _appContext.Vacunas.FirstOrDefault(v => v.Id == idVacuna);
        }


        Vacuna IRepositorioVacuna.UpdateVacuna(Vacuna vacuna){
            var vacunaEncontrada = _appContext.Vacunas.FirstOrDefault(v => v.Id == vacuna.Id);
            if (vacunaEncontrada !=null){
                vacunaEncontrada.Nombre = vacuna.Nombre;
                vacunaEncontrada.Lote = vacuna.Lote;
                vacunaEncontrada.FechaCompra = vacuna.FechaCompra;
                vacunaEncontrada.FechaVencimiento = vacuna.FechaVencimiento;
                vacunaEncontrada.Existencia = vacuna.Existencia;


                _appContext.SaveChanges();
            }
            return vacunaEncontrada;
        }

    }
}