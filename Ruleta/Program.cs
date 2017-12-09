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
            while (true)
            {
                Ruleta ruleta = new Ruleta();
                ruleta.ZacniHru();

                Console.ReadKey();
            }
        }
    }
}
