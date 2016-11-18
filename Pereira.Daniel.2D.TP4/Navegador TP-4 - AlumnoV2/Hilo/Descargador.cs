using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;
using System.Reflection;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        /// <summary>
        /// Delegado que recibe metodos que reciban un entero y retornen void
        /// </summary>
        /// <param name="progreso"></param>
        public delegate void EvProgreso(int progreso);
        /// <summary>
        /// Delegado que recibe metodos que reciban un string y retornen void
        /// </summary>
        /// <param name="html"></param>
        public delegate void EvFinDes(string html);
        /// <summary>
        /// Evento del tipo delegado EvProgreso que manejara el progreso de la descarga
        /// </summary>
        public event EvProgreso EvenProg;
        /// <summary>
        /// Evento del tipo delegado EvFinDes que manejara el fin de la descarga
        /// </summary>
        public event EvFinDes EvenFinDes;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(direccion);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            EvenProg(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                html = e.Result;
                EvenFinDes(html);
            }
            catch (TargetInvocationException)
            {

            }
        }
    }
}
