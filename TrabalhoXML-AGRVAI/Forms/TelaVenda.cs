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
using System.Xml.Linq;
using System.Xml.Serialization;
using TrabalhoXML_AGRVAI.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class TelaVenda : Form
    {
        List<Produto> produtos = new List<Produto>();
        Produto prod = new Produto();
        //Criar uma nova classe produto
        public TelaVenda()
        {
            InitializeComponent();
            ColunasDgv();
            LoadXMLData();
            AtualizarDataGridView();
            CarregarEstoque();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
       

        private void TelaVenda_Load(object sender, EventArgs e)
        {

        }
        private int LinhaRaiz(int productId)
        {
            foreach (DataGridViewRow row in dgv_produto.Rows)
            {
                int id = int.Parse(row.Cells[0].Value.ToString());

                if (id == productId)
                {
                    return row.Index;
                }
            }

            return -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txt_id.Text, out id))
            {
                int quantidadeDesejada;
                if (int.TryParse(tx_quant.Text, out quantidadeDesejada))
                {
                    Produto produtoSelecionado = produtos.FirstOrDefault(p => p.Id == id);

                    if (produtoSelecionado != null)
                    {
                        if (produtoSelecionado.Quantidade >= quantidadeDesejada)
                        {
                            produtoSelecionado.Quantidade -= quantidadeDesejada;
                            UpdateXmlFile();
                            UpdateDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Estoque insuficiente para a quantidade desejada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado com o ID fornecido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Digite uma quantidade válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateXmlFile()
        {
            try
            {

                foreach (DataGridViewRow row in dgv_produto.Rows)
                {
                    string name = row.Cells[0].Value.ToString();
                    int id = int.Parse(row.Cells[1].Value.ToString());
                    int quantity = int.Parse(row.Cells[2].Value.ToString());
                    decimal price = decimal.Parse(row.Cells[3].Value.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o arquivo XML: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AtualizarDataGridView()
        {
            CadastroProduto novo = new CadastroProduto();
            try
            {
                dgv_produto.Rows.Clear();

                foreach (var cliente in novo.pro)
                {
                    dgv_produto.Rows.Add(cliente.Nome, cliente.Id, cliente.Quantidade, cliente.Preco, cliente.Descricao);
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));

                    using (StreamReader reader = new StreamReader("estoque.xml"))
                    {
                        dnv.pro = (List<Produto>)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataGridView()
        {
            dgv_produto.Rows.Clear();
            foreach(Produto computer in produtos)
            {
                dgv_produto.Rows.Add(computer.Nome, computer.Id, computer.Quantidade, computer.Preco.ToString("C"));
            }
        }
        public void ColunasDgv()
        {
            try
            {
                dgv_produto.AutoGenerateColumns = false;

                // Configuração das colunas DGV
                DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
                colunaNome.DataPropertyName = "Nome";
                colunaNome.HeaderText = "Nome";

                DataGridViewTextBoxColumn colunaId = new DataGridViewTextBoxColumn();
                colunaId.DataPropertyName = "Id";
                colunaId.HeaderText = "Id";

                DataGridViewTextBoxColumn colunaQuant = new DataGridViewTextBoxColumn();
                colunaQuant.DataPropertyName = "Quantidade";
                colunaQuant.HeaderText = "Quantidade";

                DataGridViewTextBoxColumn colunaPreco = new DataGridViewTextBoxColumn();
                colunaPreco.DataPropertyName = "Preço";
                colunaPreco.HeaderText = "Preço";

                DataGridViewTextBoxColumn colunaDes = new DataGridViewTextBoxColumn();
                colunaDes.DataPropertyName = "Descrição";
                colunaDes.HeaderText = "Descrição";


                dgv_produto.Columns.Add(colunaNome);
                dgv_produto.Columns.Add(colunaId);
                dgv_produto.Columns.Add(colunaQuant);
                dgv_produto.Columns.Add(colunaPreco);
                dgv_produto.Columns.Add(colunaDes);
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
                // Use o nome correto do nó XML usado durante a serialização
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_cpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_produto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
