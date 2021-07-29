using RTRPG_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTRPG_CLI
{
    public class Editor
    {
        private GM __manager;

        public Editor(GM manager)
        {
            __manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public void CLI()
        {
            string input;
            List<string> args;
            while (true)
            {
                input = Console.ReadLine();

                args = input.Split().Where((string s) => !string.IsNullOrEmpty(s)).ToList();
                if (args.Count > 0 && args[0].ToLower() == "exit") {
                    break;
                }
            }
        }
    }
}
