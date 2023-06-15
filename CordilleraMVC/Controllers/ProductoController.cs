using CordilleraMVC.Models;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace CordilleraMVC.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoService _productoService;
        private ModelStateDictionary modelState;

        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }

        // GET: Producto
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentFilter = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewBag.CargoSortParm = String.IsNullOrEmpty(sortOrder) ? "precio_desc" : "Precio";

            List<Producto> productos;

            ViewBag.CurrentFilter = _productoService.AsignacionString(currentFilter, searchString);
            productos = _productoService.BuscarPorNombre(searchString);
            productos = _productoService.PorOrden(sortOrder);
            var empleadoPaged = _productoService.ListarProductosPag(currentFilter, searchString, page, productos);
            return View(empleadoPaged);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = _productoService.BuscarPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NombreProducto,Descripcion,Precio")] Producto producto)
        {
            modelState = new ModelStateDictionary();
            bool validaGuardar = _productoService.GuardarProducto(producto, modelState);
            if (validaGuardar)
            {
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = _productoService.BuscarPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
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
            Producto producto = _productoService.BuscarPorId(id.Value);
            string[] datosProducto = new string[] { "NombreProducto", "Descripcion", "Precio" };
            if (TryUpdateModel(producto, "", datosProducto))
            {
                if (_productoService.ActualizarProducto(modelState))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
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
            Producto producto = _productoService.BuscarPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Producto producto = _productoService.BuscarPorId(id);
                _productoService.BorrarProdcuto(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
