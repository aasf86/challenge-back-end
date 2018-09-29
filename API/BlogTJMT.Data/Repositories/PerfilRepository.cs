using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public PerfilRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public List<Perfil> Get() { return _db.Perfis.ToList(); }
        public Perfil Get(int id) { return _db.Perfis.FirstOrDefault(coluna => coluna.Id == id); }
        public Perfil Post(Perfil perfil)
        {
            ValidationClass.ValidaClasse(perfil);
            _db.Perfis.Add(perfil);
            _db.SaveChanges();
            return perfil;
        }

        public Perfil Put(Perfil perfil)
        {
            ValidationClass.ValidaClasse(perfil);
            _db.Entry(perfil).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return perfil;
        }

        public void Delete(int id)
        {
            _db.Perfis.Remove(_db.Perfis.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        private void ValidaDuplicidade(Perfil perfil)
        {
            var result = (from item in _db.Perfis
                          where item.Descricao == (perfil.Descricao) && item.Id != perfil.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new Exception($"Já existe um perfil cadastrado com está descrição: {perfil.Descricao}");

        }
    }
}
