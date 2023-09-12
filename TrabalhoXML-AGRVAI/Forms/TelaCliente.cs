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
using System.Xml;
using System.Xml.Linq;
using TrabalhoXML_AGRVAI.Forms;

namespace TrabalhoXML_AGRVAI.Formzs
{
    public partial class TelaCliente : Form
    {
        List<CadastroClientes> clientes = new List<CadastroClientes>();

        private string arquivoXML = "clientes.xml";
        public TelaCliente()
        {
            try
            {
                InitializeComponent();
                CarregarClientes();
                ColunasDgv();
                AtualizarDataGridView();
                LoadXMLData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CarregarClientes()
        {
            try
            {
                if (File.Exists(arquivoXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroClientes>));

                    using (StreamReader reader = new StreamReader(arquivoXML))
                    {
                        clientes = (List<CadastroClientes>)serializer.Deserialize(reader);
                    }
                }
                clientes = clientes.OrderBy(x => x.Nome).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AtualizarDataGridView()
        {
            try
            {
                dgv_clientes.Rows.Clear();

                foreach (var cliente in clientes)
                {
                    dgv_clientes.Rows.Add(cliente.Nome, cliente.Cpf, cliente.Fone, cliente.Email);
                }
                    clientes = clientes.OrderBy(x => x.Nome).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ColunasDgv()
        {
            try
            {
                dgv_clientes.AutoGenerateColumns = false;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void LimparCampos()
        {
            txt_nome.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_fone.Clear();
            tx_senha.Clear();
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadXMLData()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("clientes.xml");
                XmlNodeList pessoaNodes = xmlDoc.SelectNodes("CadastroCliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {

        }

        private void dgv_clientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            this.Dispose();
            usuario.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                    XmlSerializer serializa = new XmlSerializer(typeof(List<CadastroClientes>));
                    CadastroClientes nvCliente = new CadastroClientes(txt_nome.Text, txt_cpf.Text, txt_email.Text, txt_fone.Text, tx_senha.Text);

                    clientes.Add(nvCliente);

                /*  clientes = clientes.OrderBy(x => x.Nome).ToList();*/
                    AtualizarDataGridView();
                   
                    LimparCampos();

                    using (StreamWriter writer = new StreamWriter("clientes.xml"))
                    {
                        serializa.Serialize(writer, clientes);
                    }

                    if (clientes.Count > 0)
                    {
                        XmlSerializer serializar = new XmlSerializer(typeof(List<CadastroClientes>));

                        using (StreamWriter writer = new StreamWriter("clientes.xml"))
                        {
                            serializar.Serialize(writer, clientes);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}

