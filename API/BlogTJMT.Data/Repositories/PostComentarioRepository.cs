using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class PostComentarioRepository : IPostComentarioRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public void Delete(int id)
        {
            _db.PostComentarios.Remove(_db.PostComentarios.Find(id));
            _db.SaveChanges();
        }

        public void Dispose() => _db.Dispose();
        public List<PostComentario> Get() { return _db.PostComentarios.ToList(); }
        public PostComentario Get(int id) { return _db.PostComentarios.FirstOrDefault(coluna => coluna.Id == id); }
        public PostComentario GetPorUsuario(int usuarioId) { return _db.PostComentarios.FirstOrDefault(coluna => coluna.UsuarioId == usuarioId); }

        public PostComentario Post(PostComentario categoria)
        {
            _db.PostComentarios.Add(categoria);
            _db.SaveChanges();

            return categoria;
        }

        public PostComentario Put(PostComentario categoria)
        {
            _db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return categoria;
        }
    }
}
