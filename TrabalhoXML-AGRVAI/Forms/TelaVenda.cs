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
        List<CadastroPro> produtos = new List<CadastroPro>();
        CadastroPro prod = new CadastroPro();
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
        private void LoadComputerData()
        {
           /* try
            {
                string xmlFilePath = "estoque.xml"; // Caminho para o arquivo XML
                XElement root = XElement.Load(xmlFilePath);

                foreach (XElement computerElement in root.Elements("computer"))
                {
                    CadastroPro computer = new CadastroPro();
                    *//*computer.Nome = computerElement.Element("name").Value;
                    computer.Preco = double.Parse(computerElement.Element("price").Value);*//*
                    computer.Quantidade = int.Parse(computerElement.Element("quantity").Value);

                    produtos.Add(computer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        /*private void UpdateDataGridView()
        {
            *//*dgv_produto.Rows.Clear();
            foreach (Produto computer in produtos)
            {
                dgv_produto.Rows.Add(computer.Nome, computer.Preco.ToString("C"), computer.Quantidade);
            }*//*
        }*/

        private void TelaVenda_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int selectedId;
            if (int.TryParse(txt_id.Text, out selectedId))
            {
                CadastroPro selectedComputer = produtos.FirstOrDefault(c => c.Id == selectedId);// O lambda é "vai para"

                if (selectedComputer != null && selectedComputer.Quantidade > 0)
                {
                    selectedComputer.Quantidade--;
                    /*UpdateXmlFile();*/
                    UpdateDataGridView();
                }
                else
                {
                    MessageBox.Show("ID inválido ou estoque esgotado para este computador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Insira um ID válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            /*  int selectedIndex = comboBoxComputers.SelectedIndex;
              if (selectedIndex >= 0)
              {
                  Produto selectedComputer = produtos[selectedIndex];

                  if (selectedComputer.Quantity > 0)
                  {
                      selectedComputer.Quantity--;
                      labelQuantity.Text = "Quantidade disponível: " + selectedComputer.Quantity.ToString();
                      UpdateDataGridView();
                  }
                  else
                  {
                      MessageBox.Show("Estoque esgotado para este computador.", "Sem Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
              }*/
        }
        /*private void UpdateXmlFile()
        {
            XElement root = new XElement("CadastoPro");
            foreach (CadastroPro computer in produtos)
            {
                XElement computerElement = new XElement("computer",
                    new XAttribute("id", computer.Id),
                    new XElement("Nome", computer.Nome),
                    new XElement("Preço", computer.Preco),
                    new XElement("Quantidade", computer.Quantidade)
                );
                root.Add(computerElement);
            }
            root.Save("estoque.xml");
        }*/
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroPro>));

                    using (StreamReader reader = new StreamReader("estoque.xml"))
                    {
                        dnv.pro = (List<CadastroPro>)serializer.Deserialize(reader);
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
            foreach (CadastroPro computer in produtos)
            {
                dgv_produto.Rows.Add(computer.Id, computer.Nome, computer.Preco.ToString("C"), computer.Quantidade);
            }
        }
        public void ColunasDgv()
        {
            try
            {
                dgv_produto.AutoGenerateColumns = false;

                // Configuração das colunas DGV
                DataGridViewTextBoxColumn colunaId = new DataGridViewTextBoxColumn();
                colunaId.DataPropertyName = "ID";
                colunaId.HeaderText = "ID";

                DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
                colunaNome.DataPropertyName = "Nome";
                colunaNome.HeaderText = "Nome";

                DataGridViewTextBoxColumn colunaPreco = new DataGridViewTextBoxColumn();
                colunaPreco.DataPropertyName = "Preço";
                colunaPreco.HeaderText = "Preço";

                DataGridViewTextBoxColumn colunaDes = new DataGridViewTextBoxColumn();
                colunaDes.DataPropertyName = "Descrição";
                colunaDes.HeaderText = "Descrição";

                dgv_produto.Columns.Add(colunaNome);
                dgv_produto.Columns.Add(colunaId);
           
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
    }
}
