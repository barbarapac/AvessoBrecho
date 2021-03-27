using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EcommerceAvessoBrecho.Models
{
    public class Cliente : BaseModel
    {
        public Cliente() { }

        public virtual Pedido Pedido { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter em 5 e 100 caractéres", MinimumLength = 5)]
        [DataMember]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [DataMember]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caractéres")]
        [DataMember]
        public string CPF { get; set; } = "";

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço deve ter em 5 e 200 caractéres", MinimumLength = 5)]
        [DataMember]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [StringLength(100, ErrorMessage = "O barrio deve ter em 5 e 100 caractéres", MinimumLength = 5)]
        [DataMember]
        public string Bairro { get; set; } = "";

        [DataMember]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Municipío é obrigatório")]
        [DataMember]
        public string Municipio { get; set; } = "";

        [Required(ErrorMessage = "UF é obrigatório")]
        [StringLength(2, ErrorMessage = "O UF deve ter em 2 caractéres")]
        [DataMember]
        public string UF { get; set; } = "";

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [DataMember]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "CEP é obrigatório")]
        [DataMember]
        public string CEP { get; set; } = "";

        public Cliente GetClone()
        {
            return new Cliente
            {
                Bairro = this.Bairro,
                CEP = this.CEP,
                Complemento = this.Complemento,
                Email = this.Email,
                Endereco = this.Endereco,
                Municipio = this.Municipio,
                Nome = this.Nome,
                Telefone = this.Telefone,
                UF = this.UF,
                CPF = this.CPF                
            };
        }
    }
}
