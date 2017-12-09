using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    class Ruleta
    {
        int bank = 1000;
        Random r = new Random();

        private int ZmenaBanku()
        {

        }

        private bool StavkaNaFarbu(string farba)
        {
            int cisloFarby = (farba == "cierna") ? 1 : 0;

            return (r.Next(2) == cisloFarby);
        }

        private bool StavkaNaCislo(string cislo)
        {
            return (r.Next(37) == int.Parse(cislo));
        }

        private bool Parne(string cislo)
        {
            return (int.Parse(cislo) % 2 == 0);
        }

    }
}
