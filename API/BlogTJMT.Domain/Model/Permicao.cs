using BlogTJMT.Common.Enum;

namespace BlogTJMT.Domain.Model
{
    public class Permicao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public PermicaoEnum Enum { get; set; }
    }
}
