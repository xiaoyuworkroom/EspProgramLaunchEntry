using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EspProgramLaunchEntry.Utilitys
{
    public class UtilityXML
    {
        public static void SaveToXml(string filePath, object sourceObj, Type type)
        {
            if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
            {
                type = type != null ? type : sourceObj.GetType();

                if (!File.Exists(filePath))
                {
                    var newFile = File.Create(filePath);
                    newFile.Close();
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = 
                        new System.Xml.Serialization.XmlSerializer(type) ;
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }

        public static T LoadFromXml<T> (string filePath) where T : class
        {
            T result = default(T);

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    result = (T) xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}
