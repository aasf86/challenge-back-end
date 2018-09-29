using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    public class LoginController : ApiController
    {
        private LoginRepository _LoginRepository = new LoginRepository(new BlogTJMTDataContext());
    }
}