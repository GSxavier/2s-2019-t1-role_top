using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class ADMController : AbastractController
    {
        public IActionResult Index() {
            ViewData["NomeView"] = "ADM";
            return View();            
        }
    }
}