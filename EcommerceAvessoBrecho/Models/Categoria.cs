using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EcommerceAvessoBrecho.Models
{
    public class Categoria : BaseModel
    {
        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(40, ErrorMessage = "O nome deve ter em 5 e 40 caractéres", MinimumLength = 5)]
        //[DataMember]
        public string Nome { get; private set; } = "";
    }
}
