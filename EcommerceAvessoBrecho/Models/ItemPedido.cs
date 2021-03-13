using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EcommerceAvessoBrecho.Models
{
    public class ItemPedido : BaseModel
    {
        public ItemPedido() { }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }

        [Required]
        [DataMember]
        public Produto Produto { get; private set; }

        [Required]
        [DataMember]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PrecoUnitario { get; private set; }

        [Required]
        [DataMember]
        public int Quantidade { get; private set; }

        [DataMember]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}
