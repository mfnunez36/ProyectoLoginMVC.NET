using CapaNegocio;
using DTO;
using System.Collections.Generic;
using System.Web.Mvc;
using WebLogin.Models;

namespace WebLogin.Controllers
{
    public class PerfilController : Controller
    {
        // GET: /Perfil/

        public ActionResult Index()
        {
            //Instanciamos el objeto de la capa negocio
            PerfilBO perfilBO = new PerfilBO();
            //generamos una lista de tipo DTO el cual tomara los datos obtenidos desde la capa negocio
            List<PerfilDTO> listaPerfiles = perfilBO.ObtenerPerfiles();
            //asignamos los datos de la lista dede la capa negocio a la lista del modelo
            //usuariomodel.ObtenerUsuarios = listaUsuarios;
            ViewBag.ListaPerfiles = listaPerfiles;

            return View();
        }

        public ActionResult Agregar()
        {
            PerfilModel perfilmodel = new PerfilModel();

            return View(perfilmodel);
        }

        public ActionResult AgregarPerfil(PerfilModel perfilmodel)
        {
            PerfilBO perfilBO = new PerfilBO();
            PerfilDTO per = new PerfilDTO();

            per.tipo = perfilmodel.tipo;
            per.descripcion = perfilmodel.descripcion;

            perfilBO.AgregarPerfil(per);

            return RedirectToAction("Index", "Perfil");
        }



        public ActionResult Editar(int id)
        {
            PerfilModel perfilmodel = new PerfilModel();
            PerfilBO perBO = new PerfilBO();
            PerfilDTO per = new PerfilDTO();

            per = perBO.PerfilByID(id);

            return View(per);
        }

        public ActionResult EditarPerfil(PerfilModel perfilmodel)
        {
            PerfilBO perBO = new PerfilBO();
            PerfilDTO per = new PerfilDTO();

            per.id = perfilmodel.id;
            per.tipo = perfilmodel.tipo;
            per.descripcion = perfilmodel.descripcion;
            per.vigente = perfilmodel.vigente;

            perBO.EditarPerfil(per);

            return RedirectToAction("Index", "Perfil");
        }

        public ActionResult Desactivar(int id)
        {
            PerfilBO perBO = new PerfilBO();

            perBO.EliminarPerfil(id);

            return RedirectToAction("Index", "Perfil");
        }
    }
}