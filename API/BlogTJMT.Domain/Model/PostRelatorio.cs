namespace BlogTJMT.Domain.Model
{
    public class PostRelatorio
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public double PorcentagemVisualizacoes { get; set; }
        public double PorcentagemCurtidas { get; set; }
    }
}
    