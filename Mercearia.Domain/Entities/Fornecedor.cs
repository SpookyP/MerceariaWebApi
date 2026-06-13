using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Domain.Entities
{
    public class Fornecedor
    {
        //Guid para identificador
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Nif { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;
    }
}
