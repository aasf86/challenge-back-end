using BlogTJMT.Common.Enum;

namespace BlogTJMT.Domain.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public MenuEnum Enum { get; set; }
    }
}
