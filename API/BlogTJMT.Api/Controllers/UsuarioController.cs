using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioRepository _UsuarioRepository = new UsuarioRepository(new BlogTJMTDataContext());
    }
}