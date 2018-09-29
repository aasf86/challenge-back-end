using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class PostCategoriaMap : EntityTypeConfiguration<PostCategoria>
    {
        public PostCategoriaMap()
        {
            ToTable("PostCategoria");

            HasKey(coluna => coluna.Id);

            HasRequired(coluna => coluna.Categoria);
            HasRequired(coluna => coluna.Post);
        }
    }
}
