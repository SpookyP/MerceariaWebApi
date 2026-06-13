using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercearia.Application.DTOs
{
    // O que recebes para CRIAR um Fornecedor
    public class CriarFornecedorRequest
    {
        // Podemos usar DataAnnotations aqui para validar a entrada!
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O nif é obrigatório.")]
        [StringLength(9, ErrorMessage = "O nif tem de ter 9 caracteres.")]
        [MinLength(9, ErrorMessage = "O nif tem de ter 9 caracteres.")]
        public string Nif { get; set; } = string.Empty;
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; } = string.Empty;

        // Nota: Não pedimos o ID (é automático)
        // Nota: Vamos assumir que o Fornecedor é Criado por default em Ativo
    }
    // O que devolves para LEITURA
    public class FornecedorResponseMultiple
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Nif { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class FornecedorResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Nif { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }


    public class EditarFornecedorRequest
    {
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string? Nome { get; set; }

        [StringLength(9, ErrorMessage = "O nif tem de ter 9 caracteres.")]
        [MinLength(9, ErrorMessage = "O nif tem de ter 9 caracteres.")]
        public string? Nif { get; set; }

        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string? Email { get; set; }
    }
}
