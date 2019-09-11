using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ObtenerPesoSAP.Models;

namespace ObtenerPesoSAP.Controllers
{
    public class LogDeMovimientosController : Controller
    {
        private BDObtenerPesoSAPEntities db = new BDObtenerPesoSAPEntities();

        // GET: LogDeMovimientos
        public ActionResult Index()
        {
            var cPLogDeProcesos = db.CPLogDeProcesos.Include(c => c.CPCatEmpresas).Include(c => c.CPCatProcesos).Include(c => c.CPUsuario);
            return View(cPLogDeProcesos.ToList());
        }

        // GET: LogDeMovimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPLogDeProcesos cPLogDeProcesos = db.CPLogDeProcesos.Find(id);
            if (cPLogDeProcesos == null)
            {
                return HttpNotFound();
            }
            return View(cPLogDeProcesos);
        }

        // GET: LogDeMovimientos/Create
        public ActionResult Create()
        {
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa");
            ViewBag.CPIdProceso = new SelectList(db.CPCatProcesos, "CPIdProceso", "CPDescripcion");
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario");
            return View();
        }

        // POST: LogDeMovimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPIdLog,CPIdEmpresa,CPIdTransporte,CPIdDocumento,CPIdMaterial,CPIdErrorSAP,CPDescripcionMensaje,CPPartidas,CPFechaInicio,CpFechaFinal,CPIdUsuario,CPIdProceso,CPEstatus,CPRol")] CPLogDeProcesos cPLogDeProcesos)
        {
            if (ModelState.IsValid)
            {
                db.CPLogDeProcesos.Add(cPLogDeProcesos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPLogDeProcesos.CPIdEmpresa);
            ViewBag.CPIdProceso = new SelectList(db.CPCatProcesos, "CPIdProceso", "CPDescripcion", cPLogDeProcesos.CPIdProceso);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPLogDeProcesos.CPIdUsuario);
            return View(cPLogDeProcesos);
        }

        // GET: LogDeMovimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPLogDeProcesos cPLogDeProcesos = db.CPLogDeProcesos.Find(id);
            if (cPLogDeProcesos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPLogDeProcesos.CPIdEmpresa);
            ViewBag.CPIdProceso = new SelectList(db.CPCatProcesos, "CPIdProceso", "CPDescripcion", cPLogDeProcesos.CPIdProceso);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPLogDeProcesos.CPIdUsuario);
            return View(cPLogDeProcesos);
        }

        // POST: LogDeMovimientos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPIdLog,CPIdEmpresa,CPIdTransporte,CPIdDocumento,CPIdMaterial,CPIdErrorSAP,CPDescripcionMensaje,CPPartidas,CPFechaInicio,CpFechaFinal,CPIdUsuario,CPIdProceso,CPEstatus,CPRol")] CPLogDeProcesos cPLogDeProcesos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cPLogDeProcesos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPLogDeProcesos.CPIdEmpresa);
            ViewBag.CPIdProceso = new SelectList(db.CPCatProcesos, "CPIdProceso", "CPDescripcion", cPLogDeProcesos.CPIdProceso);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPLogDeProcesos.CPIdUsuario);
            return View(cPLogDeProcesos);
        }

        // GET: LogDeMovimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPLogDeProcesos cPLogDeProcesos = db.CPLogDeProcesos.Find(id);
            if (cPLogDeProcesos == null)
            {
                return HttpNotFound();
            }
            return View(cPLogDeProcesos);
        }

        // POST: LogDeMovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPLogDeProcesos cPLogDeProcesos = db.CPLogDeProcesos.Find(id);
            db.CPLogDeProcesos.Remove(cPLogDeProcesos);
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
