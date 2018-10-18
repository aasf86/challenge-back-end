using System.ComponentModel;

namespace BlogTJMT.Common.Enum
{
    public enum MenuEnum
    {
        [Description("Início")]
        Inicio = 1,
        [Description("Posts")]
        Posts = 2,
        [Description("Categorias")]
        Categorias = 3,
        [Description("Login")]
        Login = 4,
        [Description("Administração de posts")]
        AdminPosts = 5,
        [Description("Administracao de Comentários")]
        AdminComentarios = 6,
        [Description("Administração de Categorias")]
        AdminCategorias = 7,
        [Description("Administração de Perfis")]
        AdminPerfil = 8,
        [Description("Adminstração de Usuários")]
        AdminUsuarios = 9
    }
}
