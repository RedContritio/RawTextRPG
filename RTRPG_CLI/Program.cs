using RTRPG_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTRPG_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.Name = "map0";

            Console.WriteLine(map.Name);
            Console.ReadKey();
        }
    }
}
