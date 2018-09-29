using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    public class CategoriaController : ApiController
    {
        private CategoriaRepository _CategoriaRepository = new CategoriaRepository(new BlogTJMTDataContext());
    }
}