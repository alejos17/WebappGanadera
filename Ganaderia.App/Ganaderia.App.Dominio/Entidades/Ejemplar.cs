namespace Ganaderia.App.Dominio
{

    public class Ejemplar
    {
        public int Id { get; set; }
        public int idGanado { get; set;}
        public string fechaCompra { get; set; }
        public string fechaVacuna { get; set; }
        public string observaciones { get; set; }
        public string estadoSalud { get; set; }
        
    }

}