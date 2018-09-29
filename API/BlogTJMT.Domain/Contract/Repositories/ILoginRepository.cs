using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface ILoginRepository
    {
        Usuario AutenticaUsuario(Login login);
        void Dispose();
    }
}
