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
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        public Produto()
        {

        }
<<<<<<< HEAD
        public Produto(string id, string nome, int quant, double preco, string Descricao)
=======
        public CadastroPro(int id, string nome, int quant, double preco, string Descricao)
>>>>>>> c972d1a7227e7aa99fc4bdef8add567e8c95debb
        {
            this.Id = id;
            this.Nome = nome;
            this.Quantidade = quant;
            this.Preco = preco;
            this.Descricao = Descricao;
        }

        
    }
}
