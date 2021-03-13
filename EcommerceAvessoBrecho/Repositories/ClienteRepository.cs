using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration, AppDbContext context) 
            : base(configuration, context) { }

        public Task<Cliente> UpdateAsync(int clienteId, Cliente novoCliente)
        {
            throw new NotImplementedException();
        }
    }
}
