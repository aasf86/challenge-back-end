using System;

namespace BlogTJMT.Domain.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public int Visualizacoes { get; set; }
        public int Curtidas { get; set; }
        public int AutorId { get; set; }
        public virtual Usuario Autor { get; set; }
        public DateTime Data { get; set; }
        public string ImagemDestaque { get; set; }
    }
}
