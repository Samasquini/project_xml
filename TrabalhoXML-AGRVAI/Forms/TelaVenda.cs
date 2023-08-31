using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TrabalhoXML_AGRVAI.Classes;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class TelaVenda : Form
    {
        /*List<Produto> produtos = new List<Produto>();*/
        //Criar uma nova classe produto
        public TelaVenda()
        {
            InitializeComponent();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        private void LoadComputerData()
        {
            try
            {
                string xmlFilePath = "estoque.xml"; // Caminho para o arquivo XML
                XElement root = XElement.Load(xmlFilePath);

               /* foreach (XElement computerElement in root.Elements("computer"))
                {
                    Produto computer = new Produto();
                    computer.Nome = computerElement.Element("name").Value;
                    computer.Preco = double.Parse(computerElement.Element("price").Value);
                    computer.Quantidade = int.Parse(computerElement.Element("quantity").Value);

                    produtos.Add(computer);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataGridView()
        {
            /*dgv_produto.Rows.Clear();
            foreach (Produto computer in produtos)
            {
                dgv_produto.Rows.Add(computer.Nome, computer.Preco.ToString("C"), computer.Quantidade);
            }*/
        }

        private void TelaVenda_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
