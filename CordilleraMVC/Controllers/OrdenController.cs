using CordilleraMVC.Data;
using CordilleraMVC.Models;
using CordilleraMVC.Services;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace CordilleraMVC.Controllers
{
    public class OrdenController : Controller
    {
        private IOrdenService _ordenService;
        private ModelStateDictionary modelState;
        private CordilleraContext db = new CordilleraContext();

        public OrdenController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        // GET: Orden
        public ActionResult Index()
        {
            List<Orden> ordenes = _ordenService.ListaOrdenes();
            return View(ordenes);
        }

        // GET: Orden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = _ordenService.BuscarPorId(id.Value);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            Orden orden = new Orden();
            orden.Productos = new List<Producto>();
            ViewBag.ClienteId = _ordenService.ListaDespegableCliente();
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado();
            ViewBag.Productos = _ordenService.TraerDatosProductos(orden);
            return View();
        }

        // POST: Orden/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenId,Fecha,EmpleadoId,ClienteId")] Orden orden, string[] productosSeleccionados)
        {
            modelState = new ModelStateDictionary();
            bool validaGuardar = _ordenService.GuardarOrden(orden, modelState, productosSeleccionados);
            if (validaGuardar)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = _ordenService.ListaDespegableCliente(orden.ClienteId);
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado(orden.EmpleadoId);
            ViewBag.Productos = _ordenService.TraerDatosProductos(orden);
            return View(orden);
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = _ordenService.BuscarConProductos(id.Value);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = _ordenService.ListaDespegableCliente(orden.ClienteId);
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado(orden.EmpleadoId);
            ViewBag.Productos = _ordenService.TraerDatosProductos(orden);
            return View(orden);
        }

        // POST: Orden/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, string[] productosSeleccionados)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = _ordenService.BuscarConProductos(id.Value);
            string[] datosOrdenes = new string[] { "Fecha", "EmpleadoId", "ClienteId" };
            if (TryUpdateModel(orden, "", datosOrdenes))
            {
                if (_ordenService.ActualizarOrden(productosSeleccionados, orden, modelState))
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClienteId = _ordenService.ListaDespegableCliente(orden.ClienteId);
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado(orden.EmpleadoId);
            ViewBag.Productos = _ordenService.TraerDatosProductos(orden);
            return View(orden);
        }

        // GET: Orden/Delete/5
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
            Orden orden = _ordenService.BuscarPorId(id.Value);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Orden orden = _ordenService.BuscarPorId(id);
                _ordenService.BorrarOrden(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new {id = id, saveChangesError = true});
            }
            return RedirectToAction("Index");
        }
    }
}
