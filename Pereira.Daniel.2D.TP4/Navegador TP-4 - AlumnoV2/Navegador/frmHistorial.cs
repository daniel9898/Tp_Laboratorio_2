using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            List<string> historial;
            Texto archivos = new Texto(frmHistorial.ARCHIVO_HISTORIAL);
            ((IArchivo<string>)archivos).leer(out historial);
            foreach (string link in historial)
            {//agregamos las cadenas ala lista del listBox
                this.lstHistorial.Items.Add(link);
            }
        }
    }
}
