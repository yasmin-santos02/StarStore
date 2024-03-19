using Microsoft.AspNetCore.Mvc;
using StarStore.Models;
using StarStore.Repositorio;

namespace StarStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _loginRepositorio;

        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsuarioLogado()
        {
            return View();
        }
        public IActionResult CriarLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarLogin(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _loginRepositorio.CriarLogin(loginModel);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(loginModel);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o usuário, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                  LoginModel usuario = _loginRepositorio.BuscarPorLogin(loginModel.Login);
                if (usuario != null)
                {
                    if (usuario.SenhaValida(loginModel.Senha))
                    {
                        TempData["MensagemSucesso"] = "Senha e usuário corretos";
                        return RedirectToAction("UsuarioLogado", "Login");
                    }
                    TempData["MensagemErro"] = $"Senha inválida. Por favor, tente novamente.";
                }
                TempData["MensagemErro"] = $"Usuário e/ou senha inválidos. Por favor, tente novamente.";
                
                TempData["MensagemErro"] = $"ERRO ooo";
                return View("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Erro ao realizar o login, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
