using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
     public class Xml<T> : IArchivo<T>
     {
       /// <summary>
       /// Guarda los datos del tipo T en un archivo con formato Xml
       /// </summary>
       /// <param name="archivo"></param>
       /// <param name="datos"></param>
       /// <returns></returns>
    
       bool IArchivo<T>.Guardar(string archivo,T datos)
       {
          bool retorno = true;
          try
          {
             XmlSerializer xml = new XmlSerializer(typeof(T));
             Stream escritor = new FileStream(archivo, FileMode.OpenOrCreate);
             xml.Serialize(escritor, datos);
             escritor.Close();
          }
          catch (Exception e)
          {
              retorno = false;//si entro aca significa que hubo un problema
              throw new ArchivosException(e);
          }
          return retorno; 
       
       }
       /// <summary>
       /// lee los datos de tipo T desde un archivo con formato Xml 
       /// </summary>
       /// <param name="archivo"></param>
       /// <param name="datos"></param>
       /// <returns></returns>
       bool IArchivo<T>.Leer(string archivo,out T datos)
       {
           bool retorno = true;
           try
           {
               XmlSerializer xml = new XmlSerializer(typeof(T));
               FileStream Lector = File.OpenRead(archivo);
               T e = (T)xml.Deserialize(Lector);
               datos = e;
               Lector.Close();              
           }        
           catch (Exception ex)
           {
               retorno = false;//si entro aca significa que hubo un problema
               throw new ArchivosException(ex);
           }    
           return retorno;
       }
     

     }
}
