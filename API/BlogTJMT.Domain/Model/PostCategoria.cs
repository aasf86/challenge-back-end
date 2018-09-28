namespace BlogTJMT.Domain.Model
{
    public class PostCategoria
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoriaId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
