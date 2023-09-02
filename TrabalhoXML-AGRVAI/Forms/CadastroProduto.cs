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
    public partial class CadastroProduto : Form
    {
        public List<Produto> pro = new List<Produto>();
        public CadastroProduto()
        {
            InitializeComponent();
            AtualizaList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txt_id.Text); 
                string nm = txt_nome.Text;
                int qt = Convert.ToInt32(txt_quant.Text);
                double pre = Convert.ToDouble(tx_preco.Text);
                string dcr = tx_descri.Text;

                XmlSerializer serialize = new XmlSerializer(typeof(List<Produto>));
                Produto prod = new Produto(id, nm, qt, pre, dcr);

                pro.Add(prod);

                LimparCampos();
                using (StreamWriter writer = new StreamWriter("estoque.xml"))
                {
                    serialize.Serialize(writer, pro);
                }
                if (pro.Count > 0)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));

                    using (StreamWriter writer = new StreamWriter("estoque.xml"))
                    {
                        serializer.Serialize(writer, pro);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void LimparCampos()
        {
            txt_nome.Clear();
            txt_id.Clear();
            txt_quant.Clear();
            tx_preco.Clear();
            tx_descri.Clear();
        }
        public void AtualizaList()
        {
            if (File.Exists("estoque.xml"))
            {
                using (StreamReader reader = new StreamReader("estoque.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
                    pro = (List<Produto>)serializer.Deserialize(reader);
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void CadastroProduto_Load(object sender, EventArgs e)
        {

        }
    }
}
