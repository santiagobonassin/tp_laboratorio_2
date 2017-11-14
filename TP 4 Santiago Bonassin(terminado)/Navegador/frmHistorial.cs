using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "Historial.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(ARCHIVO_HISTORIAL);
            List<string> ListaDePaginas = new List<string>();
            if (!archivos.leer(out ListaDePaginas))
            {
                this.Close();
            }
            else
            {
                foreach (string i in ListaDePaginas)
                {
                    this.lstHistorial.Items.Add(i);
                }
            }
        }
        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
