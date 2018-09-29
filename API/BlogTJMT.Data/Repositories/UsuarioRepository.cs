using System.Collections.Generic;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;

namespace BlogTJMT.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public List<Usuario> Get()
        {
            throw new System.NotImplementedException();
        }

        public Usuario Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Post(Categoria usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Put(Categoria usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}
