using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;

namespace BlogTJMT.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private BlogTJMTDataContext _db = new BlogTJMTDataContext();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Usuario Get(Login login)
        {
            throw new System.NotImplementedException();
        }
    }
}
