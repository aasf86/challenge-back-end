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
    public class PostController : ApiController
    {
        private PostRepository _PostRepository = new PostRepository(new BlogTJMTDataContext());

        [Route("post")]
        public HttpResponseMessage Get()
        {
            var result = _PostRepository.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("post/curtidas")]
        public HttpResponseMessage GetCurtidas()
        {
            var result = _PostRepository.GetMaisCurtidas();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("post/visualizacoes")]
        public HttpResponseMessage GetVisualizacoes()
        {
            var result = _PostRepository.GetMaisVisualizacoes();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("post/top5")]
        public HttpResponseMessage GetTop5()
        {
            var result = _PostRepository.GetTop5();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("post/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _PostRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("post/porTitulo/{titulo}")]
        public HttpResponseMessage Get(string titulo)
        {
            var result = _PostRepository.Get(titulo);
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Post(Post post)
        {
            try
            {
                var result = _PostRepository.Post(post);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("post")]
        [HttpPut]
        public HttpResponseMessage Put(Post post)
        {
            try
            {
                var result = _PostRepository.Put(post);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.PostAlterado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("post/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _PostRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.PostExcluido);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}