using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudEntityFramework.Interfaz;
using CrudEntityFramework.Models;
using CrudEntityFramework.Negocio;
using CrudEntityFramework.response;
using CrudEntityFramework.Utilerias;

namespace CrudEntityFramework.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly IEscuela negocio = new EscuelaNegocio();
        private readonly Log log = new Log(typeof(EscuelaController));

        // GET: Escuela
        public ActionResult Escuela()
        {
            return View();
        }

        public JsonResult CargarAlumnos()
        {
            HandlerError handler = new HandlerError();
            object lista;

            try
            {
                lista = negocio.CargarAlumnos();
                var i = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Json(
                        new
                        {
                            lista,
                            handler
                        });
        }

        public JsonResult CargarMaterias()
        {
            HandlerError handler = new HandlerError();
            object lista;

            try
            {
                lista = negocio.CargarMaterias();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Json(
                        new
                        {
                            lista,
                            handler
                        });
        }

        public JsonResult Consultar()
        {
            HandlerError handler = new HandlerError();
            object lista;

            try
            {
                lista = negocio.Consultar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Json(
                        new
                        {
                            lista,
                            handler
                        });
        }

        public JsonResult Eliminar(CalificacionAlumno model)
        {
            HandlerError handler = new HandlerError();

            bool respuesta = negocio.Eliminar(model.miClave);

            return Json(
                        new
                        {
                            respuesta,
                            handler
                        });
        }

        public JsonResult Agregar(CalificacionAlumno model)
        {
            HandlerError handler = new HandlerError();
            bool respuesta = new bool();

            respuesta = negocio.Agregar(model);

            return Json(
                        new
                        {
                            respuesta,
                            handler

                        });
        }

        public JsonResult Actualizar(CalificacionAlumno model)
        {
            HandlerError handler = new HandlerError();

            bool respuesta = negocio.Actualizar(model);

            return Json(
                        new
                        {
                            respuesta,
                            handler
                        });
        }

        public JsonResult Recuperar(CalificacionAlumno model)
        {
            HandlerError handler = new HandlerError();
            object lista;

            try
            {
                lista = negocio.Recuperar(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Json(
                        new
                        {
                            lista,
                            handler
                        });
        }

    }
}