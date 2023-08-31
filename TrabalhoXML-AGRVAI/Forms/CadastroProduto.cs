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
        public List<CadastroPro> pro = new List<CadastroPro>();
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
                string id = txt_id.Text;
                string nm = txt_nome.Text;
                int qt = Convert.ToInt32(txt_quant.Text);
                double pre = Convert.ToDouble(tx_preco.Text);
                string dcr = tx_descri.Text;
                /*if (!(nm == "" && id == "" && txt_quant.Text == "" && tx_preco.Text == ""))
                {*/

                XmlSerializer serialize = new XmlSerializer(typeof(List<CadastroPro>));
                CadastroPro prod = new CadastroPro(id, nm, qt, pre, dcr);
                pro.Add(prod);
                LimparCampos();
                using (StreamWriter writer = new StreamWriter("estoque.xml"))
                {
                    serialize.Serialize(writer, pro);
                }
                if (pro.Count > 0)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroPro>));

                    using (StreamWriter writer = new StreamWriter("estoque.xml"))
                    {
                        serializer.Serialize(writer, pro);
                    }

                    /*}*/
                    MessageBox.Show("Salvo no xml");
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
        }
        public void AtualizaList()
        {
            if (File.Exists("estoque.xml"))
            {
                using (StreamReader reader = new StreamReader("estoque.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CadastroPro>));
                    pro = (List<CadastroPro>)serializer.Deserialize(reader);
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
