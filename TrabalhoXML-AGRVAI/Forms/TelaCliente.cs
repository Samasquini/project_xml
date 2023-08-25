using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoXML_AGRVAI.Classes;

namespace TrabalhoXML_AGRVAI.Forms
{
   /* List<CadastroCliente> novocliente = new List<CadastroClientes>();*/
    public partial class TelaCliente : Form
    {
        public TelaCliente()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            CadastroClientes novoCliente = new CadastroClientes();
            novoCliente.Nome = txt_nome.Text;
            novoCliente.Cpf = txt_cpf.Text;
            novoCliente.Email = txt_email.Text;
            novoCliente.Fone = txt_fone.Text;

            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
            TelaInicial nvInicial = new TelaInicial();
            nvInicial.ShowDialog();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
