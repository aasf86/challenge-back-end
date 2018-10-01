using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class RelatorioController : ApiController
    {
        private readonly RelatorioRepository _RelatorioRepository = new RelatorioRepository(new BlogTJMTDataContext());

        [Route("rel")]
        public HttpResponseMessage Get()
        {
            var result = _RelatorioRepository.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        public void Dispose()
        {
            _RelatorioRepository.Dispose();
        }
    }
}