using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RTRPG_CORE
{
    public class GM
    {
        [YamlMember(Alias = "地图", Order = 1)]
        public List<Map> maps = new List<Map>();
        
        [YamlMember(Alias = "角色", Order = 2)]
        public List<Character> characters = new List<Character>();

        public static GM Instance {
            get {
                if (__instance == null)
                    __instance = new GM();
                return __instance;
            }
            set {
                __instance = value;
            }
        }

        private static GM __instance = null;

        public Map AddMap(string name)
        {
            maps.Add(new Map() {
                ID = maps.Count,
                Name = name
            });

            return maps.Last();
        }

        public Character AddCharacter(string name)
        {
            characters.Add(new Character()
            {
                ID = characters.Count,
                Name = name
            });

            return characters.Last();
        }

        public void SetPosition(Map map, Character character)
        {
            var before_position = character.Position;

            if(before_position.Item1 < maps.Count)
                maps[before_position.Item1].CharactersRef.RemoveAll((t) => t.Item1 == character.Refer.Item1);

            map.CharactersRef.Add(character.Refer);
            character.Position = map.Refer;
        }
    }
}
