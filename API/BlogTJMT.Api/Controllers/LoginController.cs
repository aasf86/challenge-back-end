using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class LoginController : ApiController
    {
        private LoginRepository _LoginRepository = new LoginRepository(new BlogTJMTDataContext());

        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Post(Login login)
        {
            try
            {
                var result = _LoginRepository.AutenticaUsuario(login);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
    }
}