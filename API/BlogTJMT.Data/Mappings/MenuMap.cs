using BlogTJMT.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace BlogTJMT.Data.Mappings
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Nome).IsRequired().HasMaxLength(40);
            Property(coluna => coluna.Enum).IsRequired();
        }
    }
}
