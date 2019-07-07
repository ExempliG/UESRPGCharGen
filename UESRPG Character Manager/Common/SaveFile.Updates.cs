using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UESRPG_Character_Manager.Common
{
    public partial class SaveFile
    {
        private static void PerformUpdates( XmlDocument xml )
        {
            Version version = GetVersion(xml);
            Update_0_3_0(xml, version);
        }

        private static Version GetVersion( XmlDocument xml )
        {
            return new Version(GetIntAttribute(xml, "MajorRevision"),
                               GetIntAttribute(xml, "MinorRevision"),
                               GetIntAttribute(xml, "EngRevision"),
                               GetIntAttribute(xml, "Release", 0));

        }

        private static int GetIntAttribute( XmlDocument xml, string attributeName )
        {
            XmlNode attribute = xml.DocumentElement.Attributes.GetNamedItem(attributeName);
            return int.Parse(attribute.Value);
        }

        private static int GetIntAttribute( XmlDocument xml, string attributeName, int defaultValue )
        {
            int result = defaultValue;

            XmlNode attribute = xml.DocumentElement.Attributes.GetNamedItem(attributeName);
            if( attribute != null )
            {
                result = int.Parse(attribute.Value);
            }

            return result;
        }

        private static void Update_0_3_0( XmlDocument xml, Version version )
        {
            Version v0_3_0_1 = new Version(0, 3, 0, 1);
            if( version < v0_3_0_1 )
            {
                // do the update procedure
            }
        }
    }
}
