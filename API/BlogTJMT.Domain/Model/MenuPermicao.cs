namespace BlogTJMT.Domain.Model
{
    public class MenuPermicao
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int PerfilPermicaoId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual PerfilPermicao PerfilPermicao { get; set; }
    }
}
