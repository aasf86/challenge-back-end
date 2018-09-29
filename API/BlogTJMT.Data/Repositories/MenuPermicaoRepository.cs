using System.Collections.Generic;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;

namespace BlogTJMT.Data.Repositories
{
    public class MenuPermicaoRepository : IMenuPermicaoRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public List<MenuPermicao> GetPorPerfil(int perfilId)
        {
            throw new System.NotImplementedException();
        }

        public List<MenuPermicao> GetPorPermicao(int permicaoId)
        {
            throw new System.NotImplementedException();
        }

        public List<MenuPermicao> GetPorUsuario(int usuarioId)
        {
            throw new System.NotImplementedException();
        }
    }
}
