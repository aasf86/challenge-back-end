using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Model;
using System.Linq;
using BlogTJMT.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;

namespace BlogTJMT.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public RelatorioRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Dispose() => _db.Dispose();
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
    }
}
