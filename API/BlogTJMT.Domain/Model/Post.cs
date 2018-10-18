using System;
using System.Collections.Generic;

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
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime Data { get; set; }
        public string ImagemDestaque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}