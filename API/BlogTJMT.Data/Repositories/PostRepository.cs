using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;

namespace BlogTJMT.Data.Repositories
{
    public class PostRepository : IPostRepository
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

        public List<Post> Get()
        {
            throw new NotImplementedException();
        }

        public List<Post> Get(string titulo)
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetMaisCurtidas()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetMaisVisualizacoes()
        {
            throw new NotImplementedException();
        }

        public Post Post(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Put(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
