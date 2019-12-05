using System.IO;
using RoleTopMVC.Models;
using System;
using RoleTopMVC.Controllers;

namespace RoleTopMVC.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] { PrepararRegistroCSV(cliente) };
            File.AppendAllLines(PATH, linha);

            return true;            
        }

        public Cliente ObterPor (string email)
        {
            var linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                if(ExtrairValorDoCampo("email", item).Equals(email))
                {
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo("nome", item);
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", item));
                    c.Senha = ExtrairValorDoCampo("senha", item);
                    c.CPFCNPJ = ExtrairValorDoCampo("cpfcnpj", item);
                    c.Email = ExtrairValorDoCampo("email", item);
                   

                    return c;
                }
            }
            return null;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};senha={cliente.Senha};email={cliente.Email};cpfcnpj={cliente.CPFCNPJ};";
        }

    }
}