using EcommerceAvessoBrecho.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceAvessoBrecho.Controllers
{
    public class ConsultaCepController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConsultaCepController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> BuscaCep([FromBody] string cep)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri urlRequisicao = new Uri(_config.GetSection("Urls").GetSection("ApiCep").Value + cep + "/json");
                HttpResponseMessage responseMessage = await client.GetAsync(urlRequisicao);
                string response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    CepDTO cepdto = JsonConvert.DeserializeObject<CepDTO>(response);

                    if (cepdto.cep != null)
                    {
                        cepdto.cep = cepdto.cep.Replace("-", "");
                        return Ok(cepdto);
                    }

                    return NoContent();
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
