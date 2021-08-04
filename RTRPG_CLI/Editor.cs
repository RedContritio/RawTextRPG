using RTRPG_CORE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTRPG_CLI
{
    public class Editor
    {
        private GM __manager;

        private const string default_save_path = "./rtrpg.dat";

        public Editor(GM manager)
        {
            __manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public void CLI()
        {
            string input;
            List<string> args;
            Dictionary<string, Action<object[]>> methods = new Dictionary<string, Action<object[]>>();

            foreach (System.Reflection.MethodInfo m in typeof(Editor).GetMethods())
            {
                methods.Add(m.Name.ToLower(), (object[] os) => m.Invoke(this, os));
            }

            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                args = input.Split().Where((string s) => !string.IsNullOrEmpty(s)).ToList();

                if (args.Count <= 0)
                    continue;

                string method = args[0].ToLower();

                if (method == "exit")
                    goto END_CLI;

                if (methods.ContainsKey(method))
                {
                    methods[method].Invoke(new object[] { args });
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }
            }

        END_CLI:
            return;
        }

        public void List(List<string> args)
        {
            if (args.Count <= 1)
                Console.WriteLine("Must specify type (map or character)");
            else
            {
                switch (args[1].ToLower())
                {
                    case "map":
                    {
                        Console.WriteLine($"List all maps, size: {__manager.maps.Count}");
                        foreach (var obj in __manager.maps)
                        {
                            Console.WriteLine(obj.Serialize());
                        }
                        break;
                    }
                    case "character":
                    {
                        Console.WriteLine($"List all characters, size: {__manager.characters.Count}");
                        foreach (var obj in __manager.characters)
                        {
                            Console.WriteLine(obj.Serialize());
                        }
                        break;
                    }
                }
            }
        }

        public void Add(List<string> args)
        {
            if (args.Count <= 2)
                Console.WriteLine("Must specify type (map or character) and name, i.e. \"add map 真新镇\"");
            else
            {
                switch (args[1].ToLower())
                {
                    case "map":
                    {
                        var map = __manager.AddMap(args[2]);
                        Console.WriteLine($"Add map: \n {map.Serialize()}");
                        break;
                    }
                    case "character":
                    {
                        var character = __manager.AddCharacter(args[2]);
                        Console.WriteLine($"Add character: \n {character.Serialize()}");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"Invalid type \"{args[1]}\".");
                        break;
                    }
                }
            }
        }

        public void Load(List<string> args)
        {
            try
            {
                using (StreamReader sr = new StreamReader(default_save_path))
                {
                    __manager = Serialization.Deserialize<GM>(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Load failed.");
                Console.WriteLine(e.Message);
            }
        }
        public void Save(List<string> args)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(default_save_path))
                {
                    sw.Write(__manager.Serialize());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Save failed.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
