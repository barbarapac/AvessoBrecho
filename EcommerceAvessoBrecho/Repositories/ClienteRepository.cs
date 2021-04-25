using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration, AppDbContext context) 
            : base(configuration, context) { }

        public async Task<Cliente> UpdateAsync(int clienteId, Cliente novoCliente)
        {
            var cadastroDB = dbSet.Where(c => c.Id == clienteId)
                 .SingleOrDefault();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCliente);
            await context.SaveChangesAsync();
            return cadastroDB;
        }
    }
}
