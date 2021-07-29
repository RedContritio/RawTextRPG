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
    }
}
