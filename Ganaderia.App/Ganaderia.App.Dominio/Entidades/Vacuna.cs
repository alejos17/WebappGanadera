namespace Ganaderia.App.Dominio
{

    public class Vacuna
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Lote { get; set; }
        public string FechaCompra { get; set;}
        public string FechaVencimiento { get; set;}
        public int Existencia { get; set;}

    }
}