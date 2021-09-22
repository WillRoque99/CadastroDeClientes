using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeClientes.Domain.Entitys
{
    public class Cliente
    {

        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; } 

        
        public string CNPJ { get; set; }


        public DateTime DataDeCadastro { get; set; }

        public string Endereço { get; set; }

        public string Telefone { get; set; }
    }
}