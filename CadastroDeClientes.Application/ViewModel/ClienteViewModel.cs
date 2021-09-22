using System;

namespace CadastroDeClientes.Application.Dtos
{
    public class ClienteViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
    }
}
