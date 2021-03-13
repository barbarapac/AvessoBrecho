using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcommerceAvessoBrecho.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly IConfiguration configuration;
        protected readonly AppDbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(IConfiguration configuration, AppDbContext context)
        {
            this.configuration = configuration;
            this.context = context;
            this.dbSet = context.Set<T>();
        }
    }
}
