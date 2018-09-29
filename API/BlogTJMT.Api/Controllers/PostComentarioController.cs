using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    public class PostComentarioController : ApiController
    {
        private PostComentarioRepository _PostComentarioRepository = new PostComentarioRepository(new BlogTJMTDataContext());
    }
}