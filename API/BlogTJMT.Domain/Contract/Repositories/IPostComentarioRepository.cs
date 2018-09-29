using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface IPostComentarioRepository
    {
        List<PostComentario> Get();
        PostComentario Get(int id);
        PostComentario GetPorUsuario(int usuarioId);
        PostComentario Post(PostComentario categoria);
        PostComentario Put(PostComentario categoria);
        void Delete(int id);
        void Dispose();
    }
}
