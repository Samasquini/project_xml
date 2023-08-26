using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TrabalhoXML_AGRVAI.Classes;

namespace TrabalhoXML_AGRVAI.Forms
{
   /* List<CadastroCliente> novocliente = new List<CadastroClientes>();*/
    public partial class TelaCliente : Form
    {
        List<CadastroClientes> cliente = new List<CadastroClientes>();
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

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroClientes nvCliente = new CadastroClientes();
            nvCliente.Cliente(txt_nome.Text, txt_cpf.Text, txt_email.Text, txt_fone.Text);

            /*cliente.Add(nvCliente);
            MessageBox.Show("Cliente adicionado com sucesso!");*/

            LimparCampos();

            /*nvCliente.Main();*/

            if (cliente.Count > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroClientes>));
                

                using (StreamWriter writer = new StreamWriter("Clientes.xml"))
                {
                    serializer.Serialize(writer, nvCliente);
                }

                MessageBox.Show("Clientes salvos no arquivo XML.");
            }

        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {

        }
        public void LimparCampos()
        {
            txt_nome.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_fone.Clear();
        }
    }
}
