using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();
        Usuario Get(int id);
        Usuario Post(Categoria usuario);
        Usuario Put(Categoria usuario);
        void Delete(int id);
        void Dispose();
    }
}
