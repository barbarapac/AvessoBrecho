#pragma checksum "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "442c47fb61692f7c0665a99861a34b6c4cb34e69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_Resumo), @"mvc.1.0.view", @"/Views/Pedido/Resumo.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\_ViewImports.cshtml"
using EcommerceAvessoBrecho;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\_ViewImports.cshtml"
using EcommerceAvessoBrecho.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\_ViewImports.cshtml"
using EcommerceAvessoBrecho.ViewsModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"442c47fb61692f7c0665a99861a34b6c4cb34e69", @"/Views/Pedido/Resumo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d1861ace2474363798c4bdd485993b40bdc95bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_Resumo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResumoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn buttonPrimary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pedido", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FinalizaPedido", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding-top: 9px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn buttonSecundary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "cliente", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
   ViewData["Title"] = "Resumo"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div style=\"margin: 64px 0 64px 80px\">\r\n    <h4>");
#nullable restore
#line 6 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
    Write(Model.pedido.Cliente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", esse é seu resumo.</h4>
</div>

<div style=""height: 1500px"">

    <div class=""div_ClienteCampos"" style=""height: 220px"">
        <div class=""div_ClienteTitulo"">
            <h4>1. Dados Pessoais</h4>
        </div>

        <div style=""padding: 0 25px 0 25px;"">
            <div class=""form-group col-4"" style=""float:left"">
                <label class=""control-label"" for=""nomeCliente"">Nome do Cliente</label>
                <br /><label style=""font-weight:600; color:#474747"">");
#nullable restore
#line 19 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-4\" style=\"float:left\">\r\n                <label class=\"control-label\" for=\"email\">Email</label>\r\n                <br /><label style=\"font-weight:600; color:#474747\">");
#nullable restore
#line 23 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-4\" style=\"float:left\">\r\n                <label class=\"control-label\" for=\"telefone\">Telefone</label>\r\n                <br /><label style=\"font-weight:600; color:#474747\">");
#nullable restore
#line 27 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
            </div>
        </div>
    </div>

    <div class=""div_ClienteCampos"" style=""height: 220px"">
        <div class=""div_ClienteTitulo"" style=""margin-top: 64px"">
            <h4>2. Endereço</h4>
        </div>

        <div style=""padding: 0 25px 0 25px;"">
            <div class=""col-3"" style=""float:left"">
                <label class=""control-label"" for=""endereco"">Endereço</label>
                <br /><label style=""font-weight:600; color:#474747"">");
#nullable restore
#line 40 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.Endereco);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 40 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                                                   Write(Model.pedido.Cliente.Bairro);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-3\" style=\"float:left\">\r\n                <label class=\"control-label\" for=\"complemento\">Cidade</label>\r\n                <br /><label style=\"font-weight:600; color:#474747\">");
#nullable restore
#line 44 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.Municipio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-3\" style=\"float:left\">\r\n                <label class=\"control-label\" for=\"bairro\">CEP</label>\r\n                <br /><label style=\"font-weight:600; color:#474747\">");
#nullable restore
#line 48 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.CEP);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-3\" style=\"float:left\">\r\n                <label class=\"control-label\" for=\"municipio\">Complemento</label>\r\n                <br /><label style=\"font-weight:600; color:#474747\">");
#nullable restore
#line 52 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                Write(Model.pedido.Cliente.Complemento);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
            </div>
        </div>
    </div>

    <div class=""div_ClienteCampos"" style=""margin-bottom: 64px"">
        <div class=""div_ClienteTitulo"" style=""margin-top: 64px"">
            <h4>3. Pedido</h4>
        </div>

        <div class=""row"" id=""div_ResumoCabecalhoTabela"">
            <div class=""col-md-5"">
                Identificador
            </div>
            <div class=""col-md-2"">
                Valor
            </div>
            <div class=""col-md-2"">
                Quantidade
            </div>
            <div class=""col-md-2"">
                Total
            </div>
            <div class=""col-md-1""></div>
        </div>

        <div class=""panel-body"" id=""listaItens"">
");
#nullable restore
#line 79 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
             foreach (var item in Model.pedido.ItensPedido)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row div_ResumoLinhaProdutoTabela\"");
            BeginWriteAttribute("item-id", " item-id=\"", 3372, "\"", 3390, 1);
#nullable restore
#line 81 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
WriteAttributeValue("", 3382, item.Id, 3382, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"col-md-5\" style=\"padding-top: 5px\">");
#nullable restore
#line 82 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                               Write(item.Produto.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-2\" style=\"padding-top: 5px\">R$ ");
#nullable restore
#line 83 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                                                  Write(item.PrecoUnitario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-2\" style=\"padding-top: 5px\">0001</div>\r\n                    <div class=\"col-md-2\" style=\"padding-top: 5px\">\r\n                        R$ <span class=\"pull-right\" subtotal>\r\n                            ");
#nullable restore
#line 87 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                        Write(item.Quantidade * item.PrecoUnitario);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n                </div>            ");
#nullable restore
#line 90 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <label style=""color:white"">.</label>
        </div>

    </div>

    <div class=""div_ClienteCampos"" style=""height: 260px; width: 30%; float: left"">
        <div class=""div_ClienteTitulo"">
            <h4>4. Custo e Envio</h4>
        </div>

        <div>
            <div class=""div_CarrinhoDetalhes"">
                <label>Subtotal</label>
                <div class=""div_CarrinhoDetalhesValor"">
                    R$ <span class=""pull-right"" total>
                        ");
#nullable restore
#line 106 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                    Write(Model.pedido.VlTotalPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </span>
                </div>
            </div>

            <div class=""div_CarrinhoDetalhes"">
                <label>Desconto</label>
                <div class=""div_CarrinhoDetalhesValor"">
                    R$ <span class=""pull-right"" total>
                        ");
#nullable restore
#line 115 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                    Write(Model.pedido.VlDesconto);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </span>
                </div>
            </div>

            <div class=""div_CarrinhoDetalhes"" style=""border-top-style: ridge; padding-top: 20px;"">
                <label style=""margin-top: 6px;"">Total</label>
                <div class=""div_CarrinhoDetalhesValor"" style=""font-size: 20px; font-weight:600"">
                    R$ <span class=""pull-right"" total>
                        ");
#nullable restore
#line 124 "C:\Projetos\AvessoBrecho\EcommerceAvessoBrecho\Views\Pedido\Resumo.cshtml"
                    Write(Model.pedido.VlTotalPedido - Model.pedido.VlDesconto);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </span>
                </div>
            </div>
        </div>
    </div>

    <div class=""div_ClienteCampos"" style=""height: 260px; width:65%; float:right"">
        <div class=""div_ClienteTitulo"">
            <h4>5. Observações</h4>
        </div>

        <div style=""padding: 0 40px 0 40px;"">
            <label>Para os casos de troca ou devolução segue as seguintes condições:</label><br /><br />
            <label>A solicitação deve ocorrer no máximo em 20 dias úteis após o recebimento do produto e o mesmo ainda deve estar em sua embalagem original, acompanhado da etiqueta e sem danos aparentes. Após a confirmação da solicitação será possível optar pelas seguintes opções: produto do mesmo valor, reembolso/estorno ou vale trocas.</label>
        </div>

    </div>

    <div class=""form-group"" id=""div_ClienteBotoes"">
        <span class=""input-group-btn"" style=""float: right; margin-left: 30px; width: 150px"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "442c47fb61692f7c0665a99861a34b6c4cb34e6916710", async() => {
                WriteLiteral("Continuar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </span>\r\n\r\n        <span class=\"input-group-btn\" style=\"float:left; width: 130px\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "442c47fb61692f7c0665a99861a34b6c4cb34e6918438", async() => {
                WriteLiteral("\r\n                Anterior\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </span>\r\n    </div>\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResumoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
