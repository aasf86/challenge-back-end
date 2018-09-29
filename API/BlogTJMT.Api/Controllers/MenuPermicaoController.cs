using BlogTJMT.Data.DataContexts;
using BlogTJMT.Data.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTJMT.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class MenuPermicaoController : ApiController
    {
        private MenuPermicaoRepository _MenuPermicaoRepository = new MenuPermicaoRepository(new BlogTJMTDataContext());

        [Route("menuPermicao/usuario/{id}")]
        public HttpResponseMessage GetUsuario(int id)
        {
            var result = _MenuPermicaoRepository.GetPorUsuario(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("menuPermicao/perfil/{id}")]
        public HttpResponseMessage GetPerfil(int id)
        {
            var result = _MenuPermicaoRepository.GetPorPerfil(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("menuPermicao/permicao/{id}")]
        public HttpResponseMessage GetPermicao(int id)
        {
            var result = _MenuPermicaoRepository.GetPorPermicao(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}