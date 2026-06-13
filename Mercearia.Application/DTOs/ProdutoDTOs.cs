using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Application.DTOs
{
    // O que recebes para CRIAR um produto
    public class CriarProdutoRequest
    {
        // Podemos usar DataAnnotations aqui para validar a entrada!
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        [Range(0.01, 10000, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }
        // Nota: Não pedimos o ID (é automático)
        // Nota: Vamos assumir que o Stock inicial é sempre 0 ou gerido noutro lugar,
        // por isso nem sequer pedimos Stock aqui para demonstração.
    }
    // O que devolves para LEITURA
    public class ProdutoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        // Vamos supor que, por segurança comercial, não queremos mostrar
        // a quantidade exata de stock na listagem pública.
        // Por isso, a propriedade Stock NÃO existe neste DTO.
    }
}
