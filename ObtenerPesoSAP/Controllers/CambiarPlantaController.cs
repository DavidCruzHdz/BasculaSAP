using ObtenerPesoSAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObtenerPesoSAP.Controllers
{
    public class CambiarPlantaController : Controller
    {
        // GET: CambiarPlanta
        public ActionResult CambiarPlanta()
        {
            BDObtenerPesoSAPEntities db = new BDObtenerPesoSAPEntities();

            int id = int.Parse(Session["idUsuario"].ToString());
          
            CPPermisosPlantas cPPermisosPlantas = db.CPBascula.Find(id);
            if (cPPermisosPlantas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPPermisosPlantas.CPIdEmpresa);
            ViewBag.CPIdUsuario = new SelectList(db.CPUsuario.Where(o => o.CPIdUsuario == id), "CPIdUsuario", "CPNombreUsuario", cPPermisosPlantas.CPIdUsuario);
            ViewBag.dropdownTipos = new SelectList(db.CPCatTipoCaptura.ToList(), "CPIdTipoCaptura", "CPDescripcion");
            return View(cPPermisosPlantas);
        }


        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult CambiarPlanta(CPPermisosPlantas entity)
        {
             BDObtenerPesoSAPEntities context = new BDObtenerPesoSAPEntities();
            try
            {
                int VarUsuario = int.Parse(Session["idUsuario"].ToString());
                CPPermisosPlantas Cambios = new CPPermisosPlantas();
            
                Cambios.CPId = entity.CPId;
                Cambios.CPIdEmpresa = entity.CPIdEmpresa;
                Cambios.CPIdUsuario = VarUsuario;
                Cambios.CPFechaAlta = System.DateTime.Now;
                Cambios.CPUsuarioAlta = VarUsuario;
                Cambios.CPFechaCambio = System.DateTime.Now;
                Cambios.CPUsuarioCambio = VarUsuario;
                Cambios.CPPlantaDefault = true;
               
                Cambios.CPUsuarioCambio = VarUsuario;
                Cambios.CPIdTipoCaptura = entity.CPIdTipoCaptura;
                context.CPBascula.Attach(Cambios);
                context.Entry(Cambios).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

               
                    var empresa = context.CPBascula.Where(x => x.CPIdUsuario == VarUsuario && x.CPPlantaDefault == true).FirstOrDefault().CPIdEmpresa;

                    Session["logeado"] = true;
                    Session["idUsuario"] = VarUsuario;
                    Session["idPlantaDF"] = context.CPBascula.Where(x => x.CPIdUsuario == VarUsuario && x.CPPlantaDefault == true).FirstOrDefault().CPIdEmpresa;
                    Session["TipoCaptura"] = context.CPBascula.Where(x => x.CPIdUsuario == VarUsuario && x.CPPlantaDefault == true).FirstOrDefault().CPIdTipoCaptura;
                    Session["NombrePlanta"] = context.CPCatEmpresas.Where(x => x.CPIdEmpresa == empresa).FirstOrDefault().CPDescripcionEmpresa;
                    Session["IdUserAutoriza"] = 0;
                    Session.Timeout = 50000;
                    return Redirect("/Home/Index");
            }
            catch
            {
                ViewBag.dropdownPlanta = new SelectList(context.CPCatEmpresas.ToList(), "CPIdEmpresa", "CPDescripcionEmpresa");
                return View();
            }
        }
    }
}