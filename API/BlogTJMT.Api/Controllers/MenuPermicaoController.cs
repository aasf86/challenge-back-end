using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    public class MenuPermicaoController : ApiController
    {
        private MenuPermicaoRepository _MenuPermicaoRepository = new MenuPermicaoRepository(new BlogTJMTDataContext());
    }
}