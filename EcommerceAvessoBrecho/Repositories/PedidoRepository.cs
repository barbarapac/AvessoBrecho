using System;
using System.Threading.Tasks;
using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using Microsoft.Extensions.Configuration;

namespace EcommerceAvessoBrecho.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IConfiguration configuration, AppDbContext context): base(configuration, context) { }

        public Task AddItemAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetPedidoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> UpdateCadastroAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
