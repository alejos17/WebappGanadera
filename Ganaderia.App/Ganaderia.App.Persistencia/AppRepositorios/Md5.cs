using System.Collections.Generic;
using System.Linq;
using Ganaderia.App.Dominio;
using System.Security.Cryptography;

namespace Ganaderia.App.Persistencia
{
    public class Md5:IMd5
    {

        public Md5()
        {
        }
        
        string IMd5.ObtenerMD5(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string hash = s.ToString();
            return hash;
        }
    }
}