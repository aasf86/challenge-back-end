using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class PerfilPermicaoMap : EntityTypeConfiguration<PerfilPermicao>
    {
        public PerfilPermicaoMap()
        {
            ToTable("PerfilPermicao");

            HasKey(coluna => coluna.Id);

            HasRequired(coluna => coluna.Perfil);
            HasRequired(coluna => coluna.Permicao);
        }
    }
}
