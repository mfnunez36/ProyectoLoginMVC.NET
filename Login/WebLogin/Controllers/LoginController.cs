using CapaNegocio;
using DTO;
using System.Web.Mvc;
using System.Web.Security;
using WebLogin.Models;

namespace WebLogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UsuarioModel usumodel)
        {
            UsuarioBO usuBO = new UsuarioBO();

            if (!string.IsNullOrWhiteSpace(usumodel.correo) && !string.IsNullOrWhiteSpace(usumodel.contraseña))
            {
                var resultado = usuBO.LogIn(usumodel.correo, usumodel.contraseña);

                if (resultado.id != 0)
                {
                    FormsAuthentication.SetAuthCookie(resultado.nombre, false);
                    Session["usuario"] = resultado;
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Login");
        }
    }
}