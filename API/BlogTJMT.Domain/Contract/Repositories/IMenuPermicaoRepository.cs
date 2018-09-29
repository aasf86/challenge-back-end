using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IMenuPermicaoRepository
    {
        List<MenuPermicao> GetPorUsuario(int usuarioId);
        List<MenuPermicao> GetPorPerfil(int perfilId);
        List<MenuPermicao> GetPorPermicao(int permicaoId);
        void Dispose();
    }
}
