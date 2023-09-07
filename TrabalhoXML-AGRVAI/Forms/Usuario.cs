using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tx_usuario.Text;
            string password = mtx_senha.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, insira nome de usuário e senha.");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("clientes.xml");

            XmlNode userNode = xmlDoc.SelectSingleNode($"//CadastroClientes[Nome='{username}']");

            if (userNode != null)
            {
                string storedPassword = userNode.SelectSingleNode("Senha").InnerText;

                if (password == storedPassword)
                {
                   /* MessageBox.Show("Login bem-sucedido! Acesso concedido.");*/
                    TelaVenda venda= new TelaVenda();
                    this.Dispose();
                    venda.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Senha incorreta. Tente novamente.");
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado. Verifique o nome de usuário.");
            }
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }
    }
}
