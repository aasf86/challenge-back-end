using System.Collections.Generic;

namespace BlogTJMT.Domain.Model
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual List<Permicao> Permicoes { get; set; }
    }
}
