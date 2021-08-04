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
            try
            {
                Dictionary<string, Action> actions = new Dictionary<string, Action>() {
                    {"map", () => {
                        Console.WriteLine($"list all maps, count: {__manager.maps.Count}");
                        foreach (var obj in __manager.maps)
                        {
                            Console.WriteLine(obj.Serialize());
                        }
                        }
                    },
                    {"character", () => {
                        Console.WriteLine($"list all characters, count: {__manager.characters.Count}");
                        foreach (var obj in __manager.characters)
                        {
                            Console.WriteLine(obj.Serialize());
                        }
                        }
                    }
                };

                TypeSelect(args[1].ToLower(), actions);
            }
            catch (Exception e)
            {
                Console.WriteLine("Must specify type (map or character)");
                Console.WriteLine(e.Message);
            }
        }

        public void Add(List<string> args)
        {
            try
            {
                Dictionary<string, Action> actions = new Dictionary<string, Action>() {
                    {"map", () => {
                        var map = __manager.AddMap(args[2]);
                        Console.WriteLine($"added a map: \n {map.Serialize()}");
                        }
                    },
                    {"character", () => {
                        var character = __manager.AddCharacter(args[2]);
                        Console.WriteLine($"added a character: \n {character.Serialize()}");
                        }
                    }
                };

                TypeSelect(args[1].ToLower(), actions);
            }
            catch (Exception e)
            {
                Console.WriteLine("Must specify type (map or character) and name, i.e. \"add map 真新镇\"");
                Console.WriteLine(e.Message);
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
                Console.WriteLine("load failed.");
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
                Console.WriteLine("save failed.");
                Console.WriteLine(e.Message);
            }
        }

        public static void TypeSelect(string type, Dictionary<string, Action> actions)
        {
            string _type = type.ToLower();
            if (actions.ContainsKey(_type))
            {
                actions[_type].Invoke();
            }
            else
            {
                throw new KeyNotFoundException("Invalid operate type.");
            }
        }
    }
}
