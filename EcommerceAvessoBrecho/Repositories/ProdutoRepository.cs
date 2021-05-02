using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using EcommerceAvessoBrecho.ViewsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration, AppDbContext context)
            : base(configuration, context) { }

        public async Task<BuscaProdutosViewModel> GetProdutoById(int id)
        {
            IQueryable<Produto> query = dbSet;
            return new BuscaProdutosViewModel(await query.FirstOrDefaultAsync(p => p.Id == id));
        }

        public async Task<IList<Produto>> GetProdutosAsync()
        {
            return await dbSet
                    .Where(p => p.Disponivel == true && !(p.Promocao))
                    .Include(prod => prod.Categoria)
                    .ToListAsync();
        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<Produto> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => (q.Nome.Contains(pesquisa) || q.Categoria.Nome.Contains(pesquisa))
                                         && q.Disponivel == true);
            }

            query = query
                .Include(prod => prod.Categoria);

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }

        public async Task<BuscaProdutosViewModel> GetProdutosPromocaoAsync()
        {
            return new BuscaProdutosViewModel(await dbSet
                .Where(p => p.Disponivel == true && p.Promocao)
                .Include(prod => prod.Categoria)
                .ToListAsync());
        }

        public async Task SaveProdutosAsync(List<Roupa> roupas)
        {
            await SaveCategorias(roupas);

            foreach (var produto in roupas)
            {
                var categoria =
                    await context.Set<Categoria>()
                        .SingleAsync(c => c.Nome == produto.Categoria);

                if (!await dbSet.Where(p => p.Codigo == produto.Codigo).AnyAsync())
                {
                    await dbSet.AddAsync(new Produto(produto.Codigo, produto.Nome, produto.Descricao, 
                        produto.Preco, categoria, produto.Marca, produto.Promocao, 
                        produto.PrecoPromocional, produto.SubDescricao, produto.Tamanho, produto.Condicao));
                }
            }
            await context.SaveChangesAsync();
        }

        private async Task SaveCategorias(List<Roupa> roupas)
        {
            var categorias =
                roupas
                    .OrderBy(l => l.Categoria)
                    .Select(l => l.Categoria)
                    .Distinct();

            foreach (var categoria in categorias)
            {
                var categoriaDB = await context.Set<Categoria>()
                    .SingleOrDefaultAsync(c => c.Nome == categoria);

                if (categoriaDB == null)
                {
                    await context.Set<Categoria>()
                        .AddAsync(new Categoria(categoria));
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
