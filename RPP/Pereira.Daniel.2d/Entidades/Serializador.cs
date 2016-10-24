using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
    public class Serializador
    {
        /// <summary>
        /// Serializa en un archivo xml los datos del estante pasado por parametro
        /// en una ruta especifica
        /// </summary>
        /// <param name="e"></param>
        /// <param name="ruta"></param>
        public static void SerializarEstante(Estante e,string ruta)
        {
            XmlSerializer xml;    
            xml = new XmlSerializer(typeof(Estante));
            Stream archivo = new FileStream(ruta,FileMode.OpenOrCreate);
            xml.Serialize(archivo,e);
            archivo.Close();
        }
        /// <summary>
        /// Deserializa en un objeto de tipo estante los datos del archivo xml pasado por parametro
        /// </summary>
        /// <param name="ruta"></param>
        public static Estante DeserializarEstante(string ruta)
        {
            XmlSerializer xml;
            xml = new XmlSerializer(typeof(Estante));
            FileStream Lector = File.OpenRead(ruta);
            Estante e = (Estante)xml.Deserialize(Lector);
            Lector.Close();
            return e;
        }

    }
}
