using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
