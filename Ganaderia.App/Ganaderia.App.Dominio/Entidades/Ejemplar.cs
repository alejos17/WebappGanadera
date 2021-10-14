using System;
using System.ComponentModel.DataAnnotations;
namespace Ganaderia.App.Dominio
{

    public class Ejemplar
    {
        public int Id { get; set; }
        [Required]
        public int idGanado { get; set;}
        [Required, StringLength(50)]
        public string fechaCompra { get; set; }
        public string fechaVacuna { get; set; }
        [Required, StringLength(50)]
        public string observaciones { get; set; }
        [Required, StringLength(50)]
        public string estadoSalud { get; set; }
        
    }

}