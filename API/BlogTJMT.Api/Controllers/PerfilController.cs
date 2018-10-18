using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class PerfilController : ApiController
    {
        private readonly PerfilRepository _PerfilRepository = new PerfilRepository(new BlogTJMTDataContext());

        [Route("perfil")]
        public HttpResponseMessage Get()
        {
            var result = _PerfilRepository.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("perfil/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _PerfilRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        public void Dispose()
        {
            _PerfilRepository.Dispose();
        }
    }
}