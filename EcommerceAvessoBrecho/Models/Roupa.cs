namespace EcommerceAvessoBrecho.Models
{
    public class Roupa
    {
        public string Codigo;
        public string Nome;
        public string Descricao;
        public decimal Preco;
        public string Categoria;
        public string SubDescricao;
        public bool Promocao;
        public decimal PrecoPromocional;
        public string Marca { get; set; }
    }
}
