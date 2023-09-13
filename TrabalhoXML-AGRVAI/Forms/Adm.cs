using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoXML_AGRVAI.Forms
{
    public partial class Adm : Form
    {
        public Adm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string senha = mtx_senha.Text;
            string senhaAdm = "adm23";
            string nmAdm = tx_usuario.Text;

            if(senha != "" && nmAdm != "")
            {
                if(senha == senhaAdm)
                {
                    mtx_senha.Text = "";
                    tx_usuario.Text = "";
                    TelaAdmim adm = new TelaAdmim();
                    this.Dispose();
                    adm.ShowDialog();
                }
                else
                {
                    
                    MessageBox.Show($"Senha ADM incorreta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Preencha todos os campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
