using System;

namespace BlogTJMT.Domain.Model
{
    public class PostComentario
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int PostId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Post Post { get; set; }
    }
}
