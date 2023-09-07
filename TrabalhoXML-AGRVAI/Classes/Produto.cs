using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoXML_AGRVAI.Classes
{
    public class Produto
    {
        public string Nome { get; set; }
        public string ID { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        public Produto()
        {

        }

        public Produto( string nome, string id, int quant, double preco, string Descricao)
        {
            this.Nome = nome;
            this.ID = id;
            this.Preco = preco;
            this.Quantidade = quant;
            this.Descricao = Descricao;

        }        
    }
}
