namespace BlogTJMT.Data.Migrations
{
    using BlogTJMT.Common.Enum;
    using BlogTJMT.Domain.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogTJMT.Data.DataContexts.BlogTJMTDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogTJMT.Data.DataContexts.BlogTJMTDataContext context)
        {
            context.Perfis.AddOrUpdate(new Perfil { Id = 1, Descricao = "Administrador" });
            context.Perfis.AddOrUpdate(new Perfil { Id = 2, Descricao = "Editor" });
            context.Perfis.AddOrUpdate(new Perfil { Id = 3, Descricao = "Assinante" });

            context.Permicoes.AddOrUpdate(new Permicao { Id = 1, Descricao = "Possui todos os direitos sobre todas as funções.", Enum = PermicaoEnum.Admin });
            context.Permicoes.AddOrUpdate(new Permicao { Id = 2, Descricao = "Possui o direito de editar seu perfil, categorias, postagens e gerenciar comentários.", Enum = PermicaoEnum.Editor });
            context.Permicoes.AddOrUpdate(new Permicao { Id = 3, Descricao = "Possui o direito de editar seu perfil e visualizar os posts.", Enum = PermicaoEnum.Assinante });

            context.PerfilPermicoes.AddOrUpdate(new PerfilPermicao { Id = 1, PerfilId = 1, PermicaoId = 1 });
            context.PerfilPermicoes.AddOrUpdate(new PerfilPermicao { Id = 2, PerfilId = 2, PermicaoId = 2 });
            context.PerfilPermicoes.AddOrUpdate(new PerfilPermicao { Id = 3, PerfilId = 3, PermicaoId = 3 });
        }
    }
}
