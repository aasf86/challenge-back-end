using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class PostComentarioRepository : IPostComentarioRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public PostComentarioRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Delete(int id)
        {
            _db.PostComentarios.Remove(_db.PostComentarios.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<PostComentario> Get(int id)
        {
            return _db.PostComentarios
                            .Include(nameof(Post))
                            .Where(coluna => coluna.PostId == id).ToList();
        }

        public PostComentario GetEspecifico(int id) { return _db.PostComentarios.FirstOrDefault(coluna => coluna.Id == id); }

        public PostComentario GetPorUsuario(int usuarioId)
        {
            return _db.PostComentarios.FirstOrDefault(coluna => coluna.UsuarioId == usuarioId);
        }

        public PostComentario Post(PostComentario postComentario)
        {
            ValidationClass.ValidaClasse(postComentario);
            _db.PostComentarios.Add(postComentario);
            _db.SaveChanges();

            return postComentario;
        }

        public PostComentario Put(PostComentario postComentario)
        {
            ValidationClass.ValidaClasse(postComentario);
            _db.Entry(postComentario).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return postComentario;
        }
    }
}
