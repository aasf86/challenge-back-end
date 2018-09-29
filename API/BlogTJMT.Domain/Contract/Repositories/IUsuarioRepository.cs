using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();
        Usuario Get(int id);
        Usuario Post(Usuario usuario);
        Usuario Put(Usuario usuario);
        void Delete(int id);
        void Dispose();
    }
}
