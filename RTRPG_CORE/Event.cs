﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RTRPG_CORE
{
    public class Event
    {
        [YamlMember(Order = 1)]
        public int ID;

        [YamlMember(Alias = "描述", Order = 1)]
        public string Description;

        public enum Effect {
            Nothing,
            Message,
            Message_Next,
        };

        [YamlMember(Alias = "消息", Order = 2)]
        public string Message;

        [YamlMember(Alias = "后继事件ID", Order = 2)]
        public int NextEventID;
    }
}
