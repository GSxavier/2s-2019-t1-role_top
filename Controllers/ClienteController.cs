using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : AbastractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
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
            return View(new BaseViewModel()
            {
                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try
            {
                System.Console.WriteLine("==================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("==================");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);

                if(cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        switch(cliente.TipoUsuario){
                            case (uint) TiposUsuario.CLIENTE:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                
                                
                                return RedirectToAction("Logado" ,"Cliente");
                            
                                default:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                
                                return RedirectToAction("Index","ADM");
                            
                        }
                    }
                    else 
                    {
                        return View("Erro", new RespostaViewModel("Senha incorreta"));
                    }
                } 
                else
                {
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não encontrado"));
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel());
            }
        }

        public IActionResult Logado()
        {

            return View(new BaseViewModel()
            {
                NomeView = "Logado",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        

    }

}




