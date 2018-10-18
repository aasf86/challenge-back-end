using System;

namespace BlogTJMT.Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Descricao { get; set; }
        public string Senha { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
