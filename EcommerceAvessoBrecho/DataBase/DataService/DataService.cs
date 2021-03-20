using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.DataBase.DataService
{
    public class DataService : IDataService
    {
        public async Task InicializaDBAsync(IServiceProvider provider)
        {
            var contexto = provider.GetService<AppDbContext>();
            await contexto.Database.MigrateAsync();

            if (await contexto.Set<Produto>().AnyAsync())
                return;

            List<Roupa> roupas = await GetProdutosAsync();

            var produtoRepository = provider.GetService<IProdutoRepository>();
            await produtoRepository.SaveProdutosAsync(roupas);
        }

        private async Task<List<Roupa>> GetProdutosAsync()
        {
            var json = await File.ReadAllTextAsync("produtos.json", Encoding.GetEncoding("iso-8859-1"));
            return JsonConvert.DeserializeObject<List<Roupa>>(json);
        }
    }
}



