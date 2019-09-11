using ObtenerPesoSAP.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Globalization;

namespace ObtenerPesoSAP.Controllers
{
    public class BitacoraController : Controller
    {
        private BDObtenerPesoSAPEntities db = new BDObtenerPesoSAPEntities();

        // GET: Bitacora
        public ActionResult Bitacora(string sortOrder, string currentFilter, string FeInicial, string FeFinal, string searchString, int? page)
        {

            var PlantaDF = int.Parse(Session["idPlantaDF"].ToString());
            int pageSize = 0;
            int pageNumber = 0;
            int ReOrdena = 0;

            if (sortOrder != null)
            {
                ReOrdena = 0;
            }
            else
            {
                Session["OrdenInfo"] = "";
            }


            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Transporte" : "";
            ViewBag.DateSortParm = sortOrder == "Entrada" ? "Salida" : "Date";

            if (searchString != null)
            {
                page = 1;
                sortOrder = "Transporte";
            }
            else
            {
                searchString = currentFilter;

            }

            ViewBag.CurrentFilter = searchString;

            var Bitacora = from s in db.CPBitacora
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {

                Bitacora = Bitacora.Where(s => s.CPIdEmpresa == PlantaDF && s.CPIdTransporte.ToString().Contains(searchString)
                                                   || s.CPNumEconomico.Contains(searchString)
                                                   || s.CPPlaca.Contains(searchString)
                                                   || s.CPNumPorte.Contains(searchString)
                                                   || s.CPNomConductor.Contains(searchString)
                                                   || s.CPPesoEntrada.ToString().Contains(searchString)
                                                   || s.CPPesoSalida.ToString().Contains(searchString)
                                                   || s.CPPesoNeto.ToString().Contains(searchString)
                                                   || s.CPFechaEntrada.ToString().Contains(searchString)
                                                   || s.CpFechaSalida.ToString().Contains(searchString)
                                                   );
            }
            else
            {

                if (FeInicial != null && FeInicial != "")
                {
                    var FechaIni = Convert.ToDateTime(FeInicial);
                    var FechaFin = Convert.ToDateTime(FeFinal);
                    Bitacora = Bitacora.Where(s => (s.CPIdEmpresa == PlantaDF) && (s.CPFechaEntrada >= FechaIni) && (s.CPFechaEntrada <= FechaFin));
                }
                else
                {
                    Bitacora = Bitacora.Where(s => s.CPIdEmpresa == PlantaDF);
                }
            }

            switch (sortOrder)
            {
                case "Transporte":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPIdTransporte);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPIdTransporte);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Economico":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPNumEconomico);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPNumEconomico);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Placas":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPPlaca);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPPlaca);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Carta Porte":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPNumPorte);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPNumPorte);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Conductor":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPNomConductor);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPNomConductor);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }

                case "Peso Tara":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPPesoEntrada);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPPesoEntrada);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Peso Bruto":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPPesoSalida);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPPesoSalida);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Peso Neto":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPPesoNeto);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPPesoNeto);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Entrada":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CPFechaEntrada);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CPFechaEntrada);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                case "Salida":
                    if (Session["OrdenInfo"].ToString() != sortOrder)
                    {
                        Bitacora = Bitacora.OrderBy(s => s.CpFechaSalida);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }
                    else
                    {
                        Bitacora = Bitacora.OrderByDescending(s => s.CpFechaSalida);
                        Session["OrdenInfo"] = sortOrder;
                        break;
                    }

                default:

                    Bitacora = Bitacora.OrderByDescending(s => s.CPIdTransporte);
                    break;
            }

            pageSize = 10;
            pageNumber = (page ?? 1);
            return View(Bitacora.ToPagedList(pageNumber, pageSize));
        }

       
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}


        // GET: EditarPesos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPBitacora cPBitacora = db.CPBitacora.Find(id);
            if (cPBitacora == null)
            {
                return HttpNotFound();
            }
            ViewBag.VarConsecutivo = cPBitacora.CPIdTransporte;
            return View(cPBitacora);
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public JsonResult WebSer(int IdPlanta = 0, long Id = 0, string IdTipo = "", string FechaIni = "")
        {
            BDObtenerPesoSAPEntities context = new BDObtenerPesoSAPEntities();
            CPLogDeProcesos LogErrores = new CPLogDeProcesos();
            CPBitacora Bitacora = new CPBitacora();
            var Planta = int.Parse(Session["idPlantaDF"].ToString());

            Session["IdTransporte"] = Id;
            Session["TipoVehiculo"] = IdTipo;

            var Consecutivo = long.Parse(Id.ToString());


            var existenteDoc = "";
            var mensajeDoc = "";


            List<Tabla> lsitTabla = new List<Tabla>();
            lsitTabla.Clear();

            DocEntrega.SI_OS_Consulta_NumCargaClient ClientDoc = new DocEntrega.SI_OS_Consulta_NumCargaClient();
            DocEntrega.DT_Consulta_NumCarga contextWsDoc = new DocEntrega.DT_Consulta_NumCarga();
            DocEntrega.DT_Consulta_NumCargaData datosWsDoc = new DocEntrega.DT_Consulta_NumCargaData();

            ClientDoc.ClientCredentials.UserName.UserName = "POCYDSAINT";
            ClientDoc.ClientCredentials.UserName.Password = "Cydsa2019$";

            datosWsDoc.Numero_Transporte = Session["IdTransporte"].ToString();

            contextWsDoc.data = datosWsDoc;

            var resultadoDoc = ClientDoc.SI_OS_Consulta_NumCarga(contextWsDoc);

            var RegDoc = resultadoDoc.OPTIONS.item.Count();

            decimal SumaDeProd = 0;
            decimal elemetomayor = 0;
            decimal valoromayor = 0;
            for (int i = 0; i < RegDoc; i++)
            {
                PartidasMateriales.SI_OA_TM101_Consulta_EntregaClient ClientMat = new PartidasMateriales.SI_OA_TM101_Consulta_EntregaClient();
                PartidasMateriales.DT_TM101_Consulta_Entrega_Req contextWsMat = new PartidasMateriales.DT_TM101_Consulta_Entrega_Req();
                PartidasMateriales.DT_TM101_Consulta_Entrega_ReqItem datosWsMat = new PartidasMateriales.DT_TM101_Consulta_Entrega_ReqItem();

                ClientMat.ClientCredentials.UserName.UserName = "POCYDSAINT";
                ClientMat.ClientCredentials.UserName.Password = "Cydsa2019$";

                if (resultadoDoc.OPTIONS.item[i].Response.ToString() != null)
                {
                    datosWsMat.DELIV_NUMB = resultadoDoc.OPTIONS.item[i].Response.ToString();
                }
                else
                {
                    datosWsMat.DELIV_NUMB = "";
                }

                if (resultadoDoc.OPTIONS.Type.ToString() != "E")
                {
                    Session["IdDocumento"] = long.Parse(datosWsMat.DELIV_NUMB.ToString());
                }

                contextWsMat.item = datosWsMat;
                var resultadoMat = ClientMat.SI_OA_TM101_Consulta_Entrega(contextWsMat);
                decimal VarRequerido = 0;
                var RegPda = resultadoMat.ET_DELIVERY_ITEM.Count();
                var ColPda = 4;
                var NoEncontroMat = 0;
                decimal idMaterial = 0;

                for (int f = 0; f < RegPda; f++)
                {
                    Tabla tabla = new Tabla();


                    if (resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString() != null && resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString() != "")
                    {
                        idMaterial = long.Parse(resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString());
                    }
                    else
                    {
                        idMaterial = 0;
                    }

                    var ValidaCodigo = db.CPCatMateriales.Where(x => (x.CPIdEmpresa == IdPlanta) & (x.CPIdMaterialSAP == idMaterial)).FirstOrDefault();
                    if (ValidaCodigo != null)
                    {
                        if (resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString() != null && resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString() != "")
                        {
                            idMaterial = decimal.Parse(resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString());
                            tabla.Id = idMaterial.ToString();
                        }
                        else
                        {
                            tabla.Id = "0";
                        }

                        if (resultadoMat.ET_DELIVERY_ITEM[f].LFIMG.ToString() != null && resultadoMat.ET_DELIVERY_ITEM[f].LFIMG.ToString() != "")
                        {
                            VarRequerido = decimal.Parse(resultadoMat.ET_DELIVERY_ITEM[f].LFIMG.ToString());
                            var TipoPeso = resultadoMat.ET_DELIVERY_ITEM[f].MEINS.ToString();
                            TipoPeso = TipoPeso.Substring(0, 1);

                            if (TipoPeso == "T")
                            {
                                VarRequerido = (VarRequerido * 1000);
                            }

                            if (valoromayor < decimal.Parse(resultadoMat.ET_DELIVERY_ITEM[f].LFIMG.ToString()))
                            {



                                tabla.Requerido = VarRequerido.ToString();

                                valoromayor = VarRequerido;
                                elemetomayor = decimal.Parse(resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString());

                            }

                            SumaDeProd = (SumaDeProd + VarRequerido);
                        }
                        else
                        {
                            tabla.Requerido = "0";
                        }

                        if (resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString() != null && resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString() != "")
                        {
                            tabla.Codigo = resultadoMat.ET_DELIVERY_ITEM[f].MATNR.ToString();
                        }
                        else
                        {
                            tabla.Codigo = "";
                        }


                        if (resultadoMat.ET_DELIVERY_ITEM[f].ARKTX.ToString() != null && resultadoMat.ET_DELIVERY_ITEM[f].ARKTX.ToString() != "")
                        {
                            tabla.Descripcion = resultadoMat.ET_DELIVERY_ITEM[f].ARKTX.ToString();
                        }
                        else
                        {
                            tabla.Descripcion = "";
                        }

                        tabla.Requerido = VarRequerido.ToString();

                        lsitTabla.Add(tabla);
                    }
                }


                Session["valoromayor"] = valoromayor;
                Session["elemetomayor"] = elemetomayor;

                if (elemetomayor == 0)
                {
                    LogErrores.CPIdEmpresa = Planta;
                    LogErrores.CPIdTransporte = long.Parse(Session["IdTransporte"].ToString());
                    LogErrores.CPIdDocumento = 0;
                    LogErrores.CPIdMaterial = elemetomayor;
                    LogErrores.CPIdErrorSAP = 0;
                    LogErrores.CPDescripcionMensaje = "El material no esta dado de alta dentro del portal vaya la opcion catalogos en materiales para darlo de alta";
                    LogErrores.CPPartidas = 0;
                    LogErrores.CpFechaFinal = DateTime.Now;
                    LogErrores.CPFechaInicio = DateTime.Parse(FechaIni);
                    LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                    LogErrores.CPIdProceso = 3;
                    LogErrores.CPEstatus = "Error";
                    LogErrores.CPRol = 1;
                    context.CPLogDeProcesos.Add(LogErrores);
                    context.SaveChanges();

                    NoEncontroMat = -1;
                    return Json(NoEncontroMat);
                }
            }

            return Json(lsitTabla, JsonRequestBehavior.AllowGet);
        }




        public JsonResult Index3(int IdPlanta = 0, long Id = 0, string IdTipo = "", string FechaIni = "")
        {
            CPLogDeProcesos LogErrores = new CPLogDeProcesos();
            CPBitacora Bitacora = new CPBitacora();
            var Planta = int.Parse(Session["idPlantaDF"].ToString());

            Session["IdTransporte"] = Id;
            Session["TipoVehiculo"] = IdTipo;

            var Consecutivo = long.Parse(Id.ToString());
            long ValorSAP = 0;
            var RespBusqueda = 0;
            var MensajeError = "";


            try
            {
                var Busca = db.CPBitacora.Where(x => (x.CPIdTransporte == Consecutivo)).FirstOrDefault();

                if (Busca != null)
                {
                    if (Busca.CPSalida == null)
                    {
                        RespBusqueda = int.Parse(("2").ToString());
                    }
                    else
                    {
                        RespBusqueda = int.Parse(("3").ToString());
                    }


                    return Json(db.CPBitacora.ToList().Where(x => (x.CPIdTransporte == Consecutivo)).Select(x => new { CPIdEmpresa = x.CPIdEmpresa, CPIdMaterial = x.CPIdMaterial, CPPesoEntrada = x.CPPesoEntrada, CPPesoSalida = x.CPPesoSalida, CPNumEconomico = x.CPNumEconomico, CPPlaca = x.CPPlaca, CPNomConductor = x.CPNomConductor, CPFechaEntrada = x.CPFechaEntrada, CpFechaSalida = x.CpFechaSalida, CPEntrada = x.CPEntrada, CPSalida = x.CPSalida, CPNumPorte = x.CPNumPorte, CPNumCelular = x.CPNumCelular, CPPesoNeto = x.CPPesoNeto, CPEstatus = x.CPEstatus }), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var PlantaSAP = 0;
                    RespBusqueda = int.Parse(("1").ToString());

                    ValidaTransporte.SI_OS_Consulta_TransporteClient Client3 = new ValidaTransporte.SI_OS_Consulta_TransporteClient();
                    ValidaTransporte.DT_Consulta_Tranporte contextWs3 = new ValidaTransporte.DT_Consulta_Tranporte();
                    ValidaTransporte.DT_Consulta_TranporteData datosWs3 = new ValidaTransporte.DT_Consulta_TranporteData();

                    Client3.ClientCredentials.UserName.UserName = "POCYDSAINT";
                    Client3.ClientCredentials.UserName.Password = "Cydsa2019$";

                    datosWs3.Numero_Transporte = Session["IdTransporte"].ToString();
                    datosWs3.Centro_Logistico = Session["idPlantaDF"].ToString();

                    contextWs3.data = datosWs3;
                    var resultado3 = Client3.SI_OS_Consulta_Transporte(contextWs3);
                    var existente3 = resultado3.OPTIONS[0].Type;
                    var Respuesta = resultado3.OPTIONS[0].Response;
                    long IdTransporteSAP = 0;

                    if (existente3 != "E")
                    {
                        var Col = 0;

                        Col = Respuesta.IndexOf(",");
                        var Cons = Respuesta.Substring(0, Col);


                        if (Cons != null)
                        {
                            IdTransporteSAP = long.Parse(Cons.ToString());
                        }
                        Col = Col + 1;
                        Respuesta = Respuesta.Remove(0, Col);



                        Col = Respuesta.IndexOf(",");

                        if (PlantaSAP == 0)
                        {
                            PlantaSAP = int.Parse(Respuesta.ToString());
                        }


                        ValorSAP = Consecutivo;
                    }
                    else
                    {
                        IdTransporteSAP = 0;
                    }


                    if (existente3 != "E")
                    {
                        return Json(db.CPBitacora.ToList().Where(x => (x.CPIdTransporte == Consecutivo)).Select(x => new { CPIdEmpresa = x.CPIdEmpresa, CPIdMaterial = x.CPIdMaterial, CPPesoEntrada = x.CPPesoEntrada, CPPesoSalida = x.CPPesoSalida, CPNumEconomico = x.CPNumEconomico, CPPlaca = x.CPPlaca, CPNomConductor = x.CPNomConductor, CPFechaEntrada = x.CPFechaEntrada, CpFechaSalida = x.CpFechaSalida, CPEntrada = x.CPEntrada, CPSalida = x.CPSalida, CPNumPorte = x.CPNumPorte, CPNumCelular = x.CPNumCelular, CPPesoNeto = x.CPPesoNeto, CPEstatus = x.CPEstatus, ErrorSAP = x.CPIdUsuarioSal }), JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (IdTransporteSAP == Consecutivo)
                        {
                            if (IdTransporteSAP == 0 && Consecutivo == 0)
                            {
                                ValorSAP = -4;
                            }
                            else
                            {
                                if (Respuesta != "")
                                {

                                    ValorSAP = -2;
                                }
                                else
                                {
                                    ValorSAP = -3;
                                }

                            }
                        }
                        else
                        {
                            ValorSAP = -1;
                        }

                        switch (ValorSAP)
                        {
                            case -1:
                                MensajeError = "El numero de transporte no existe ne SAP";
                                break;
                            case -2:
                                MensajeError = "El numero de transporte pertenece a otra planta";
                                break;
                            case -3:
                                MensajeError = "El numero de transporte No se encontro en SAP";
                                break;
                            case -4:
                                MensajeError = "El numero de transporte no puede ser cero";
                                break;
                        }

                        return Json(ValorSAP);
                    }
                }


            }
            catch (Exception e)
            {

                return Json(e);
            }

        }



        public JsonResult BuscaClientes(int IdPlanta = 0, long Id = 0)
        {
            BDObtenerPesoSAPEntities context = new BDObtenerPesoSAPEntities();
            CPLogDeProcesos LogErrores = new CPLogDeProcesos();
            CPBitacora Bitacora = new CPBitacora();

            var Planta = int.Parse(Session["idPlantaDF"].ToString());
            Session["IdTransporte"] = Id;

            var Consecutivo = long.Parse(Id.ToString());
            List<TablaClientes> lsitTablaCli = new List<TablaClientes>();
            lsitTablaCli.Clear();

            Complementos.SI_OS_BasculaComplementoClient ClientComple = new Complementos.SI_OS_BasculaComplementoClient();
            Complementos.DT_Bascula_ComplementoREQ contextWsComple = new Complementos.DT_Bascula_ComplementoREQ();
            Complementos.DT_Bascula_ComplementoREQData datosWsComple = new Complementos.DT_Bascula_ComplementoREQData();

            ClientComple.ClientCredentials.UserName.UserName = "POCYDSAINT";
            ClientComple.ClientCredentials.UserName.Password = "Cydsa2019$";
            datosWsComple.Transporte = Session["IdTransporte"].ToString();

            contextWsComple.data = datosWsComple;
            var resultadoComple = ClientComple.SI_OS_BasculaComplemento(contextWsComple);
            var existenteComple = resultadoComple.RESULT.ToString();
            //var Respuesta = resultadoComple.RESULT[0].ToString();

            if (existenteComple != "E")
            {
                Session["Transportista"] = resultadoComple.NOM_TRANSPORTISTA.ToString();
                Session["FechaPlaneada"] = resultadoComple.FECHA_PLAN.ToString();

                var RegComple = resultadoComple.CLIENTES.Count();
                for (int f = 0; f < RegComple; f++)
                {
                    TablaClientes tabla2 = new TablaClientes();
                    tabla2.IdCliente = resultadoComple.CLIENTES[f].NUM_CLIENTE.ToString();
                    tabla2.NombreCliente = resultadoComple.CLIENTES[f].NOM_CLIENTE.ToString();
                    tabla2.PoblacionCli = resultadoComple.CLIENTES[f].POBLACION.ToString();
                    tabla2.RegionCli = resultadoComple.CLIENTES[f].REGION.ToString();

                    DateTime fecha = DateTime.Parse(resultadoComple.FECHA_PLAN.ToString());
                    string fechaSalida1 = fecha.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"));

                    tabla2.FechaPlan = fechaSalida1;
                    //ToString("dd, MM", CultureInfo.InvariantCulture);
                    tabla2.Transportista = resultadoComple.NOM_TRANSPORTISTA.ToString();

                    lsitTablaCli.Add(tabla2);
                }

            }

         
            var Trans = resultadoComple.NOM_TRANSPORTISTA.ToString();
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            var userInfoJson = jss.Serialize(ViewBag.Trans);

            return Json(lsitTablaCli, JsonRequestBehavior.AllowGet);
        }


    }
}
