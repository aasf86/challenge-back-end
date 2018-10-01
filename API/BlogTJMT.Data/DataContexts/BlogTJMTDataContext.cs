using BlogTJMT.Data.Mappings;
using BlogTJMT.Domain.Model;
using System.Data.Entity;

namespace BlogTJMT.Data.DataContexts
{
    public class BlogTJMTDataContext : DbContext
    {
        public BlogTJMTDataContext() : base("BlogTJMTConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PerfilPermicao> PerfilPermicoes { get; set; }
        public DbSet<Permicao> Permicoes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComentario> PostComentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new PerfilPermicaoMap());
            modelBuilder.Configurations.Add(new PermicaoMap());
            modelBuilder.Configurations.Add(new PostComentarioMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
