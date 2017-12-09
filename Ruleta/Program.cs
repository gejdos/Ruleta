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
            Ruleta ruleta = new Ruleta(5000);

            while (true)
            {   
                ruleta.ZacniHru();
                Console.WriteLine("");
            }
        }
    }
}
