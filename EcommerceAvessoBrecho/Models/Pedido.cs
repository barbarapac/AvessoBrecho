using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAvessoBrecho.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cliente = new Cliente();
        }

        public Pedido(Cliente cliente)
        {
            Cliente = cliente;
        }

        [Column(TypeName = "decimal(8,2)")]
        public decimal VlTotalPedido { get; set; }

        public DateTime DataCadastro { get; set; }
        public List<ItemPedido> ItensPedido { get; private set; } = new List<ItemPedido>();

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [Required]
        public virtual Cliente Cliente { get; private set; }

    }
}
