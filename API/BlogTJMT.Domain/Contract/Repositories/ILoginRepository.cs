using BlogTJMT.Domain.Model;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface ILoginRepository
    {
        Usuario AutenticaUsuario(Login login);
        void Dispose();
    }
}
