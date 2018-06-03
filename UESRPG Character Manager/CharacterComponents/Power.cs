﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public class Power
    {
        public static uint NextAvailableId { get; set; }

        [XmlAttribute()]
        public string Name { get; set; }
        public string Description { get; set; }

        [XmlIgnore(), Browsable(false)]
        public uint PowerId { get; set; }

        public Power()
        {
            PowerId = NextAvailableId;
            NextAvailableId++;
        }

        public Power(string Name, string Description) : this()
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}
