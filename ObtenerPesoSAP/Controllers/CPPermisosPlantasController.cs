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
    public class CPPermisosPlantasController : Controller
    {
        private BDObtenerPesoSAPEntities db = new BDObtenerPesoSAPEntities();

        // GET: CPPermisosPlantas
        public ActionResult Index()
        {

            int VarUsuario = int.Parse(Session["idUsuario"].ToString());
            if (!db.CPPantallasPermisos.Any(x => x.IdPantalla == 8 && x.IdUsuario == VarUsuario))
            {
                return Redirect("/Home/Index");
            }

            var cPPermisosPlantas = db.CPBascula.Include(c => c.CPCatEmpresas).Include(c => c.CPUsuario);
            return View(cPPermisosPlantas.ToList());
        }

        // GET: CPPermisosPlantas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPPermisosPlantas cPPermisosPlantas = db.CPBascula.Find(id);
            if (cPPermisosPlantas == null)
            {
                return HttpNotFound();
            }
            return View(cPPermisosPlantas);
        }

        // GET: CPPermisosPlantas/Create
        public ActionResult Create()
        {
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa");
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPId,CPIdEmpresa,CPIdUsuario,CPFechaAlta,CPUsuarioAlta,CPFechaCambio,CPUsuarioCambio,CPPlantaDefault")] CPPermisosPlantas cPPermisosPlantas)
        {
            if (ModelState.IsValid)
            {
                db.CPBascula.Add(cPPermisosPlantas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPPermisosPlantas.CPIdEmpresa);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPPermisosPlantas.CPIdUsuario);
            return View(cPPermisosPlantas);
        }

        // GET: CPPermisosPlantas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPPermisosPlantas cPPermisosPlantas = db.CPBascula.Find(id);
            if (cPPermisosPlantas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPPermisosPlantas.CPIdEmpresa);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPPermisosPlantas.CPIdUsuario);
            return View(cPPermisosPlantas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPId,CPIdEmpresa,CPIdUsuario,CPFechaAlta,CPUsuarioAlta,CPFechaCambio,CPUsuarioCambio,CPPlantaDefault")] CPPermisosPlantas cPPermisosPlantas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cPPermisosPlantas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPPermisosPlantas.CPIdEmpresa);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPPermisosPlantas.CPIdUsuario);
            return View(cPPermisosPlantas);
        }

        // GET: CPPermisosPlantas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPPermisosPlantas cPPermisosPlantas = db.CPBascula.Find(id);
            if (cPPermisosPlantas == null)
            {
                return HttpNotFound();
            }
            return View(cPPermisosPlantas);
        }

        // POST: CPPermisosPlantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPPermisosPlantas cPPermisosPlantas = db.CPBascula.Find(id);
            db.CPBascula.Remove(cPPermisosPlantas);
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
