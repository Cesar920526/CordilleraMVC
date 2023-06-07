using CordilleraMVC.Models;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace CordilleraMVC.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteService _clienteService;
        private ModelStateDictionary modelState;
        //private CordilleraContext db = new CordilleraContext();

        public ClienteController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }

        // GET: Cliente
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentFilter = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewBag.CargoSortParm = String.IsNullOrEmpty(sortOrder) ? "cargo_desc" : "Cargo";

            List<Cliente> clientes;

            ViewBag.CurrentFilter = _clienteService.AsignacionString(currentFilter, searchString);
            clientes = _clienteService.BuscarPorNombre(searchString);
            clientes = _clienteService.PorOrden(sortOrder);
            var empleadoPaged = _clienteService.ListarClientesPag(currentFilter, searchString, page, clientes);
            return View(empleadoPaged);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _clienteService.BuscarPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Telefono,Email,Direccion,Ciudad")] Cliente cliente)
        {
            modelState = new ModelStateDictionary();
            bool validaGuardar = _clienteService.GuardarCliente(cliente, modelState);
            if (validaGuardar)
            {
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _clienteService.BuscarPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
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
            Cliente cliente = _clienteService.BuscarPorId(id.Value);
            string[] datosCliente = new string[] { "Nombre", "Apellido", "Telefono", "Email", "Direccion", "Ciudad" };
            if (TryUpdateModel(cliente, "", datosCliente))
            {
                if (_clienteService.ActualizarCliente(modelState))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Borrado fallido, Intente nuevamente, y si el error persiste contacte al administrador.";
            }
            Cliente cliente = _clienteService.BuscarPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cliente cliente = _clienteService.BuscarPorId(id);
                _clienteService.BorrarCliente(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
