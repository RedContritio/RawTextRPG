using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RTRPG_CORE
{
    public static class Serialization
    {
        private static Deserializer deserializer = new Deserializer();
        private static Serializer serializer = new Serializer();
        
        public static T Deserialize<T>(string yamlText)
        {
            return deserializer.Deserialize<T>(yamlText);
        }

        public static string Serialize<T>(this T obj)
        {
            return serializer.Serialize(obj);
        }
    }
}
