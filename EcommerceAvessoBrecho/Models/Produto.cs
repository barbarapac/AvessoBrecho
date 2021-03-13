using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EcommerceAvessoBrecho.Models
{
    public class Produto : BaseModel
    {
        public Produto() { }

        public Produto(string codigo, string nome, string descricao, decimal preco, Categoria categoria)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.DataCadastro = DateTime.Now;
            this.Categoria = categoria;
        }

        [DataMember]
        [Required(ErrorMessage = "Código é obrigatório")]
        public string Codigo { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(80, ErrorMessage = "Nome deve ter em 5 e 80 caractéres", MinimumLength = 5)]
        public string Nome { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(300, ErrorMessage = "Descrição deve ter em 5 e 300 caractéres", MinimumLength = 5)]
        public string Descricao { get; private set; }

        [DataMember]
        [Column(TypeName = "decimal(8,2)")]
        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; private set; }

        [DataMember]
        public DateTime DataCadastro { get; private set; }

        [Required]
        [DataMember]
        public Categoria Categoria { get; private set; }
    }
}
