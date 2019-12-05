using System;
using Microsoft.Extensions.Primitives;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Models
{
    public class Cliente
    {
       

        public string Nome {get;set;}
        public string Senha {get;set;}
         public string CPFCNPJ { get; set; }

        public string Email {get;set;}
    
        public uint TipoUsuario {get;set;}

        public Cliente()
        {

        }

        public Cliente( string nome, string senha, string cpfcnpj, string email)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.CPFCNPJ = cpfcnpj;
            this.Email = email;

        }

    }
}