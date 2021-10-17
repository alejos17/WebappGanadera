using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IMd5
    {
        string ObtenerMD5(string input);
    }
}