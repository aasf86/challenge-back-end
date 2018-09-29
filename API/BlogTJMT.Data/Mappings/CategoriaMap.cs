using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired().HasMaxLength(40);
        }
    }
}
