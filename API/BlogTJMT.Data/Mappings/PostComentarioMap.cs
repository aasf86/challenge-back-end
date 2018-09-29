using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class PostComentarioMap : EntityTypeConfiguration<PostComentario>
    {
        public PostComentarioMap()
        {
            ToTable("PostComentario");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired().HasMaxLength(350);
            Property(coluna => coluna.Data).IsRequired();

            HasRequired(coluna => coluna.Post);
            HasRequired(coluna => coluna.Usuario).WithMany().WillCascadeOnDelete(false);
        }
    }
}
