using System;
using System.Collections.Generic;
using System.Text;

namespace searchFight
{
    public class Extractor
    {
        public string extract(string todo, string prefijo, string sufijo)
        {
            var inicio = todo.IndexOf(prefijo) + prefijo.Length;
            var len = (todo.IndexOf(sufijo) - inicio);
            return  todo.Substring(inicio, len) ;
        }
    }
}
