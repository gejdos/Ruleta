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
        int stavka;
        Random r = new Random();

        public void ZacniHru()
        {
            Console.WriteLine("Zadaj farbu alebo cislo");
            string vstup = Console.ReadLine();

            Console.WriteLine("Zadaj sumu stavky");
            int stavka = int.Parse(Console.ReadLine());

            if (!SkontrolujVstup(vstup, out bool jeCislo)) return;

            if (jeCislo)
            {
                Console.WriteLine(StavkaNaCislo(vstup));
            }
            else
            {
                Console.WriteLine(StavkaNaFarbu(vstup));
            }




        }
        
        //private int ZmenaBanku()
        //{

        //}

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

        private bool SkontrolujVstup(string vstup, out bool naCislo, out bool naFarbu, out bool naParne)
        {
            int cislo;
            naCislo = false;
            naFarbu = false;
            naParne = false;

            if (int.TryParse(vstup, out cislo))
            {
                cislo = int.Parse(vstup);
                naCislo = true;

                if (cislo < 0 || cislo > 36)
                {
                    Console.WriteLine("Nespravny vstup");
                    return false;
                }

                return true;
            }
            else if (vstup == "cierna" || vstup == "cervena")
            {
                naFarbu = true;
                return true;
            }
            else if (vstup == "parne" || vstup == "neparne")
            {
                naParne = true;   
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
