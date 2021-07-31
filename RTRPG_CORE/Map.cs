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
        [YamlMember(Order = 0)]
        public int ID { get; set; }

        [YamlMember(Alias = "名称", Order = 1)]
        public string Name { get; set; }

        [YamlMember(Alias = "进入触发事件", Order = 2)]
        public List<Event> onEnter = new List<Event>();

        [YamlMember(Alias = "离开触发事件", Order = 3)]
        public List<Event> onLeave = new List<Event>();

        [YamlMember(Alias = "角色", Order = 4)]
        public List<Tuple<int, string>> CharactersRef;

        public Tuple<int, string> Refer {
            get => new Tuple<int, string>(ID, Name);
        }
    }
}
