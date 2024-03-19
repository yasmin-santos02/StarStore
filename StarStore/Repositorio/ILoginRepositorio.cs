using StarStore.Models;

namespace StarStore.Repositorio
{
    public interface ILoginRepositorio
    {
        LoginModel CriarLogin(LoginModel login);
    }
}
