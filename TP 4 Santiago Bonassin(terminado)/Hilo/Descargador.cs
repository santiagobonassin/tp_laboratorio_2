using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;
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
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);
                cliente.DownloadStringAsync(direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Progreso(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {          
            html = e.Result;
            EventoFinalizado(html);
        }
        public delegate void EventProgress(int progreso);
        public delegate void End(string html);
        public event EventProgress Progreso;
        public event End EventoFinalizado;
    }
}
