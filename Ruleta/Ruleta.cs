using System;
using System.Collections;

namespace Ruleta
{
    class Ruleta
    {
        private int bank;
        private Random r;
        private Stack zasobnik = new Stack();

        public Ruleta(int bank, Random r)
        {
            this.bank = bank;
            this.r = r;
            zasobnik.Push("Stav banku: $" + bank);
        }

        public void ZadajStavku()
        {
            int typ;
            string vstup;
            int stavka;
            
            do
            {
                Console.WriteLine("\nNova stavka (cervena, cierna, parne (sude), neparne (liche), cislo: 0 - 36, ukoncenie hry: 'koniec', prehranie hry od zaciatku: 'replay')" +
                    "\n------------------------------------------------------------------------------------------------------------------------------------------");
                vstup = Console.ReadLine();

            } while (!SkontrolujVstup(vstup, out typ));
            
            zasobnik.Push("Stavka na: '" + vstup + "' v case " + DateTime.Now.ToString("HH:mm:ss"));

            do
            {
                Console.WriteLine("Zadaj sumu stavky v $");
                stavka = int.Parse(Console.ReadLine());

                if (bank < stavka) Console.WriteLine("Nedostatok penazi v banku\n");
               
            } while (bank < stavka);

            zasobnik.Push("Hodnota stavky: $" + stavka);

            bool vyhra = Stavit(vstup, typ);
            
            if (vyhra)
            {
                Console.WriteLine("VYHRA!");
                zasobnik.Push("Vysledok: VYHRA");
                bank += stavka;
                Console.WriteLine("Stav banku: ${0}", bank);
            }
            else
            {
                Console.WriteLine("PREHRA");
                zasobnik.Push("Vysledok: PREHRA");
                bank -= stavka;
                Console.WriteLine("Stav banku: ${0}", bank);
            }

            zasobnik.Push("Stav banku: $" + bank);

            if (bank == 0)
            {
                Console.WriteLine("Z banku boli vycerpane vsetky peniaze.\nHRA BUDE UKONCENA.");
                System.Threading.Thread.Sleep(4000);
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
                    Console.WriteLine("Neplatny vstup. Skuste to znovu.\n");
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
            else if (vstup == "koniec")
            {
                Console.WriteLine("HRA BUDE UKONCENA.");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
                return false;
            }
            else if (vstup == "replay")
            {
                while (zasobnik.Count > 0)
                {
                    Console.WriteLine(zasobnik.Pop().ToString());
                }
                return false;
            }
            else
            {
                Console.WriteLine("Neplatny vstup. Skuste to znovu.\n");
                return false;
            }
        }

    }
}
