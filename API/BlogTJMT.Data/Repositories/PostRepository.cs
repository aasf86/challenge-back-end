using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public PostRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Delete(int id)
        {
            _db.Posts.Remove(_db.Posts.Find(id));
            _db.SaveChanges();

            RemoveComentarios(id);
            RemoveVinculosCategoria(id);
        }

        private void RemoveVinculosCategoria(int id)
        {
            var result = _db.PostCategorias.FirstOrDefault(coluna => coluna.Post.Id == id);
            _db.PostCategorias.Remove(result);
            _db.SaveChanges();
        }

        private void RemoveComentarios(int id)
        {
            var result = _db.PostComentarios.FirstOrDefault(coluna => coluna.Post.Id == id);
            _db.PostComentarios.Remove(result);
            _db.SaveChanges();
        }

        public void Dispose() => _db.Dispose();
        public List<Post> Get()
        {
            return _db.Posts.Include(nameof(Usuario)).Include($"{nameof(Usuario)}.{nameof(Perfil)}").ToList();
        }

        public List<Post> Get(string titulo)
        {
            return _db.Posts
                        .Include(nameof(Usuario))
                        .Include($"{nameof(Usuario)}.{nameof(Perfil)}")
                        .Where(coluna => coluna.Titulo.Contains(titulo)).ToList();
        }

        public Post Get(int id) { return _db.Posts.Include(nameof(Usuario)).Include($"{nameof(Usuario)}.{nameof(Perfil)}").FirstOrDefault(coluna => coluna.Id == id); }

        public List<Post> GetMaisCurtidas()
        {
            var result = _db.Posts
                                .Include(nameof(Usuario))
                                .Include($"{nameof(Usuario)}.{nameof(Perfil)}")
                                .ToList().OrderBy(coluna => coluna.Curtidas);
            return result.ToList();
        }

        public List<Post> GetMaisVisualizacoes()
        {
            var result = _db.Posts
                                .Include(nameof(Usuario))
                                .Include($"{nameof(Usuario)}.{nameof(Perfil)}")
                                .ToList().OrderBy(coluna => coluna.Visualizacoes);
            return result.ToList();
        }

        public Post Post(Post post)
        {
            ValidationClass.ValidaClasse(post);
            _db.Posts.Add(post);
            _db.SaveChanges();

            var postCategoria = new PostCategoria();
            post.Categorias.ForEach(campo => SalvaPostCategoria(campo, post));

            return post;
        }

        private void SalvaPostCategoria(Categoria categoria, Post post)
        {
            _db.PostCategorias.Add(new PostCategoria
            {
                CategoriaId = categoria.Id,
                PostId = post.Id
            });
            _db.SaveChanges();
        }

        public Post Put(Post post)
        {
            ValidationClass.ValidaClasse(post);
            _db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return post;
        }
    }
}
