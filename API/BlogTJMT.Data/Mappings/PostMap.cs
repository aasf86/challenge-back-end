using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Post");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Titulo).IsRequired().HasMaxLength(60);
            Property(coluna => coluna.Descricao).IsRequired().HasMaxLength(120);
            Property(coluna => coluna.Conteudo).IsRequired().HasMaxLength(650);
            Property(coluna => coluna.ImagemDestaque).HasColumnType("nvarchar(max)");

            HasRequired(coluna => coluna.Usuario);
        }
    }
}
