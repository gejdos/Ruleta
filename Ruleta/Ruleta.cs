﻿using System;
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
            Console.WriteLine("Zadaj typ stavky:\n");
            string vstup = Console.ReadLine();

            Console.WriteLine("Zadaj sumu stavky");
            int stavka = int.Parse(Console.ReadLine());

            //if (!SkontrolujVstup(vstup, out bool jeCislo)) return;

            //if (jeCislo)
            //{
            //    Console.WriteLine(StavkaNaCislo(vstup));
            //}
            //else
            //{
            //    Console.WriteLine(StavkaNaFarbu(vstup));
            //}




        }
        
        //private int ZmenaBanku()
        //{

        //}

        //private bool Stavka(string vstup, int typStavky)
        //{
        //    switch (typStavky)
        //    {
        //        case 1:
        //            return (r.Next(37) == int.Parse(vstup));  
        //        case 2:
        //            int cisloFarby = (vstup == "cierna") ? 1 : 0;
        //            return (r.Next(2) == cisloFarby);
        //        case 3:
        //            int parne = (vstup == "parne") ? 1 : 0;
        //            return (int.Parse(vstup) % 2 == 0);



        //        default:
        //            break;
        //    }

         
        //}

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
