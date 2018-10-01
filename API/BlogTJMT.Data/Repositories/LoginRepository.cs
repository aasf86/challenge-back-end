using BlogTJMT.Common.Resources;
using BlogTJMT.Common.Security;
using BlogTJMT.Common.Validations;
using BlogTJMT.Data.DataContexts;
using BlogTJMT.Domain.Contract.Repositories;
using BlogTJMT.Domain.Model;
using System;
using System.Linq;

namespace BlogTJMT.Data.Repositories
{
    public class LoginRepository : ILoginRepository, IDisposable
    {
        private readonly BlogTJMTDataContext _db = new BlogTJMTDataContext();

        private Usuario ProcuraUsuario(Login login)
        {
            return (from item in _db.Usuarios.Include(nameof(Perfil)).Include("Perfil.Permicoes")
                    where item.Email.ToLower() == (login.Email.ToLower()) && item.Senha == (login.Senha)
                    select item).FirstOrDefault();
        }

        private Usuario ValidaUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new Exception(MensagensErro.UsuarioNaoEncontrado);

            return usuario;
        }

        public LoginRepository(BlogTJMTDataContext context)
        {
            _db = context;
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario AutenticaUsuario(Login login)
        {
            ValidationClass.ValidaClasse(login);
            login.Senha = login.Senha.Encrypta();
            return ValidaUsuario(ProcuraUsuario(login));
        }
    }
}
