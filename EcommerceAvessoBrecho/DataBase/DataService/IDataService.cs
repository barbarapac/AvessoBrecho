using System;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.DataBase.DataService
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}
