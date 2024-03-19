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

        public IActionResult Entrar()
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
    }
}
