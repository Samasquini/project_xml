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
using System.Xml;
using System.Xml.Serialization;
using TrabalhoXML_AGRVAI.Classes;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
            ColunasDgv();
            LoadXMLData();
            AtualizarDataGridView();
            CarregarEstoque();
        }
        private void AtualizarDataGridView()
        {
            CadastroProduto novo = new CadastroProduto();
            try
            {
                dgv_estoque.Rows.Clear();

                foreach (var cliente in novo.pro)
                {
                    dgv_estoque.Rows.Add(cliente.Nome, cliente.ID, cliente.Quantidade, cliente.Preco, cliente.Descricao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CarregarEstoque()
        { 
            CadastroProduto dnv = new CadastroProduto();
            try
            {
                if (File.Exists("estoque.xml"))
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(List<Produto>));

                    using (StreamReader ler = new StreamReader("estoque.xml"))
                    {
                        dnv.pro = (List<Produto>)serializar.Deserialize(ler);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ColunasDgv()
        {
            try
            {
                dgv_estoque.AutoGenerateColumns = false;

                DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
                colunaNome.DataPropertyName = "Nome";
                colunaNome.HeaderText = "Nome";

                DataGridViewTextBoxColumn colunaId = new DataGridViewTextBoxColumn();
                colunaId.DataPropertyName = "ID";
                colunaId.HeaderText = "ID";

                DataGridViewTextBoxColumn colunaQt = new DataGridViewTextBoxColumn();
                colunaQt.DataPropertyName = "Quant";
                colunaQt.HeaderText = "Quant";

                DataGridViewTextBoxColumn colunaPreco = new DataGridViewTextBoxColumn();
                colunaPreco.DataPropertyName = "Preço";
                colunaPreco.HeaderText = "Preço";

                DataGridViewTextBoxColumn colunaDes = new DataGridViewTextBoxColumn();
                colunaDes.DataPropertyName = "Descrição";
                colunaDes.HeaderText = "Descrição";

                dgv_estoque.Columns.Add(colunaNome);
                dgv_estoque.Columns.Add(colunaId);
                dgv_estoque.Columns.Add(colunaQt);
                dgv_estoque.Columns.Add(colunaPreco);
                dgv_estoque.Columns.Add(colunaDes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadXMLData()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("estoque.xml");
                XmlNodeList pessoaNodes = xmlDoc.SelectNodes("CadastroPro");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Estoque_Load(object sender, EventArgs e)
        {

        }
        private void dgv_estoque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
