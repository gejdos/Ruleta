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

        public void ZacniHru()
        {
            Console.WriteLine("Na co chcete stavit?");
            string vstup = Console.ReadLine();

            Console.WriteLine("Zadaj sumu stavky");
            int stavka = int.Parse(Console.ReadLine());

            if (!SkontrolujVstup(vstup, out int typ)) return;

            bool vyhra = Stavit(vstup, typ);

            if (vyhra)
            {
                Console.WriteLine("Vyhra!");
                bank += stavka;
                Console.WriteLine("Stav banku: {0}", bank);
            }
            else
            {
                Console.WriteLine("Prehra");
                bank -= stavka;
                Console.WriteLine("Stav banku: {0}", bank);
            }
            

            
        }

        //private int ZmenaBanku()
        //{

        //}

        private bool Stavit(string vstup, int typStavky)
        {
            switch (typStavky)
            {
                case 1:
                    int nahod = r.Next(37);
                    Console.WriteLine(nahod);
                    return (nahod == int.Parse(vstup));                    
                case 2:
                    int cisloFarby = (vstup == "cierna") ? 1 : 0;
                    int nah = r.Next(2);
                    Console.WriteLine(cisloFarby + " " + nah);
                    return (nah == cisloFarby);
                case 3:
                    int parne = (vstup == "parne") ? 0 : 1;
                    int nahodC = r.Next(37);
                    Console.WriteLine(nahodC);
                    return (nahodC % 2 == parne);
                default:
                    return false;
            }
        }

        private bool StavkaNaCislo(string cislo)
        {
            return (r.Next(37) == int.Parse(cislo));
        }

        private bool Parne(string cislo)
        {
            return (int.Parse(cislo) % 2 == 0);
        }

        private bool SkontrolujVstup(string vstup, out int typStavky)
        {
            int cislo;
            typStavky = 0;

            if (int.TryParse(vstup, out cislo))
            {
                cislo = int.Parse(vstup);
                typStavky = 1;

                if (cislo < 0 || cislo > 36)
                {
                    Console.WriteLine("Nespravny vstup");
                    return false;
                }

                return true;
            }
            else if (vstup == "cierna" || vstup == "cervena")
            {
                typStavky = 2;
                return true;
            }
            else if (vstup == "parne" || vstup == "neparne")
            {
                typStavky = 3;
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
