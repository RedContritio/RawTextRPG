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
                Console.Write("> ");
                input = Console.ReadLine();

                args = input.Split().Where((string s) => !string.IsNullOrEmpty(s)).ToList();

                if (args.Count <= 0)
                    continue;

                string method = args[0].ToLower();
                switch (method)
                {
                    case "list":
                    {
                        this.List(args);
                        break;
                    }
                    case "exit":
                    {
                        goto END_CLI;
                    }
                }
            }

        END_CLI:
            return;
        }

        public void List(List<string> args)
        {
            if (args.Count <= 1)
                Console.WriteLine("Must specify list type (map or character)");
            else
            {
                switch (args[1].ToLower())
                {
                    case "map":
                    {
                        Console.WriteLine($"List all maps, size: {0}", __manager.maps.Count);
                        foreach (var obj in __manager.maps)
                        {
                            Console.WriteLine(obj.Serialize());
                        }
                        break;
                    }
                    case "character":
                    {
                        Console.WriteLine($"List all characters, size: {0}", __manager.characters.Count);
                        foreach (var obj in __manager.characters)
                        {
                            Console.WriteLine(obj.Serialize());
                        }
                        break;
                    }
                }
            }
        }
    }
}
