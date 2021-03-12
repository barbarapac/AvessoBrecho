# EcommerceAvessoBrecho
## Aplicação Web ASP.Net Core, Ecommerce Avesso Brechó
Projeto ACCH matéria de Oficina de Software . (UTFPR-2021)

### Tecnologias utilizadas:
- .Net Cores 5.0
    > NET Core é um framework livre e de código aberto para os sistemas operacionais Windows, Linux e macOS. É um sucessor de código aberto do .NET Framework. O projeto é desenvolvido principalmente pela Microsoft e lançado com a Licença MIT.
- ASP.NET Core MVC 5.0
    > A estrutura do ASP.NET Core MVC é uma estrutura de apresentação leve, de software livre e altamente testável, otimizada para uso com o ASP.NET Core. ASP.NET Core MVC fornece uma maneira com base em padrões para criar sites dinâmicos que habilitam uma separação limpa de preocupações. Ele lhe dá controle total sobre a marcação, dá suporte ao desenvolvimento amigável a TDD e usa os padrões da web mais recentes.
- Microsoft SQL Server
    > O Microsoft SQL Server é um sistema gerenciador de Banco de dados relacional desenvolvido pela Sybase em parceria com a Microsoft. Esta parceria durou até 1994, com o lançamento da versão para Windows NT e desde então a Microsoft mantém a manutenção do produto.

### Requisitos para a compilação do projeto:
- Instalação .Net Core 5.0 SDK.
    > https://dotnet.microsoft.com/download/visual-studio-sdks
- Instalação IDE visual studio.
    > https://code.visualstudio.com/download

### Instruções para a execução do projeto:
- Abrir a IDE do Visual Studio (você pode abrir clicando `EcommerceAvessoBrecho.sln` localizado na pasta raiz do projeto).
- Aguarde a restauração das dependências; 
- No menu Ferramentas -> Gerenciador de pacotes NUGet -> Criar em 'Console do Gerenciado de pacotes'
    - Rodar o seguinte comando `Update-Database` (esse comando cria o banco de dados utilizando o .NetFramework)
    - Você podera visualizar o banco de dados pelo menu: Exibir -> clique em SQL Server Object Explorer
- Executar o projeto através ISS Express.
- Pagina inicial da aplicação será aberta no seu navegador padrão.

**OU**

- Abrir diretorio **EcommerceAvessoBrecho** pelo terminal, rode o comando `dotnet run --project EcommerceAvessoBrecho.csproj`;
