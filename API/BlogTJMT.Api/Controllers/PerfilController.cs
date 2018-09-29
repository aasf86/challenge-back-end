using BlogTJMT.Common.Validations;
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
    public class PerfilController : ApiController
    {
        private PerfilRepository _PerfilRepository = new PerfilRepository(new BlogTJMTDataContext());

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

        [Route("perfil")]
        [HttpPost]
        public HttpResponseMessage Post(Perfil perfil)
        {
            try
            {
                ValidationClass.ValidaClasse(perfil);
                var result = _PerfilRepository.Post(perfil);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("perfil")]
        [HttpPut]
        public HttpResponseMessage Put(Perfil perfil)
        {
            try
            {
                ValidationClass.ValidaClasse(perfil);
                _PerfilRepository.Put(perfil);
                return Request.CreateResponse(HttpStatusCode.OK, "Perfil alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("perfil/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _PerfilRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Perfil excluído com sucesso.");
        }
    }
}