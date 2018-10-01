using BlogTJMT.Common.Resources;
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
    public class RelatorioController : ApiController
    {
        private RelatorioRepository _RelatorioRepository = new RelatorioRepository(new BlogTJMTDataContext());

        [Route("rel")]
        public HttpResponseMessage Get()
        {
            var result = _RelatorioRepository.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}