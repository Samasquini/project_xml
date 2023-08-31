using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoXML_AGRVAI.Classes
{
    public class CadastroPro
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        public CadastroPro()
        {

        }
        public CadastroPro(string id, string nome, int quant, double preco, string Descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Quantidade = quant;
            this.Preco = preco;
            this.Descricao = Descricao;
        }
    }
}
