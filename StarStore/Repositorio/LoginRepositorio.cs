using StarStore.Data;
using StarStore.Models;

namespace StarStore.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly BancoContext _context;

        public LoginRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public LoginModel CriarLogin(LoginModel loginModel)
        {
            //gravar no banco de dados
              _context.Usuarios.Add(loginModel);
              _context.SaveChanges();
              return loginModel;  
        }
    }
}
