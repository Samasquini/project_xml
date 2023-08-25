using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class TelaAdmim : Form
    {
        public TelaAdmim()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ClientesCadastrados nvCadas = new ClientesCadastrados();

            this.Dispose();

            nvCadas.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadastroProduto nvProduto = new CadastroProduto();

            this.Dispose();

            nvProduto.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
