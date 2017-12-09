using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    class Ruleta
    {
        private double bank;
        private Random r = new Random();

        public Ruleta(int bank)
        {
            this.bank = bank;
        }

        public void ZacniHru()
        {
            int typ;
            
            Console.WriteLine("Nova stavka (cervena, cierna, parne, neparne, cislo: 0 - 36, ukoncenie hry: 'koniec')\n-------------------------------------------------------------------");
            string vstup = Console.ReadLine();

            if (vstup == "koniec")
            {

                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
            }

            while (!SkontrolujVstup(vstup, out typ))
            {
                Console.WriteLine("Neplatny vstup. Skuste to znovu.\n");
                Console.WriteLine("Na co chcete stavit?");
                vstup = Console.ReadLine();
            }

            //if (!SkontrolujVstup(vstup, out int typ)) return;

            Console.WriteLine("Zadaj sumu stavky");
            double stavka = double.Parse(Console.ReadLine());

            while (bank < stavka)
            {
                Console.WriteLine("Nedostatok penazi v banku\n");
                Console.WriteLine("Zadaj sumu stavky");
                stavka = double.Parse(Console.ReadLine());
            }
            
            bool vyhra = Stavit(vstup, typ);

            if (vyhra)
            {
                Console.WriteLine("VYHRA!");
                bank += stavka;
                Console.WriteLine("Stav banku: {0}", bank);
            }
            else
            {
                Console.WriteLine("PREHRA");
                bank -= stavka;
                Console.WriteLine("Stav banku: {0}", bank);
            }

            if (bank == 0)
            {
                Console.WriteLine("Z banku boli vycerpane vsetky peniaze.\nHra bude ukoncena.");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(1);
                return;
            }
            
        }

        private bool Stavit(string vstup, int typStavky)
        {
            int nahodneCislo;

            switch (typStavky)
            {
                case 1:
                    nahodneCislo = r.Next(37);
                    Console.WriteLine("Padlo cislo {0}", nahodneCislo);
                    return (nahodneCislo == int.Parse(vstup));                    
                case 2:
                    int cisloFarby = (vstup == "cierna") ? 1 : 0;
                    return (r.Next(2) == cisloFarby);
                case 3:
                    int parne = (vstup == "parne") ? 0 : 1;
                    nahodneCislo = r.Next(37);
                    Console.WriteLine("Padlo cislo {0}", nahodneCislo);
                    return (nahodneCislo % 2 == parne);
                default:
                    return false;
            }
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
                return false;
            }
        }

    }
}
