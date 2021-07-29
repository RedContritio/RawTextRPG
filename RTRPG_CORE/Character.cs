using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RTRPG_CORE
{
    public class Character
    {
        private static int g_id = 0;

        [YamlMember(Order = 0)]
        public int ID;

        [YamlMember(Alias = "名称", Order = 1)]
        public string Name;

        [YamlMember(Alias = "位置", Order = 1)]
        public int Position;
        public static Character Create(string name)
        {
            Character character = new Character
            {
                ID = g_id++,
                Name = name
            };
            return character;
        }
    }
}
