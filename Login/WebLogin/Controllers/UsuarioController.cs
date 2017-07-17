using CapaNegocio;
using DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebLogin.Models;

namespace WebLogin.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            //Instanciamos el objeto de la capa negocio
            UsuarioBO usuarioBO = new UsuarioBO();
            //generamos una lista de tipo DTO el cual tomara los datos obtenidos desde la capa negocio
            List<UsuarioDTO> listaUsuarios = usuarioBO.ObtenerUsuarios();
            //asignamos los datos de la lista dede la capa negocio a la lista del modelo
            //usuariomodel.ObtenerUsuarios = listaUsuarios;
            ViewBag.ListaUsuarios = listaUsuarios;

            return View();
        }

        public ActionResult Agregar()
        {
            UsuarioModel usuariomodel = new UsuarioModel();

            return View(usuariomodel);
        }

        [HttpPost]
        public ActionResult Agregar(UsuarioModel usuariomodel)
        {
            UsuarioBO usuarioBO = new UsuarioBO();
            UsuarioDTO usu = new UsuarioDTO();

            try
            {
                if (ModelState.IsValid)
                {
                    usu.rut = usuariomodel.rut;
                    usu.nombre = usuariomodel.nombre;
                    usu.apellido = usuariomodel.apellido;
                    usu.fecha_nac = usuariomodel.fecha_nac;
                    usu.contraseña = usuariomodel.contraseña;
                    usu.correo = usuariomodel.correo;
                    usu.telefono = (int)usuariomodel.telefono;
                    usu.vigente = true;

                    usuarioBO.AgregarUsuario(usu);

                    return RedirectToAction("Index", "Usuario");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View(usuariomodel);

        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            UsuarioModel usuariomodel = new UsuarioModel();
            UsuarioBO usuBO = new UsuarioBO();
            UsuarioDTO usu = new UsuarioDTO();

            usu = usuBO.UsuarioByID(id);

            ViewBag.usumodel = usuariomodel;

            return View(usu);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioModel usuariomodel)
        {
            UsuarioBO usuBO = new UsuarioBO();
            UsuarioDTO usu = new UsuarioDTO();

            usu.id = usuariomodel.id;
            usu.rut = usuariomodel.rut;
            usu.nombre = usuariomodel.nombre;
            usu.apellido = usuariomodel.apellido;
            usu.fecha_nac = usuariomodel.fecha_nac;
            usu.correo = usuariomodel.correo;
            usu.contraseña = usuariomodel.contraseña;
            usu.telefono = (int)usuariomodel.telefono;
            usu.vigente = usuariomodel.vigente;

            usuBO.EditarUsuario(usu);

            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Desactivar(int id)
        {
            UsuarioBO usuBO = new UsuarioBO();

            usuBO.EliminarUsuario(id);

            return RedirectToAction("Index", "Usuario");
        }
    }
}