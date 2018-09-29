using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> Get();
        Categoria Get(int id);
        Categoria Post(Categoria categoria);
        Categoria Put(Categoria categoria);
        void Delete(int id);
        void Dispose();
    }
}
