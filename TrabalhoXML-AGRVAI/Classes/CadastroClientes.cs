using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TrabalhoXML_AGRVAI.Classes
{
    public class CadastroClientes
    {
        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }

        public CadastroClientes()
        {

        }
        public CadastroClientes(string nome, string cpf, string email, string fone)
        {
            try
            {
                this.Nome = nome;
                this.Cpf = cpf;
                this.Email = email;
                this.Fone = fone;
            }
            catch(Exception ex) {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Cliente(string nome, string cpf, string email, string fone) 
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Fone = fone;
        }
        public void Main()
        {
            try
            {
                XmlWriter writer = null;
                XmlDocument doc = new XmlDocument();
                writer = XmlWriter.Create("Cliente.xml");

                // Write the root element.
                writer.WriteStartElement("cliente");

                // Write the xmlns:bk="urn:book" namespace declaration.

                writer.WriteAttributeString("id", "1");


                // Write the bk:ISBN="1-800-925" attribute.
                /*writer.WriteAttributeString("ISBN", "urn:book", "1-800-925");*/

                writer.WriteElementString("name", this.Nome);
                writer.WriteElementString("cpf", this.Cpf);
                writer.WriteElementString("email", this.Email);
                writer.WriteElementString("fone", this.Fone);


                /*doc.LoadXml("Cliente.xml");

                XmlNode root = doc.FirstChild;
                Console.WriteLine("Display the price element...");

                Console.WriteLine(root.LastChild);*/

                // Write the close tag for the root element.
                writer.WriteEndElement();

                // Write the XML to file and close the writer.

                writer.Flush();
                writer.Close();
                MessageBox.Show("Cadastrado com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
