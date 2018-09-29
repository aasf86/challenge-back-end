using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;

namespace BlogTJMT.Data.Repositories
{
    public class PostComentarioRepository : IPostComentarioRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<PostComentario> Get()
        {
            throw new NotImplementedException();
        }

        public PostComentario Get(int id)
        {
            throw new NotImplementedException();
        }

        public PostComentario GetPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public PostComentario Post(PostComentario categoria)
        {
            throw new NotImplementedException();
        }

        public PostComentario Put(PostComentario categoria)
        {
            throw new NotImplementedException();
        }
    }
}
