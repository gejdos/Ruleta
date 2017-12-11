using System;

namespace Ruleta
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Ruleta ruleta = new Ruleta(1000, r);

            while (true)
            {   
                ruleta.ZadajStavku();
            }
        }
    }
}
