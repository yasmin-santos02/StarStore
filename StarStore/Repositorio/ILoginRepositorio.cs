using StarStore.Models;

namespace StarStore.Repositorio
{
    public interface ILoginRepositorio
    {
        LoginModel BuscarPorLogin(string login);
        LoginModel CriarLogin(LoginModel login);
    }
}
