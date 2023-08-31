using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoXML_AGRVAI.Forms;
using TrabalhoXML_AGRVAI.Formzs;

namespace TrabalhoXML_AGRVAI
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaCliente novoClie= new TelaCliente();
            novoClie.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaAdmim nvAdm= new TelaAdmim();

            nvAdm.ShowDialog();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
