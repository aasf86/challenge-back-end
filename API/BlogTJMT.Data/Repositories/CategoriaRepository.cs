using BlogTJMT.Common.Resources;
using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        private void ValidaDuplicidade(Categoria categoria)
        {
            var result = (from item in _db.Categorias
                          where item.Descricao == categoria.Descricao && item.Id != categoria.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new Exception($"{MensagensErro.CategoriaDuplicada} {categoria.Descricao}");
        }

        public CategoriaRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Delete(int id)
        {
            _db.Categorias.Remove(_db.Categorias.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Categoria> Get() { return _db.Categorias.ToList(); }

        public Categoria Get(int id) { return _db.Categorias.FirstOrDefault(coluna => coluna.Id == id); }

        public Categoria Post(Categoria categoria)
        {
            ValidationClass.ValidaClasse(categoria);
            ValidaDuplicidade(categoria);

            _db.Categorias.Add(categoria);
            _db.SaveChanges();
            return categoria;
        }

        public Categoria Put(Categoria categoria)
        {
            ValidationClass.ValidaClasse(categoria);
            ValidaDuplicidade(categoria);

            _db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return categoria;
        }
    }
}
