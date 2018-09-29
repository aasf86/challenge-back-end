using BlogTJMT.Domain.Model;
using System.Collections.Generic;

namespace BlogTJMT.Domain.Contract.Repositories
{
    public interface ILoginRepository
    {
        Usuario Get(Login login);
        void Dispose();
    }
}
