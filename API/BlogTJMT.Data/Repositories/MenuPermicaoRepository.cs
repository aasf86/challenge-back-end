using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class MenuPermicaoRepository : IMenuPermicaoRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public MenuPermicaoRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Dispose() => _db.Dispose();

        public List<MenuPermicao> GetPorPerfil(int perfilId)
        {
            return _db.MenuPermicoes
                        .Include(nameof(Menu))
                        .Include(nameof(PerfilPermicao))
                        .Include($"{nameof(PerfilPermicao)}.{nameof(Perfil)}")
                        .Where(coluna => coluna.PerfilPermicao.PerfilId == perfilId).ToList();
        }

        public List<MenuPermicao> GetPorPermicao(int permicaoId)
        {
            return _db.MenuPermicoes.Where(coluna => coluna.PerfilPermicao.PermicaoId == permicaoId).ToList();
        }

        public List<MenuPermicao> GetPorUsuario(int usuarioId)
        {
            var user = _db.Usuarios.Find(usuarioId);
            return _db.MenuPermicoes.Where(coluna => coluna.PerfilPermicao.PermicaoId == user.PerfilId).ToList();
        }
    }
}
