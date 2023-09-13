using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TrabalhoXML_AGRVAI.Classes;
using TrabalhoXML_AGRVAI.Formzs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class TelaVenda : Form
    {
        List<Produto> produtos = new List<Produto>();
        Produto prod = new Produto();
        private List<Produto> produtosDisponiveis;
        private List<Produto> produtosVendidos;
        

        public TelaVenda()
        {
            InitializeComponent();
            ColunasDgv();
            CarregarXML();
            AtualizarDataGridView();
            CarregarEstoque();
            ProdutosG();
        }

        public void ProdutosG()
        {
            produtosDisponiveis = new List<Produto>();
            produtosDisponiveis = ProdutosXML("estoque.xml");
            produtosVendidos = new List<Produto>();
        }

        private List<Produto> ProdutosXML(string caminho)
        {
            if (File.Exists(caminho))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
                    using (StreamReader ler = new StreamReader(caminho))
                    {
                        return (List<Produto>)serializer.Deserialize(ler);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar produtos do XML: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return new List<Produto>();
        }
        private void TelaVenda_Load(object sender, EventArgs e)
        {

        }
        public void LimparCampos()
        {
            txt_id.Clear();
            tx_quant.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ID = txt_id.Text;
            int qt = Convert.ToInt32(tx_quant.Text);

            try
            {
                Produto produto = produtosDisponiveis.Find(p => p.ID == ID);

                if(produto != null && produto.Quantidade >= qt)
                {
                    produtosVendidos.Add(new Produto(produto.Nome, produto.ID, produto.Quantidade, produto.Preco, produto.Descricao));
                
                    produto.Quantidade -= qt;
                    DGV();
                    SalvarVenda("estoque.xml", produtosDisponiveis);
                    AtualizarDataGridView();
                    MessageBox.Show("Venda realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Produto não encontrado ou quantidade insuficiente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ocorreu um Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SalvarVenda(string caminho, List<Produto> produtos)
        {
            try
            {
                /*var produtosComQuantidade = produtos.Where(p => p.Quantidade > 0).ToList();*/
                produtos.RemoveAll(p => p.Quantidade == 0);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
                using (StreamWriter esc = new StreamWriter(caminho))
                {
                    serializer.Serialize(esc, produtos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produtos no XML: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    using (StreamReader ler = new StreamReader("estoque.xml"))
                    {
                        dnv.pro = (List<Produto>)serializer.Deserialize(ler);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGV()
        {
            dgv_produto.Rows.Clear();
            
            foreach (Produto pc in produtos)
            {
                dgv_produto.Rows.Add(pc.Nome, pc.ID, pc.Quantidade, pc.Preco.ToString("C"));
            }
        }
        private void AtualizarDataGridView()
        {
            CadastroProduto novo = new CadastroProduto();
            try
            {
                dgv_produto.Rows.Clear();
                produtos.RemoveAll(p => p.Quantidade == 0);
                foreach (var cliente in novo.pro)
                {
                    dgv_produto.Rows.Add(cliente.Nome, cliente.ID, cliente.Quantidade, cliente.Preco, cliente.Descricao);
                }

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
                dgv_produto.AutoGenerateColumns = false;

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
        private void CarregarXML()
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

        private void txt_cpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_produto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
