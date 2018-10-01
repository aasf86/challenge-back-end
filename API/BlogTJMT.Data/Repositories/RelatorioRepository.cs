using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        private List<PostRelatorio> RetornaListaDePosts()
        {
            var list = new List<PostRelatorio>();
            _db.Posts.ToList().ForEach(dados => list.Add(RetornaPostRelatorio(dados)));

            return list;
        }

        private PostRelatorio RetornaPostRelatorio(Post dados)
        {
            var classe = new PostRelatorio
            {
                PostId = dados.Id,
                Post = dados,
                PorcentagemCurtidas = RetornaPorcentagemCurtida(dados.Curtidas),
                PorcentagemVisualizacoes = RetornaPorcentagemVisualizacoes(dados.Visualizacoes)
            };

            return classe;
        }

        private double RetornaPorcentagemCurtida(int totalCurtidasPost)
        {
            var result = ((double)totalCurtidasPost * 100 / RetornaTotalCurtidas());
            return result;
        }

        private double RetornaPorcentagemVisualizacoes(int totalVisualizacoesPost)
        {
            var result = ((double)totalVisualizacoesPost * 100 / RetornaTotalVisualizacoes());
            return result;
        }

        private int RetornaTotalVisualizacoes()
        {
            return _db.Posts.Sum(coluna => coluna.Visualizacoes);
        }

        private int RetornaTotalCurtidas()
        {
            return _db.Posts.Sum(coluna => coluna.Curtidas);
        }

        public RelatorioRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public Relatorio Get()
        {
            var rel = new Relatorio
            {
                TotalCurtidas = RetornaTotalCurtidas(),
                TotalVisualizacoes = RetornaTotalVisualizacoes(),
                PostRelatorios = RetornaListaDePosts()
            };

            return rel;
        }
    }
}
