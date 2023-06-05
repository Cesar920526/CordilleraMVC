using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CordilleraMVC.Data;
using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using CordilleraMVC.Implements;

namespace CordilleraMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        private IEmpleadoService empleadoService;
        private ModelStateDictionary modelState;
        private CordilleraContext db = new CordilleraContext();

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        // GET: Empleado
        public ActionResult Index()
        {
            var empleados = empleadoService.ListaEmpleados();
            return View(empleados);
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = empleadoService.BuscarPorId(id.Value);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Telefono,Email,Cargo")] Empleado empleado)
        {
            modelState = new ModelStateDictionary();
            bool validaGuardar = empleadoService.GuardarEmpleado(empleado, modelState);
            if (validaGuardar)
            {
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = empleadoService.BuscarPorId(id.Value);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = empleadoService.BuscarPorId(id.Value);
            string[] datosEmpleado = new string[] { "Nombre", "Apellido", "Telefono", "Email", "Cargo" };
            if(TryUpdateModel(empleado, "", datosEmpleado))
            {
                if (empleadoService.ActualizarEmpleado(modelState))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Borrado fallido, Intente nuevamente, y si el error persiste contacte al administrador.";
            }
            Empleado empleado = empleadoService.BuscarPorId(id.Value);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Empleado empleado = empleadoService.BuscarPorId(id);
                empleadoService.BorrarEmpleado(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
