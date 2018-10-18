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
    public class PostComentarioController : ApiController
    {
        private readonly PostComentarioRepository _PostComentarioRepository = new PostComentarioRepository(new BlogTJMTDataContext());

        [Route("postComentario/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _PostComentarioRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("postComentario/especifico/{id}")]
        public HttpResponseMessage GetEspecifico(int id)
        {
            var result = _PostComentarioRepository.GetEspecifico(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("postComentario/usuario/{id}")]
        public HttpResponseMessage GetUsuario(int id)
        {
            var result = _PostComentarioRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("postComentario")]
        [HttpPost]
        public HttpResponseMessage Post(PostComentario postComentario)
        {
            try
            {
                var result = _PostComentarioRepository.Post(postComentario);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("postComentario")]
        [HttpPut]
        public HttpResponseMessage Put(PostComentario postComentario)
        {
            try
            {
                _PostComentarioRepository.Put(postComentario);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.ComentarioAlterado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("postComentario/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _PostComentarioRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.ComentarioExcluido);
        }

        public void Dispose()
        {
            _PostComentarioRepository.Dispose();
        }
    }
}