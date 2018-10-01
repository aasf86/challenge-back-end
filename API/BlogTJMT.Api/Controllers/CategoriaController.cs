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
    public class CategoriaController : ApiController
    {
        private readonly CategoriaRepository _CategoriaRepository = new CategoriaRepository(new BlogTJMTDataContext());

        [Route("categoria")]
        public HttpResponseMessage Get()
        {
            var result = _CategoriaRepository.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categoria/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _CategoriaRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("categoria")]
        [HttpPost]
        public HttpResponseMessage Post(Categoria categoria)
        {
            try
            {
                var result = _CategoriaRepository.Post(categoria);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
            return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("categoria")]
        [HttpPut]
        public HttpResponseMessage Put(Categoria categoria)
        {
            try
            {
                var result = _CategoriaRepository.Put(categoria);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.CategoriaAlterada);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("categoria/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _CategoriaRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, MensagensSucesso.CategoriaExcluida);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public void Dispose()
        {
            _CategoriaRepository.Dispose();
        }
    }
}