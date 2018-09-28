using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTJMT.Common.Enum
{
    public enum PermicaoEnum
    {
        [Description("Possui todos os direitos sobre todas as funções.")]
        Admin = 1,
        [Description("Possui o direito de editar seu perfil, categorias, postagens e gerenciar comentários.")]
        Editor = 2,
        [Description("Possui o direito de editar seu perfil e visualizar os posts.")]
        Assinante = 3,
    }
}
