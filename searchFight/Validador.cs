using System;
using System.Collections.Generic;
using System.Text;

namespace searchFight
{
    public class Validador
    {
        static public string limpia(string aLímpiar) {
            return aLímpiar.Trim().Replace(".", "").Replace(",", "");
        }
    }
}
