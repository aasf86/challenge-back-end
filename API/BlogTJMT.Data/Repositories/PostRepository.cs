using BlogTJMT.Common.Enum;
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
    public class PostRepository : IPostRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        private void AdicionaVisualizacao(Post result)
        {
            if (result == null) return;

            result.Visualizacoes += 1;
            _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        private void ValidaUsuario(Usuario usuario)
        {
            ValidationClass.ValidaClasse(usuario);

            var result = (from item in _db.Usuarios
                          where item.Email.ToLower() == (usuario.Email.ToLower()) && item.Senha == (usuario.Senha)
                          select item).FirstOrDefault();

            if (result == null)
                throw new Exception(MensagensErro.PostSemUsuario);

            ValidaPermicaoUsuario(result);
        }

        private void ValidaPermicaoUsuario(Usuario usuario)
        {
            var result = (from item in _db.PerfilPermicoes.Include(nameof(Permicao))
                          where item.PerfilId == usuario.PerfilId
                          select item).FirstOrDefault();

            if (!(result.Permicao.Enum == PermicaoEnum.Admin || result.Permicao.Enum == PermicaoEnum.Editor))
                throw new Exception(MensagensErro.UsuarioSemPermicao);
        }

        public void AdicionarCurtida(int id)
        {
            var result = _db.Posts.FirstOrDefault(coluna => coluna.Id == id);
            if (result == null) return;

            result.Curtidas += 1;
            _db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public List<Post> GetTop5()
        {
            return _db.Posts
                        .Include(nameof(Categoria))
                        .OrderByDescending(coluna => coluna.Curtidas).ThenBy(coluna => coluna.Data).Take(5).ToList();
        }

        public List<Post> GetMaisCurtidas()
        {
            var result = _db.Posts
                                .Include(nameof(Categoria))
                                .ToList().OrderBy(coluna => coluna.Curtidas);
            return result.ToList();
        }

        public List<Post> GetMaisVisualizacoes()
        {
            var result = _db.Posts
                                .Include(nameof(Categoria))
                                .ToList().OrderBy(coluna => coluna.Visualizacoes);
            return result.ToList();
        }

        public Post Post(Post post)
        {
            ValidationClass.ValidaClasse(post);

            ValidaUsuario(post.Usuario);
            post.Usuario = null;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return post;
        }

        public PostRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Delete(int id)
        {
            _db.Posts.Remove(_db.Posts.Find(id));
            _db.SaveChanges();

            RemoveComentarios(id);
        }

        private void RemoveComentarios(int id)
        {
            var result = _db.PostComentarios.FirstOrDefault(coluna => coluna.Post.Id == id);
            if (result != null)
            {
                _db.PostComentarios.Remove(result);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Post> Get()
        {
            return _db.Posts
                        .Include(nameof(Categoria))
                        .ToList();
        }

        public List<Post> Get(string titulo)
        {
            return _db.Posts
                        .Include(nameof(Categoria))
                        .Where(coluna => coluna.Titulo.Contains(titulo)).ToList();
        }

        public Post Get(int id)
        {
            var result = _db.Posts
                        .Include(nameof(Categoria))
                        .FirstOrDefault(coluna => coluna.Id == id);

            AdicionaVisualizacao(result);

            return result;
        }

        public Post Put(Post post)
        {
            ValidationClass.ValidaClasse(post);

            ValidaUsuario(post.Usuario);
            post.Usuario = null;

            _db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return post;
        }
    }
}
