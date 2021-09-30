namespace Ganaderia.App.Dominio 
{
    public class AtencionEjemplar
    {
        public int Id { get; set; }
        public int idEjemplar { get; set; }
        public int idVeterinario { get; set;}
        public string Fecha { get; set;}
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}