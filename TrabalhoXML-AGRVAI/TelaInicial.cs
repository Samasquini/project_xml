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
            TelaCliente nvCliente = new TelaCliente();
            this.SuspendLayout();

            nvCliente.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaAdmim nvAdm= new TelaAdmim();

            nvAdm.ShowDialog();
        }
    }
}
