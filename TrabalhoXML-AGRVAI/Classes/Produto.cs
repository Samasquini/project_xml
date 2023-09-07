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
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        public Produto()
        {

        }

        public Produto( string nome, int id, int quant, double preco, string Descricao)
        {
            this.Id = Id;
            this.Nome = nome;
            this.Quantidade = quant;
            this.Preco = preco;
            this.Descricao = Descricao;

        }        
    }
}
