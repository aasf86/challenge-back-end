using System.Collections.Generic;

namespace BlogTJMT.Domain.Model
{
    public class Relatorio
    {
        public int TotalCurtidas { get; set; }
        public int TotalVisualizacoes { get; set; }
        public virtual List<PostRelatorio> PostRelatorios { get; set; }
    }
}
