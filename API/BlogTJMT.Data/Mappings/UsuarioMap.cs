using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Nome).IsRequired().HasMaxLength(50);
            Property(coluna => coluna.Sobrenome).IsRequired().HasMaxLength(50);
            Property(coluna => coluna.Email).IsRequired().HasMaxLength(120);
            Property(coluna => coluna.DataNascimento).IsRequired();
            Property(coluna => coluna.Senha).IsRequired().HasMaxLength(32);

            HasRequired(coluna => coluna.Perfil);
        }
    }
}
