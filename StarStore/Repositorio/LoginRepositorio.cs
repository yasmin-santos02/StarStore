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
        
        public LoginModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public LoginModel CriarLogin(LoginModel loginModel)
        {
            //gravar no banco de dados
            loginModel.SetSenhaHash();
            _context.Usuarios.Add(loginModel);
            _context.SaveChanges();
            return loginModel;
        }

       
    }
}
