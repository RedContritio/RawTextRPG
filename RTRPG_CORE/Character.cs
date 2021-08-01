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
        [YamlMember(Order = 0)]
        public int ID;

        [YamlMember(Alias = "名称", Order = 1)]
        public string Name;

        [YamlMember(Alias = "位置", Order = 2)]
        public Tuple<int, string> Position;

        [YamlIgnore]
        public Tuple<int, string> Refer
        {
            get => new Tuple<int, string>(ID, Name);
        }
    }
}
