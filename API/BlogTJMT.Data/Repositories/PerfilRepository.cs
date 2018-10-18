using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        private void SalvarPermicoes(Permicao campo, Perfil perfil)
        {
            _db.PerfilPermicoes.Add(new PerfilPermicao
            {
                PerfilId = perfil.Id,
                PermicaoId = campo.Id
            });

            _db.SaveChanges();
        }

        private void ExcluiPerfilPermicao(int id)
        {
            _db.PerfilPermicoes.Remove(_db.PerfilPermicoes.FirstOrDefault(coluna => coluna.PerfilId == id));
            _db.SaveChanges();
        }

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

            perfil.Permicoes.ForEach(campo => SalvarPermicoes(campo, perfil));

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

            ExcluiPerfilPermicao(id);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
