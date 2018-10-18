﻿using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IPostRepository
    {
        List<Post> Get();
        List<Post> GetTop5();
        List<Post> GetMaisCurtidas();
        List<Post> GetMaisVisualizacoes();
        List<Post> Get(string titulo);
        Post Get(int id);
        Post Post(Post post);
        Post Put(Post post);
        void AdicionarCurtida(int id);
        void Delete(int id);
        void Dispose();
    }
}
