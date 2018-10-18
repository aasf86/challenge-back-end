using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class PermicaoMap : EntityTypeConfiguration<Permicao>
    {
        public PermicaoMap()
        {
            ToTable("Permicao");

            HasKey(coluna => coluna.Id);

            Property(coluna => coluna.Descricao).IsRequired().HasMaxLength(120);
            Property(coluna => coluna.Enum).IsRequired();
        }
    }
}
