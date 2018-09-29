using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    public class PostController : ApiController
    {
        private PostRepository _PostRepository = new PostRepository(new BlogTJMTDataContext());
    }
}