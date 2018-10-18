using BlogTJMT.Common.Resources;
using BlogTJMT.Common.Security;
using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        private void ValidaDuplicidade(Usuario usuario)
        {
            var result = (from item in _db.Usuarios
                          where item.Email == (usuario.Email) && item.Id != usuario.Id
                          select item).FirstOrDefault();

            if (result != null) throw new Exception($"{MensagensErro.UsuarioDuplicado} {usuario.Email}");
        }

        public UsuarioRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(_db.Usuarios.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario Post(Usuario usuario)
        {
            ValidationClass.ValidaClasse(usuario);

            ValidaDuplicidade(usuario);

            usuario.Senha = usuario.Senha.Encrypta();
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            return usuario;
        }

        public Usuario Put(Usuario usuario)
        {
            ValidationClass.ValidaClasse(usuario);

            ValidaDuplicidade(usuario);

            usuario.Senha = usuario.Senha.Encrypta();
            _db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return usuario;
        }
    }
}
