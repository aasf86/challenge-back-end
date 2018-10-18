namespace BlogTJMT.Domain.Model
{
    public class PerfilPermicao
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int PermicaoId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Permicao Permicao { get; set; }
    }
}
