using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoXML_AGRVAI.Classes
{
    internal class CadastroClientes
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }

        List<string> list = new List<string>();

        public string Cliente(string nome, string cpf, string email, string fone) 
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Fone = fone;

            list.Add(nome);
            list.Add(cpf);
            list.Add(email);
            list.Add(fone);

            return list.ToString();
        }
    }
}
