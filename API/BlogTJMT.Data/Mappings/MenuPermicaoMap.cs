using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class MenuPermicaoMap : EntityTypeConfiguration<MenuPermicao>
    {
        public MenuPermicaoMap()
        {
            ToTable("MenuPermicao");

            HasKey(coluna => coluna.Id);

            HasRequired(coluna => coluna.Menu);
            HasRequired(coluna => coluna.PerfilPermicao);
        }
    }
}
