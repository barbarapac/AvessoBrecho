using EcommerceAvessoBrecho.Models;
using EcommerceAvessoBrecho.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EcommerceAvessoBrecho.Repositories
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;
        public IConfiguration Configuration { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            this.contextAccessor = contextAccessor;
            Configuration = configuration;
        }

        public Cliente GetCadastro()
        {
            string json = contextAccessor.HttpContext.Session.GetString("cliente");
            if (string.IsNullOrWhiteSpace(json))
                return new Cliente();

            return JsonConvert.DeserializeObject<Cliente>(json);
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        public void ResetPedidoId()
        {
            contextAccessor.HttpContext.Session.Remove("pedidoId");
        }

        public void SetCliente(Cliente cliente)
        {
            string json = JsonConvert.SerializeObject(cliente.GetClone());
            contextAccessor.HttpContext.Session.SetString("cliente", json);
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public void ResetClienteId()
        {
            contextAccessor.HttpContext.Session.Remove("cliente");
        }
    }
}
