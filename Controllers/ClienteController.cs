using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult HOME()
        {
            ViewData["NomeView"] = "HOME";
            return View();
        }
        public IActionResult GALERIA()
        {

            ViewData["NomeView"] = "GALERIA";
            return View();
        }

        public IActionResult AGENDA()
        {
            ViewData["NomeView"] = "AGENDA";
            return View();

        }

        public IActionResult CONTATO()
        {

            ViewData["NomeView"] = "CONTATO";
            return View();
        }
        public IActionResult LOCALIZACAO()
        {

            ViewData["NomeView"] = "LOCALIZACAO";
            return View();
        }

        public IActionResult Cadastro()
        {
            ViewData["NomeView"] = "CADASTRO";
            return View();
        }
        public IActionResult Login()
        {
            ViewData["NomeView"] = "LOGIN";
            return View();
        }

    }
}