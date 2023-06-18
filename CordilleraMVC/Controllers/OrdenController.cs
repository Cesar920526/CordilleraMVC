using CordilleraMVC.Data;
using CordilleraMVC.Models;
using CordilleraMVC.Services;
using System.Collections.Generic;
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
            Orden orden = db.Ordenes.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = _ordenService.ListaDespegableCliente();
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado();
            return View();
        }

        // POST: Orden/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenId,Fecha,EmpleadoId,ClienteId")] Orden orden)
        {
            modelState = new ModelStateDictionary();
            bool validaGuardar = _ordenService.GuardarOrden(orden, modelState);
            if (validaGuardar)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = _ordenService.ListaDespegableCliente(orden.ClienteId);
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado(orden.EmpleadoId);
            return View(orden);
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ClienteId = _ordenService.ListaDespegableCliente(orden.ClienteId);
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado(orden.EmpleadoId);
            return View(orden);
        }

        // POST: Orden/Edit/5
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
            Orden orden = _ordenService.BuscarPorId(id.Value);
            string[] datosOrdenes = new string[] { "Fecha", "EmpleadoId", "ClienteId" };
            if (TryUpdateModel(orden, "", datosOrdenes))
            {
                if (_ordenService.ActualizarOrden(modelState))
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClienteId = _ordenService.ListaDespegableCliente(orden.ClienteId);
            ViewBag.EmpleadoId = _ordenService.ListaDespegableEmpleado(orden.EmpleadoId);
            return View(orden);
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordenes.Find(id);
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
            Orden orden = db.Ordenes.Find(id);
            db.Ordenes.Remove(orden);
            db.SaveChanges();
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
