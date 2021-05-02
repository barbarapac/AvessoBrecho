using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EcommerceAvessoBrecho.Models
{
    public class Produto : BaseModel
    {
        public Produto() { }

        public Produto(string codigo, string nome, string descricao, decimal preco, 
            Categoria categoria, string marca, bool promocao, decimal precoPromocional, string subDescricao, string tamanho, string condicao)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.DataCadastro = DateTime.Now;
            this.Categoria = categoria;
            this.Marca = marca;
            this.Promocao = promocao;
            this.SubDescricao = subDescricao;
            this.PrecoPromocional = precoPromocional;
            this.Tamanho = tamanho;
            this.Condicao = condicao;
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
        [Required(ErrorMessage = "Marca é obrigatória")]
        [StringLength(60, ErrorMessage = "Descrição deve ter em 1 e 60 caractéres", MinimumLength = 5)]
        public string Marca { get; private set; }

        [DataMember]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PrecoPromocional { get; private set; } = 0;

        [DataMember]
        [Required(ErrorMessage = "Sub descrição é obrigatória")]
        [StringLength(300, ErrorMessage = "Sub descrição deve ter em 5 e 300 caractéres", MinimumLength = 5)]
        public string SubDescricao { get; private set; }

        [DataMember]
        public bool Disponivel { get; set; } = true;

        [DataMember]
        public bool Promocao { get; set; } = false;

        [StringLength(5, ErrorMessage = "Tamanho deve ter em 1 e 5 caractéres", MinimumLength = 1)]
        [DataMember]
        public string Tamanho { get; set; } = "";

        [StringLength(200, ErrorMessage = "Tamanho deve ter em 1 e 200 caractéres", MinimumLength = 1)]
        [DataMember]
        public string Condicao { get; set; } = "";

        [DataMember]
        public DateTime DataCadastro { get; private set; }

        [Required]
        [DataMember]
        public Categoria Categoria { get; private set; }
    }
}
