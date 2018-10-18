using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IPerfilRepository
    {
        List<Perfil> Get();
        Perfil Get(int id);
    }
}
