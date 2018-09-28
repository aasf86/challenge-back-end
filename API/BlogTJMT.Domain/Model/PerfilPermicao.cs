namespace BlogTJMT.Domain.Model
{
    public class PerfilPermicao
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int PerfilPermicaoId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual PerfilPermicao PerfilPermicao { get; set; }
    }
}
