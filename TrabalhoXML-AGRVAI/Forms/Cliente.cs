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
using TrabalhoXML_AGRVAI.Formzs;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class Cliente : Form
    {
        public List<CadastroClientes> clientes = new List<CadastroClientes>();
        private string arquivoXML = "clientes.xml";
        
        
        public Cliente()
        {
            InitializeComponent();
            CarregarClientes();
            AtualizarDataGridView();
        }
        private void CarregarClientes()
        {
            TelaCliente c = new TelaCliente();
            try
            {
                if (File.Exists(arquivoXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroClientes>));

                    using (StreamReader lerXml = new StreamReader(arquivoXML))
                    {
                        clientes = (List<CadastroClientes>)serializer.Deserialize(lerXml);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AtualizarDataGridView()
        {
            TelaCliente c = new TelaCliente();
            try
            {
                c.dgv_clientes.Rows.Clear();

                foreach (var cliente in clientes)
                {
                    c.dgv_clientes.Rows.Add(cliente.Nome, cliente.Cpf, cliente.Fone, cliente.Email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nm = txt_nome.Text;
                string cf = txt_cpf.Text;
                string em = txt_email.Text;
                string fn = txt_fone.Text;
                string sh = tx_senha.Text;


                if (!(nm == "" && cf == "" && em == "" && fn == "" && sh == ""))
                {

                    XmlSerializer serialize = new XmlSerializer(typeof(List<CadastroClientes>));

                    CadastroClientes nvCliente = new CadastroClientes(txt_nome.Text, txt_cpf.Text, txt_email.Text, txt_fone.Text, tx_senha.Text);

                    clientes.Add(nvCliente);
                   
                    LimparCampos();

                    using (StreamWriter writer = new StreamWriter("clientes.xml"))
                    {
                        serialize.Serialize(writer, clientes);
                    }

                    if (clientes.Count > 0)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroClientes>));

                        using (StreamWriter ecXml = new StreamWriter("clientes.xml"))
                        {
                            serializer.Serialize(ecXml, clientes);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LimparCampos()
        {
            txt_nome.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_fone.Clear();
            tx_senha.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TelaCliente cliente = new TelaCliente();
            cliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
