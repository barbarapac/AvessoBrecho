using EcommerceAvessoBrecho.DataBase.Context;
using EcommerceAvessoBrecho.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EcommerceAvessoBrecho.Repositories.IRepository
{
    public class SendEmailRepository : BaseRepository<Pedido>, ISendEmailRepository
    {
        private readonly IConfiguration config;

        public SendEmailRepository(IConfiguration configuration, AppDbContext contexto,
               IHttpContextAccessor contextAccessor, IHttpHelper sessionHelper,
               IClienteRepository clienteRepository) : base(configuration, contexto)
        {
            this.config = configuration;
        }

        public void EnviarEmailPedido(Pedido pedido)
        {
            var credenciais = GetCredenciais();
            var infoEmail = GetCorpoMensagemEmail(pedido);
            MailMessage mail = new MailMessage();
            
            mail.From = new MailAddress(credenciais.Email);
            mail.To.Add(pedido.Cliente.Email);
            mail.Subject = infoEmail.Title;
            mail.Body = infoEmail.Body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient(credenciais.StmpClient))
            {
                try
                {
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false; 
                    smtp.Credentials = new NetworkCredential(credenciais.Email, credenciais.Pass);
                    smtp.Send(mail); //PARA ENVIAR EMAIL SÓ DESCOMENTAR AQUI.
                }
                catch (Exception ex){ }
            }
        }

        private Credenciais GetCredenciais() => new Credenciais()
            {
                Email = config.GetSection("Email").GetSection("user").Value,
                Pass = config.GetSection("Email").GetSection("pass").Value,
                StmpClient = config.GetSection("Email").GetSection("stmpClient").Value
            };

        private InfoEmail GetCorpoMensagemEmail(Pedido pedido)
         {
            var infoEmail = new InfoEmail();
            infoEmail.Title = $"Recebemos seu pedido :)";

            StringBuilder mensagem = new StringBuilder();
            mensagem.Append("<b>SEU PEDIDO FOI CONFIRMADO</b> <br>");
            mensagem.Append("<br>");
            mensagem.Append($"<b>Número do pedido:{pedido.Id}</b> <br><br>");
            mensagem.Append($"Olá {pedido.Cliente.Nome}, <br><br>");
            mensagem.Append("Obrigado por comprar na loja online do Avesso Brechó.<br><br>");
            mensagem.Append("A previsão de recebimento será de acordo com a nossa <u>política de entrega</u>, mas para mais informações você pode entrar em contato conosco pelo e-mail: avesso.b@gmail.com <br><br>");
            mensagem.Append("Loja Online Avesso Brechó.<br>");
            mensagem.Append("<br><br>");
            mensagem.Append("<b>RESUMO DO PEDIDO</b> <br><br>");
            mensagem.Append("<b>Endereço de entrega</b><br>");
            mensagem.Append($"{pedido.Cliente.Endereco}, {pedido.Cliente.Bairro}, {pedido.Cliente.Complemento}<br>");
            mensagem.Append($"{pedido.Cliente.Municipio} - {pedido.Cliente.UF} <br><br><br>");
            mensagem.Append("<b>Pedido</b><br>");
            
            foreach (var item in pedido.ItensPedido)
            {
                mensagem.Append($"{item.Produto.Nome} | {item.Produto.Marca} <br>");
            }

            mensagem.Append("<br><br>");
            mensagem.Append("<b>Custo do pedido</b><br>");
            mensagem.Append("<table border=\"1\" >");
            mensagem.Append("<tr><td> Subtotal </td><td> Desconto </td><td> Total </td></tr>");
            mensagem.Append($"<tr><td> R${pedido.VlTotalPedido + pedido.VlDesconto} </td><td> R${pedido.VlDesconto} </td><td> R${pedido.VlTotalPedido} </td></tr>");
            mensagem.Append("</table>");
            infoEmail.Body = mensagem.ToString();

            return infoEmail;
        }
    }

    class Credenciais
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string StmpClient { get; set; }
    }

    class InfoEmail
    {
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
