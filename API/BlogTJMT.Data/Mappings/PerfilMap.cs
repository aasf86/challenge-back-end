using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired().HasMaxLength(120);
        }
    }
}
