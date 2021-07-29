using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RTRPG_CORE
{
    public class Map
    {
        private static int g_id = 0;

        [YamlMember(Order = 0)]
        public int ID { get; set; }

        [YamlMember(Alias = "名称", Order = 1)]
        public string Name { get; set; }

        [YamlMember(Alias = "进入触发事件", Order = 2)]
        public List<Event> onEnter = new List<Event>();

        [YamlMember(Alias = "离开触发事件", Order = 3)]
        public List<Event> onLeave = new List<Event>();

        [YamlMember(Alias = "角色", Order = 4)]
        public List<Character> Characters = new List<Character>();
        public static Map Create(string name)
        {
            Map map = new Map
            {
                ID = g_id++,
                Name = name
            };
            return map;
        }
    }
}
