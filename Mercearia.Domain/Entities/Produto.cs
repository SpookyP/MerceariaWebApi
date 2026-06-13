using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Domain.Entities
{
    public class Produto
    {
        //Sugiro usar GUIDs ou Inteiros.Vamos usar int para simplificar.
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int Stock { get; set; }
    }
}
