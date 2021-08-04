using RTRPG_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RTRPG_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            GM manager = GM.Instance;
            Editor editor = new Editor(manager);
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            
            //editor.CLI();

            Game.Play();
            
            Console.ReadKey();
        }
    }
}
