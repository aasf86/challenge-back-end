using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    class CategoriaRepository : ICategoriaRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public void Delete(int id)
        {
            _db.Categorias.Remove(_db.Categorias.Find(id));
            _db.SaveChanges();
        }

        public void Dispose() => _db.Dispose();
        public List<Categoria> Get() { return _db.Categorias.ToList(); }
        public Categoria Get(int id) { return _db.Categorias.FirstOrDefault(coluna => coluna.Id == id); }

        public Categoria Post(Categoria categoria)
        {
            _db.Categorias.Add(categoria);
            _db.SaveChanges();
            return categoria;
        }

        public Categoria Put(Categoria categoria)
        {
            _db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return categoria;
        }
    }
}
