using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public UsuarioRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(_db.Usuarios.Find(id));
            _db.SaveChanges();
        }

        public void Dispose() => _db.Dispose();
        public List<Usuario> Get() { return _db.Usuarios.ToList(); }
        public Usuario Get(int id) { return _db.Usuarios.FirstOrDefault(coluna => coluna.Id == id); }

        public Usuario Post(Usuario usuario)
        {
            ValidationClass.ValidaClasse(usuario);
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            return usuario;
        }

        public Usuario Put(Usuario usuario)
        {
            _db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return usuario;
        }

        private void ValidaDuplicidade(Usuario usuario)
        {
            var result = (from item in _db.Usuarios
                          where item.Email == (usuario.Email) && item.Id != usuario.Id
                          select item).FirstOrDefault();

            if (result != null) throw new Exception($"Já existe um usuário cadastrado com este e-mail: {usuario.Email}");
        }
    }
}
