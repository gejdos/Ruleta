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

        private bool SkontrolujVstup(string vstup)
        {
            int cislo;

            if (int.TryParse(vstup, out cislo))
            {
                cislo = int.Parse(vstup);

                if (cislo < 0 || cislo > 36)
                {
                    Console.WriteLine("Nespravny vstup");
                    return false;
                }

                return true;
            }
            else if (vstup == "cierna" || vstup == "cervena")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Nespravny vstup");
                return false;
            }
        }

    }
}
