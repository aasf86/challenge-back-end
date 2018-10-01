using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Post(Usuario usuario);
        Usuario Put(Usuario usuario);
        void Delete(int id);
        void Dispose();
    }
}
