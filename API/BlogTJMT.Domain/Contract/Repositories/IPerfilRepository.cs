using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IPerfilRepository
    {
        List<Perfil> Get();
        Perfil Get(int id);
        Perfil Post(Perfil perfil);
        Perfil Put(Perfil perfil);
        void Delete(int id);
        void Dispose();
    }
}
