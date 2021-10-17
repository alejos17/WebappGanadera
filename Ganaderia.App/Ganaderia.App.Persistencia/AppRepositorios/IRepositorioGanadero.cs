using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioGanadero
    {
        IEnumerable<Ganadero> GetAllGanaderos();

        Ganadero AddGanadero(Ganadero ganadero);

        Ganadero UpdateGanadero(Ganadero ganadero);

        void DeleteGanadero(int idGanadero);

        Ganadero GetGanadero(int idGanadero);

        Ganadero GetGanaderoxCorreo(string correo);
        Ganadero GetGanaderoxHash(string hash);
    }
}