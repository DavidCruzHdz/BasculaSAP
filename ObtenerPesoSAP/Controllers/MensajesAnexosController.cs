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
    public class MensajesAnexosController : Controller
    {
        private BDObtenerPesoSAPEntities db = new BDObtenerPesoSAPEntities();
        // GET: MensajesAnexos
        public ActionResult Index()
        {
            var cPCatMensajesSAP = db.CPCatMensajesSAP.Include(c => c.CPRol).Include(c => c.CPUsuario).Include(c => c.CPUsuario1);
            return View(cPCatMensajesSAP.ToList());
        }

        // GET: MensajesAnexos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPCatMensajesSAP cPCatMensajesSAP = db.CPCatMensajesSAP.Find(id);
            if (cPCatMensajesSAP == null)
            {
                return HttpNotFound();
            }
            return View(cPCatMensajesSAP);
        }

        // GET: MensajesAnexos/Create
        public ActionResult Create()
        {
            ViewBag.CPRol_id = new SelectList(db.CPRol, "id", "Nombre");
            ViewBag.CPUsuarioAlta = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario");
            ViewBag.CPUsuarioCambio = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario");
            return View();
        }

        // POST: MensajesAnexos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPIdMsj,CPIdMsjSAP,CPDescripcionMsjSAP,CPTextoAnexo,CPRol_id,CPFechaAlta,CPUsuarioAlta,CPFechaCambio,CPUsuarioCambio")] CPCatMensajesSAP cPCatMensajesSAP)
        {
            if (ModelState.IsValid)
            {
                cPCatMensajesSAP.CPFechaAlta = DateTime.Now;
                cPCatMensajesSAP.CPFechaCambio = DateTime.Now;
                cPCatMensajesSAP.CPRol_id = 1;
                cPCatMensajesSAP.CPIdMsjSAP = 0;
                cPCatMensajesSAP.CPUsuarioAlta = int.Parse(Session["idUsuario"].ToString());
                cPCatMensajesSAP.CPUsuarioCambio = int.Parse(Session["idUsuario"].ToString());

                db.CPCatMensajesSAP.Add(cPCatMensajesSAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPRol_id = new SelectList(db.CPRol, "id", "Nombre", cPCatMensajesSAP.CPRol_id);
            ViewBag.CPUsuarioAlta = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPCatMensajesSAP.CPUsuarioAlta);
            ViewBag.CPUsuarioCambio = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPCatMensajesSAP.CPUsuarioCambio);
            return View(cPCatMensajesSAP);
        }

        // GET: MensajesAnexos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPCatMensajesSAP cPCatMensajesSAP = db.CPCatMensajesSAP.Find(id);
            if (cPCatMensajesSAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPRol_id = new SelectList(db.CPRol, "id", "Nombre", cPCatMensajesSAP.CPRol_id);
            ViewBag.CPUsuarioAlta = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPCatMensajesSAP.CPUsuarioAlta);
            ViewBag.CPUsuarioCambio = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPCatMensajesSAP.CPUsuarioCambio);
            return View(cPCatMensajesSAP);
        }

        // POST: MensajesAnexos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPIdMsj,CPIdMsjSAP,CPDescripcionMsjSAP,CPTextoAnexo,CPRol_id,CPFechaAlta,CPUsuarioAlta,CPFechaCambio,CPUsuarioCambio")] CPCatMensajesSAP cPCatMensajesSAP)
        {
            if (ModelState.IsValid)
            {
                cPCatMensajesSAP.CPFechaAlta = DateTime.Now;
                cPCatMensajesSAP.CPFechaCambio = DateTime.Now;
                cPCatMensajesSAP.CPRol_id = 1;
                cPCatMensajesSAP.CPIdMsjSAP = 0;
                cPCatMensajesSAP.CPUsuarioAlta = int.Parse(Session["idUsuario"].ToString());
                cPCatMensajesSAP.CPUsuarioCambio = int.Parse(Session["idUsuario"].ToString());

                db.Entry(cPCatMensajesSAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPRol_id = new SelectList(db.CPRol, "id", "Nombre", cPCatMensajesSAP.CPRol_id);
            ViewBag.CPUsuarioAlta = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPCatMensajesSAP.CPUsuarioAlta);
            ViewBag.CPUsuarioCambio = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPCatMensajesSAP.CPUsuarioCambio);
            return View(cPCatMensajesSAP);
        }

        // GET: MensajesAnexos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPCatMensajesSAP cPCatMensajesSAP = db.CPCatMensajesSAP.Find(id);
            if (cPCatMensajesSAP == null)
            {
                return HttpNotFound();
            }
            return View(cPCatMensajesSAP);
        }

        // POST: MensajesAnexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPCatMensajesSAP cPCatMensajesSAP = db.CPCatMensajesSAP.Find(id);
            db.CPCatMensajesSAP.Remove(cPCatMensajesSAP);
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
