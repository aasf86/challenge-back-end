using BlogTJMT.Common.Enum;
using BlogTJMT.Domain.Model;
using System.Data.Entity;

namespace BlogTJMT.Data.DataContexts
{
    public class BlogTJMTDataContextInitializer : DropCreateDatabaseIfModelChanges<BlogTJMTDataContext>
    {
        protected override void Seed(BlogTJMTDataContext context)
        {
            context.Perfis.Add(new Perfil { Id = 1, Descricao = "Administrador" });
            context.Perfis.Add(new Perfil { Id = 2, Descricao = "Editor" });
            context.Perfis.Add(new Perfil { Id = 3, Descricao = "Assinante" });
            context.SaveChanges();

            context.Permicoes.Add(new Permicao { Id = 1, Descricao = "Possui todos os direitos sobre todas as funções.", Enum = PermicaoEnum.Admin });
            context.Permicoes.Add(new Permicao { Id = 2, Descricao = "Possui o direito de editar seu perfil, categorias, postagens e gerenciar comentários.", Enum = PermicaoEnum.Editor });
            context.Permicoes.Add(new Permicao { Id = 3, Descricao = "Possui o direito de editar seu perfil e visualizar os posts.", Enum = PermicaoEnum.Assinante });
            context.SaveChanges();

            context.PerfilPermicoes.Add(new PerfilPermicao { Id = 1, PerfilId = 1, PermicaoId = 1 });
            context.PerfilPermicoes.Add(new PerfilPermicao { Id = 2, PerfilId = 2, PermicaoId = 2 });
            context.PerfilPermicoes.Add(new PerfilPermicao { Id = 3, PerfilId = 3, PermicaoId = 3 });
            context.SaveChanges();

            context.Menus.Add(new Menu { Id = 1, Nome = "Início", Enum = MenuEnum.Inicio });
            context.Menus.Add(new Menu { Id = 2, Nome = "Posts", Enum = MenuEnum.Posts });
            context.Menus.Add(new Menu { Id = 3, Nome = "Categorias", Enum = MenuEnum.Categorias });
            context.Menus.Add(new Menu { Id = 4, Nome = "Login", Enum = MenuEnum.Login });
            context.Menus.Add(new Menu { Id = 5, Nome = "Posts", Enum = MenuEnum.AdminPosts });
            context.Menus.Add(new Menu { Id = 6, Nome = "Comentários", Enum = MenuEnum.AdminComentarios });
            context.Menus.Add(new Menu { Id = 7, Nome = "Categorias", Enum = MenuEnum.AdminCategorias });
            context.Menus.Add(new Menu { Id = 8, Nome = "Perfil", Enum = MenuEnum.AdminPerfil });
            context.Menus.Add(new Menu { Id = 9, Nome = "Usuários", Enum = MenuEnum.AdminUsuarios });
            context.SaveChanges();

            context.MenuPermicoes.Add(new MenuPermicao { Id = 1, MenuId = 1, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 2, MenuId = 1, PerfilPermicaoId = 2 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 3, MenuId = 1, PerfilPermicaoId = 3 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 4, MenuId = 2, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 5, MenuId = 2, PerfilPermicaoId = 2 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 6, MenuId = 2, PerfilPermicaoId = 3 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 7, MenuId = 3, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 8, MenuId = 3, PerfilPermicaoId = 2 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 9, MenuId = 3, PerfilPermicaoId = 3 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 10, MenuId = 4, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 11, MenuId = 4, PerfilPermicaoId = 2 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 12, MenuId = 4, PerfilPermicaoId = 3 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 13, MenuId = 5, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 14, MenuId = 5, PerfilPermicaoId = 2 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 15, MenuId = 6, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 16, MenuId = 6, PerfilPermicaoId = 2 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 17, MenuId = 7, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 18, MenuId = 7, PerfilPermicaoId = 2 });

            context.MenuPermicoes.Add(new MenuPermicao { Id = 19, MenuId = 8, PerfilPermicaoId = 1 });
            context.MenuPermicoes.Add(new MenuPermicao { Id = 19, MenuId = 9, PerfilPermicaoId = 1 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
