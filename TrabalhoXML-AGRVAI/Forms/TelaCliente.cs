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
using System.Collections.Generic;
using System.Xml;

namespace TrabalhoXML_AGRVAI.Forms
{
   /* List<CadastroCliente> novocliente = new List<CadastroClientes>();*/
    public partial class TelaCliente : Form
    {
        List<CadastroClientes> clientes = new List<CadastroClientes>();
        private string arquivoXML = "clientes.xml";
        /*private DataGridView dataGridViewClientes;*/
        public TelaCliente()
        {
            InitializeComponent();
            CarregarClientes();
            AtualizarDataGridView();
           
        }
        private void CarregarClientes()
        {
            if (File.Exists(arquivoXML))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroClientes>));

                using (StreamReader reader = new StreamReader(arquivoXML))
                {
                    clientes = (List<CadastroClientes>)serializer.Deserialize(reader);
                }
            }
        }
        private void AtualizarDataGridView()
        {
            dgv_clientes = new DataGridView();
            dgv_clientes.AutoGenerateColumns = false;
            dgv_clientes.Rows.Clear();

            // Configuração das colunas (você precisa adicionar as colunas aqui)
            DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
            colunaNome.DataPropertyName = "Nome";
            colunaNome.HeaderText = "Nome";

            DataGridViewTextBoxColumn colunacpf = new DataGridViewTextBoxColumn();
            colunacpf.DataPropertyName = "Cpf";
            colunacpf.HeaderText = "Cpf";

            DataGridViewTextBoxColumn colunaFone = new DataGridViewTextBoxColumn();
            colunaFone.DataPropertyName = "Fone";
            colunaFone.HeaderText = "Fone";

            DataGridViewTextBoxColumn colunaEmail = new DataGridViewTextBoxColumn();
            colunaEmail.DataPropertyName = "Email";
            colunaEmail.HeaderText = "Email";

            dgv_clientes.Columns.Add(colunaNome);
            dgv_clientes.Columns.Add(colunacpf);
            dgv_clientes.Columns.Add(colunaFone);
            dgv_clientes.Columns.Add(colunaEmail);

            // Configurações do DataGridView, colunas etc.



            foreach (var cliente in clientes)
            {
                dgv_clientes.Rows.Add(cliente.Nome, cliente.Cpf, cliente.Fone, cliente.Email);
            }
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

            XmlSerializer serialize = new XmlSerializer(typeof(List<CadastroClientes>));
            CadastroClientes nvCliente = new CadastroClientes();
            nvCliente.Cliente(txt_nome.Text, txt_cpf.Text, txt_email.Text, txt_fone.Text);

            clientes.Add(nvCliente);
            MessageBox.Show("Cliente adicionado com sucesso!");

            /*
             * nvCliente.Main();*/

            using (StreamWriter writer = new StreamWriter("clientes.xml"))
            {
                serialize.Serialize(writer, clientes);
            }
            MessageBox.Show("Clientes salvos no arquivo XML.");
            if (clientes.Count > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroClientes>));

                using (StreamWriter writer = new StreamWriter("clientes.xml"))
                {
                    serializer.Serialize(writer, clientes);
                }

                MessageBox.Show("Clientes salvos no arquivo XML.");
            }
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {
            // Crie uma tabela para armazenar os dados do XML
            DataTable dataTable = new DataTable();

            // Adicione as colunas à tabela com base no XML
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Cpf", typeof(string));
            dataTable.Columns.Add("Fone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));

            // Carregue o arquivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("clientes.xml");

            // Encontre os elementos desejados no XML (neste exemplo, assumimos uma estrutura específica)
            XmlNodeList pessoaNodes = xmlDoc.SelectNodes("//Clientes");

            foreach (XmlNode pessoaNode in pessoaNodes)
            {
                string nome = pessoaNode.SelectSingleNode("Nome").InnerText;
                string cpf = (pessoaNode.SelectSingleNode("Cpf").InnerText);
                string fone = pessoaNode.SelectSingleNode("Fone").InnerText;
                string email = pessoaNode.SelectSingleNode("Email").InnerText;

                // Adicione os dados como uma nova linha na tabela
                dataTable.Rows.Add(nome, cpf, fone, email);
            }

            // Associe a tabela ao DataGridView
            dgv_clientes.DataSource = dataTable;
        }
        public void LimparCampos()
        {
            txt_nome.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_fone.Clear();
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

