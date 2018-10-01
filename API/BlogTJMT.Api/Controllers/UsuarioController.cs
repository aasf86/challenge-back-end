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
    public class UsuarioController : ApiController
    {
        private UsuarioRepository _UsuarioRepository = new UsuarioRepository(new BlogTJMTDataContext());

        [Route("usuario")]
        [HttpPost]
        public HttpResponseMessage Post(Usuario usuario)
        {
            try
            {
                var result = _UsuarioRepository.Post(usuario);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("usuario")]
        [HttpPut]
        public HttpResponseMessage Put(Usuario usuario)
        {
            try
            {
                var result = _UsuarioRepository.Put(usuario);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.UsuarioAlterado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("usuario/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _UsuarioRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.UsuarioExcluido);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}