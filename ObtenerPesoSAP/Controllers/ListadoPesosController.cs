using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ObtenerPesoSAP.Models;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Globalization;

namespace ObtenerPesoSAP.Controllers
{
    public class ListadoPesosController : Controller
    {
        private BDObtenerPesoSAPEntities db = new BDObtenerPesoSAPEntities();

        // GET: EditarPesos
        //public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        public ActionResult Index(string sortOrder, string currentFilter, string FeInicial, string FeFinal, string searchString, int? page)
        {
            
            var PlantaDF = int.Parse(Session["idPlantaDF"].ToString());
            int pageSize = 0;
            int pageNumber = 0;
            //var cPBitacora = db.CPBitacora.Include(c => c.CPCatEmpresas).Include(c => c.CPUsuario).Include(c => c.CPUsuario1);
            //return View(cPBitacora.Where(x => x.CPIdEmpresa == PlantaDF).ToList());
            int ReOrdena = 0;

            if (sortOrder != null)
            {
                ReOrdena = 0;
            }
            else
            {
                Session["OrdenInfo"] = "";
            }


            //if (Session["OrdenInfo"].ToString() != sortOrder)
            //{
            //    ReOrdena = 0;
            //}
            //else
            //{
            //    ReOrdena = 1;
            //}

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
                    //IFormatProvider culture = new CultureInfo("en-US", true);

                    var FechaIni = Convert.ToDateTime(FeInicial);
                    var FechaFin = Convert.ToDateTime(FeFinal);

                    //System.Globalization.CultureInfo enGB = new System.Globalization.CultureInfo("en-US");
                    //DateTime FechaIni = Convert.ToDateTime(FeInicial, enGB);
                    //DateTime FechaFin = Convert.ToDateTime(FeFinal, enGB);

                    //pageSize = 10;
                    // pageNumber = (page ?? 1);

                    //var query = from o in db.CPBitacora.ToList()                                
                    //            where o.CPIdEmpresa == PlantaDF && o.CPFechaEntrada >= FechaIni && o.CPFechaEntrada <= FechaFin
                    //select new SelectListItem
                    //            {
                    //                Transporte = o.CPIdTransporte,
                    //                Economico = o.CPNumEconomico,
                    //                Placas = o.CPPlaca,
                    //                Carta Porte = o.CPNumPorte,
                    //                Conductor = o.CPNomConductor,
                    //                Peso Tara = o.CPPesoEntrada,
                    //                Peso Bruto = o.CPPesoSalida,
                    //                Peso Neto = o.CPPesoNeto,
                    //                Entrada = o.CPFechaEntrada,
                    //                Salida = o.CpFechaSalida
                    //            };

                    //ViewBag.dropdownUsuario = query.OrderBy(u => u.Text).ToList();


                    Bitacora = Bitacora.Where(s => (s.CPIdEmpresa == PlantaDF) && (s.CPFechaEntrada >= FechaIni) && (s.CPFechaEntrada <= FechaFin));
                    //Bitacora = Bitacora.Where(s => s.CPIdEmpresa == PlantaDF);

                    //var RangoFechas = db.SpRangoFechasBitacora(PlantaDF, FechaIni, FechaFin);
                    //return View(db.SpRangoFechasBitacora(PlantaDF, FechaIni, FechaFin).ToPagedList(pageNumber, pageSize));


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
                    //Session["OrdenInfo"] = sortOrder;
                    break;
            }
            
            pageSize = 10;
            pageNumber = (page ?? 1);
            return View(Bitacora.ToPagedList(pageNumber, pageSize));
        }


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
            return View(cPBitacora);
        }

        // GET: EditarPesos/Create
        public ActionResult Create()
        {
            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa");
            ViewBag.CPIdTipoVehiculo = new SelectList(db.CPCatTiposDeVehiculos, "CPIdTipoVehiculo", "CPDescripcionVehiculo");
            ViewBag.CPIdUsuarioEnt = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario");
            ViewBag.CPIdUsuarioSal = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario");
            return View();
        }

        // POST: EditarPesos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPId,CPIdEmpresa,CPIdTransporte,CPNumEconomico,CPPlaca,CPNumPorte,CPNomConductor,CPPesoEntrada,CPPesoSalida,CPPesoNeto,CPIdTipoVehiculo,CPFechaEntrada,CpFechaSalida,CPEntrada,CPSalida,CPIdUsuarioEnt,CPIdUsuarioSal")] CPBitacora cPBitacora)
        {
            if (ModelState.IsValid)
            {
                db.CPBitacora.Add(cPBitacora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPBitacora.CPIdEmpresa);
            ViewBag.CPIdTipoVehiculo = new SelectList(db.CPCatMateriales, "CPIdMaterial", "CPDescripcionMaterial", cPBitacora.CPIdMaterial);
            ViewBag.CPIdUsuarioEnt = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPBitacora.CPIdUsuarioEnt);
            ViewBag.CPIdUsuarioSal = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPBitacora.CPIdUsuarioSal);
            return View(cPBitacora);
        }

        // GET: EditarPesos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Session["Id"] = id;
            }
            CPBitacora cPBitacora = db.CPBitacora.Find(id);
            if (cPBitacora == null)
            {
                return HttpNotFound();
            }

            ViewBag.CPIdEmpresa = new SelectList(db.CPCatEmpresas, "CPIdEmpresa", "CPDescripcionEmpresa", cPBitacora.CPIdEmpresa);
            ViewBag.CPIdTipoVehiculo = new SelectList(db.CPCatMateriales, "CPIdMaterial", "CPDescripcionMaterial", cPBitacora.CPIdMaterial);
            ViewBag.CPIdUsuarioEnt = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPBitacora.CPIdUsuarioEnt);
            ViewBag.CPIdUsuarioSal = new SelectList(db.CPUsuario, "CPIdUsuario", "CPNombreUsuario", cPBitacora.CPIdUsuarioSal);
            return View(cPBitacora);
        }

        // POST: EditarPesos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CPBitacora entity)
        {
            var Id = int.Parse(Session["Id"].ToString());

            var VarEntrada = 0;
            var VarSalida = 0;
            decimal IdTransporte = 0;

            //var Material = 0;
            var NumEco = "";
            var Placas = "";
            var Conductor = "";
            var Carta = "";

            var FechaIni = DateTime.Now;
            BDObtenerPesoSAPEntities context = new BDObtenerPesoSAPEntities();
            CPLogDeProcesos LogErrores = new CPLogDeProcesos();

            try
            {
                var ProcesoSAP = 0;
                var Busqueda = context.CPBitacora.Where(x => (x.CPId == Id)).FirstOrDefault();

                if (Busqueda != null)
                {

                    BDObtenerPesoSAPEntities dbCambios = new BDObtenerPesoSAPEntities();
                    CPBitacora Peso = new CPBitacora();
                    Peso.CPIdEmpresa = Busqueda.CPIdEmpresa;
                    Peso.CPIdTransporte = Busqueda.CPIdTransporte;
                    Peso.CPNumEconomico = Busqueda.CPNumEconomico.ToString();
                    Peso.CPNumPorte = Busqueda.CPNumPorte;
                    Peso.CPPlaca = Busqueda.CPPlaca.ToString();
                    Peso.CPNomConductor = Busqueda.CPNomConductor.ToString();
                    Peso.CPNumCelular = Busqueda.CPNumCelular;
                    Peso.CPFechaEntrada = Busqueda.CPFechaEntrada;
                    Peso.CPEntrada = Busqueda.CPEntrada;
                    Peso.CPId = Busqueda.CPId;
                    Peso.CPPesoEntrada = Busqueda.CPPesoEntrada;
                    Peso.CPPesoSalida = Busqueda.CPPesoSalida;
                    Peso.CPSalida = Busqueda.CPSalida;
                    Peso.CPIdUsuarioSal = Busqueda.CPIdUsuarioSal;
                    Peso.CpFechaSalida = Busqueda.CpFechaSalida;
                    Peso.CPIdUsuarioEnt = Busqueda.CPIdUsuarioEnt;
                    Peso.CPIdMaterial = Busqueda.CPIdMaterial;
                    Peso.CPNumDePasos = Busqueda.CPNumDePasos;
                    Peso.CPEstatus = Busqueda.CPEstatus;
                    Peso.CPIdDocumento = Busqueda.CPIdDocumento;
                    Peso.CPPartida = Busqueda.CPPartida;


                    if (Busqueda.CPPesoEntrada != entity.CPPesoEntrada)
                    {
                        VarEntrada = int.Parse(entity.CPPesoEntrada.ToString());
                    }
                    else
                    {
                        VarEntrada = int.Parse(Busqueda.CPPesoEntrada.ToString());
                    }

                    Peso.CPPesoEntrada = VarEntrada;


                    if (Busqueda.CPPesoSalida != entity.CPPesoSalida)
                    {
                        VarSalida = int.Parse(entity.CPPesoSalida.ToString());
                    }
                    else
                    {
                        VarSalida = int.Parse(Busqueda.CPPesoSalida.ToString());
                    }

                    Peso.CPPesoSalida = VarSalida;


                    double VarPesoNeto = (VarSalida - VarEntrada);

                    if (VarPesoNeto < 0)
                    {
                        VarPesoNeto = 0;
                    }

                    Peso.CPPesoNeto = VarPesoNeto;


                    if (Peso.CPPesoSalida == 0)
                    {
                        // esto es para darle reversa siempre y cuando el peso de salida lo teclemos en ceros
                        Peso.CPPesoNeto = 0;
                        Peso.CPSalida = false;
                        Peso.CPNumDePasos = 3;
                        Peso.CPEstatus = 1;
                    }


                    if (Peso.CPPesoEntrada == 0)
                    {
                        // esto es para darle reversa siempre y cuando el peso de entrada lo teclemos en ceros
                        Peso.CPPesoSalida = 0;
                        Peso.CPEntrada = false;
                        Peso.CPPesoNeto = 0;
                        Peso.CPSalida = false;
                        Peso.CPNumDePasos = 2;
                        Peso.CPEstatus = 1;
                    }


                    dbCambios.CPBitacora.Attach(Peso);
                    dbCambios.Entry(Peso).State = System.Data.Entity.EntityState.Modified;
                    dbCambios.SaveChanges();

                    if (Peso.CPPesoSalida == 0)
                    {
                        EnviaPesos.SI_OA_Peso_VehiculoClient Client = new EnviaPesos.SI_OA_Peso_VehiculoClient();
                        EnviaPesos.DT_Peso_Vehiculo contextWs = new EnviaPesos.DT_Peso_Vehiculo();
                        EnviaPesos.DT_Peso_VehiculoData datosWs = new EnviaPesos.DT_Peso_VehiculoData();

                        Client.ClientCredentials.UserName.UserName = "POCYDSAINT";
                        Client.ClientCredentials.UserName.Password = "Cydsa2019$";

                        datosWs.Vehicle_Number = Peso.CPIdTransporte.ToString();
                        datosWs.Weight_Initial = Peso.CPPesoEntrada.ToString();
                        datosWs.Weight_Final = "0";
                        datosWs.Economic_Number = Peso.CPNumEconomico.ToString();
                        datosWs.Licence_Plate = Peso.CPPlaca.ToString();
                        datosWs.Driver_Name = Peso.CPNomConductor.ToString();
                        datosWs.Carriage_Number = Peso.CPNumPorte.ToString();

                        datosWs.Check_In = "";
                        datosWs.Load_Start = "";
                        datosWs.Load_End = "X";


                        contextWs.data = datosWs;
                        var resultado = Client.SI_OA_Peso_Vehiculo(contextWs);

                        LogErrores.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                        LogErrores.CPIdTransporte = Busqueda.CPIdTransporte;
                        LogErrores.CPIdDocumento = Busqueda.CPIdDocumento;
                        LogErrores.CPIdMaterial = Busqueda.CPIdMaterial;
                        LogErrores.CPIdErrorSAP = 0;
                        LogErrores.CPDescripcionMensaje = "Se cancelo la salida del peso bruto";
                        LogErrores.CPPartidas = Busqueda.CPPartida;
                        LogErrores.CpFechaFinal = DateTime.Now;
                        LogErrores.CPFechaInicio = DateTime.Parse(FechaIni.ToString());
                        LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                        LogErrores.CPIdProceso = 11;
                        LogErrores.CPEstatus = "Completo";
                        LogErrores.CPRol = 1;
                        context.CPLogDeProcesos.Add(LogErrores);
                        context.SaveChanges();

                        // esto es para darle reversa siempre y cuando el peso de salida lo teclemos en ceros
                        ViewBag.VarConsecutivo = int.Parse(Session["IdTransporte"].ToString());
                        ViewBag.Message = "Se cancelo la salida del peso bruto, vuelva a realizar nuevamente este paso";
                        return RedirectToAction("Index");
                    }


                    if (Peso.CPPesoEntrada == 0)
                    {
                        EnviaPesos.SI_OA_Peso_VehiculoClient Client = new EnviaPesos.SI_OA_Peso_VehiculoClient();
                        EnviaPesos.DT_Peso_Vehiculo contextWs = new EnviaPesos.DT_Peso_Vehiculo();
                        EnviaPesos.DT_Peso_VehiculoData datosWs = new EnviaPesos.DT_Peso_VehiculoData();

                        Client.ClientCredentials.UserName.UserName = "POCYDSAINT";
                        Client.ClientCredentials.UserName.Password = "Cydsa2019$";

                        datosWs.Vehicle_Number = Peso.CPIdTransporte.ToString();
                        datosWs.Weight_Initial = "0";
                        datosWs.Weight_Final = "0";
                        datosWs.Economic_Number = Peso.CPNumEconomico.ToString();
                        datosWs.Licence_Plate = Peso.CPPlaca.ToString();
                        datosWs.Driver_Name = Peso.CPNomConductor.ToString();
                        datosWs.Carriage_Number = Peso.CPNumPorte.ToString();

                        datosWs.Check_In = "";
                        datosWs.Load_Start = "X";
                        datosWs.Load_End = "X";


                        contextWs.data = datosWs;
                        var resultado = Client.SI_OA_Peso_Vehiculo(contextWs);

                        LogErrores.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                        LogErrores.CPIdTransporte = Busqueda.CPIdTransporte;
                        LogErrores.CPIdDocumento = Busqueda.CPIdDocumento;
                        LogErrores.CPIdMaterial = Busqueda.CPIdMaterial;
                        LogErrores.CPIdErrorSAP = 0;
                        LogErrores.CPDescripcionMensaje = "Se cancelo el peso de la Tara y el peso bruto";
                        LogErrores.CPPartidas = Busqueda.CPPartida;
                        LogErrores.CpFechaFinal = DateTime.Now;
                        LogErrores.CPFechaInicio = DateTime.Parse(FechaIni.ToString());
                        LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                        LogErrores.CPIdProceso = 11;
                        LogErrores.CPEstatus = "Completo";
                        LogErrores.CPRol = 1;
                        context.CPLogDeProcesos.Add(LogErrores);
                        context.SaveChanges();

                        // esto es para darle reversa siempre y cuando el peso de salida lo teclemos en ceros
                        ViewBag.VarConsecutivo = int.Parse(Session["IdTransporte"].ToString());
                        ViewBag.Message = "Se cancelo el peso de la Tara y el peso bruto, vuelva a realizar nuevamente el pesaje";
                        return RedirectToAction("Index");
                    }

                    IdTransporte = decimal.Parse(Busqueda.CPIdTransporte.ToString());
                    NumEco = Busqueda.CPNumEconomico.ToString();
                    Placas = Busqueda.CPPlaca.ToString();
                    Conductor = Busqueda.CPNomConductor.ToString();
                    Carta = Busqueda.CPNumPorte;

                }
                else
                {
                    ViewBag.VarConsecutivo = int.Parse(Session["IdTransporte"].ToString());
                    ViewBag.Message = "No se encontro el nnumero de transporte";
                    return View();
                }




                var existente = "";
                //var mensaje = "";
                ProcesoSAP = 0;

                for (int x = 2; x < 5; x += 1)
                {
                    EnviaPesos.SI_OA_Peso_VehiculoClient Client = new EnviaPesos.SI_OA_Peso_VehiculoClient();
                    EnviaPesos.DT_Peso_Vehiculo contextWs = new EnviaPesos.DT_Peso_Vehiculo();
                    EnviaPesos.DT_Peso_VehiculoData datosWs = new EnviaPesos.DT_Peso_VehiculoData();

                    Client.ClientCredentials.UserName.UserName = "POCYDSAINT";
                    Client.ClientCredentials.UserName.Password = "Cydsa2019$";

                    datosWs.Vehicle_Number = IdTransporte.ToString();
                    datosWs.Weight_Initial = VarEntrada.ToString();
                    datosWs.Weight_Final = VarSalida.ToString();
                    datosWs.Economic_Number = NumEco.ToString();
                    datosWs.Licence_Plate = Placas.ToString();
                    datosWs.Driver_Name = Conductor.ToString();
                    datosWs.Carriage_Number = Carta.ToString();

                    ProcesoSAP = x;

                    switch (ProcesoSAP)
                    {
                        case 2:
                            datosWs.Check_In = "X";
                            datosWs.Load_Start = "";
                            datosWs.Load_End = "";
                            break;
                        case 3:
                            datosWs.Check_In = "";
                            datosWs.Load_Start = "X";
                            datosWs.Load_End = "";
                            break;
                        case 4:
                            datosWs.Check_In = "";
                            datosWs.Load_Start = "";
                            datosWs.Load_End = "X";
                            break;
                    }

                    contextWs.data = datosWs;
                    var resultado = Client.SI_OA_Peso_Vehiculo(contextWs);


                    if (existente == "E" && existente == "A")
                    {

                    }

                }

                var existente2 = "";
                var mensaje2 = "";

                CierreProceso.SI_OS_UpdatePickingClient Client2 = new CierreProceso.SI_OS_UpdatePickingClient();
                CierreProceso.DT_UpdatePicking contextWs2 = new CierreProceso.DT_UpdatePicking();
                CierreProceso.DT_UpdatePickingData datosWs2 = new CierreProceso.DT_UpdatePickingData();

                Client2.ClientCredentials.UserName.UserName = "POCYDSAINT";
                Client2.ClientCredentials.UserName.Password = "Cydsa2019$";

                datosWs2.Vehicle_Number = IdTransporte.ToString();
                contextWs2.data = datosWs2;
                var resultado2 = Client2.SI_OS_UpdatePicking(contextWs2);
                existente2 = resultado2[0].Response;
                mensaje2 = resultado2[0].Message;

                if (existente2 != "E")
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    var PlantaDF = int.Parse(Session["idPlantaDF"].ToString());
                    var CierrePasos = context.CPBitacora.Where(w => (w.CPIdEmpresa == PlantaDF) && (w.CPIdTransporte == IdTransporte)).FirstOrDefault();
                    if (CierrePasos != null)
                    {
                        BDObtenerPesoSAPEntities CmbRegresa = new BDObtenerPesoSAPEntities();
                        CPBitacora Regresar = new CPBitacora();
                        Regresar.CPId = CierrePasos.CPId;
                        Regresar.CPIdTransporte = int.Parse(Session["IdTransporte"].ToString());

                        Regresar.CPNumEconomico = CierrePasos.CPNumEconomico;
                        Regresar.CPPlaca = CierrePasos.CPPlaca;
                        Regresar.CPNomConductor = CierrePasos.CPNomConductor;
                        Regresar.CPNumPorte = CierrePasos.CPNumPorte;

                        Regresar.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                        Regresar.CPIdUsuarioEnt = int.Parse(Session["idUsuario"].ToString());
                        Regresar.CPIdMaterial = CierrePasos.CPIdMaterial;
                        Regresar.CPNumCelular = CierrePasos.CPNumCelular;
                        Regresar.CPIdUsuarioSal = int.Parse(Session["idUsuario"].ToString());

                        switch (ProcesoSAP)
                        {
                            case 2:
                                //CPPartidas cPPartida = CmbRegresa.CPPartidas.Find(CierrePasos.CPId);
                                //CmbRegresa.CPPartidas.Remove(cPPartida);
                                //CmbRegresa.SaveChanges();

                                CPBitacora cPBitacora = CmbRegresa.CPBitacora.Find(CierrePasos.CPId);
                                CmbRegresa.CPBitacora.Remove(cPBitacora);
                                CmbRegresa.SaveChanges();


                                var Transporte = int.Parse(Session["IdTransporte"].ToString());

                                var BuscaPartidas = context.CPPartidas.Where(w => (w.CPId == Transporte)).FirstOrDefault();
                                if (BuscaPartidas != null)
                                {
                                    CPPartidas Partidas = context.CPPartidas.Find(BuscaPartidas.CPId);
                                    context.CPPartidas.Remove(Partidas);
                                    context.SaveChanges();

                                }
                                break;
                            case 3:
                                Regresar.CPPesoEntrada = CierrePasos.CPPesoEntrada;
                                Regresar.CPEntrada = CierrePasos.CPEntrada;

                                Regresar.CPFechaEntrada = CierrePasos.CPFechaEntrada;
                                Regresar.CPPesoEntrada = 0;
                                Regresar.CPEntrada = false;

                                Regresar.CpFechaSalida = CierrePasos.CpFechaSalida;
                                Regresar.CPPesoSalida = 0;
                                Regresar.CPSalida = false;

                                Regresar.CPPesoNeto = 0;
                                Regresar.CPNumDePasos = 2;
                                Regresar.CPEstatus = 1;
                                CmbRegresa.CPBitacora.Attach(Regresar);
                                CmbRegresa.Entry(Regresar).State = System.Data.Entity.EntityState.Modified;
                                CmbRegresa.SaveChanges();
                                break;
                            case 4:
                                Regresar.CPPesoEntrada = CierrePasos.CPPesoEntrada;
                                Regresar.CPEntrada = CierrePasos.CPEntrada;
                                Regresar.CPFechaEntrada = CierrePasos.CPFechaEntrada;

                                Regresar.CpFechaSalida = CierrePasos.CpFechaSalida;
                                Regresar.CPPesoSalida = 0;
                                Regresar.CPSalida = false;

                                Regresar.CPPesoNeto = 0;
                                Regresar.CPNumDePasos = 3;
                                Regresar.CPEstatus = 1;
                                CmbRegresa.CPBitacora.Attach(Regresar);
                                CmbRegresa.Entry(Regresar).State = System.Data.Entity.EntityState.Modified;
                                CmbRegresa.SaveChanges();
                                break;
                        }


                        LogErrores.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                        LogErrores.CPIdTransporte = Busqueda.CPIdTransporte;
                        LogErrores.CPIdDocumento = Busqueda.CPIdDocumento;
                        LogErrores.CPIdMaterial = Busqueda.CPIdMaterial;
                        LogErrores.CPDescripcionMensaje = "Ocurrio un error al momento de modificar el registro";
                        LogErrores.CPPartidas = Busqueda.CPPartida;
                        LogErrores.CpFechaFinal = DateTime.Now;
                        LogErrores.CPFechaInicio = DateTime.Parse(FechaIni.ToString());
                        LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                        LogErrores.CPIdProceso = 11;
                        LogErrores.CPEstatus = "Error";
                        LogErrores.CPRol = 1;
                        context.CPLogDeProcesos.Add(LogErrores);
                        context.SaveChanges();


                        ViewBag.VarConsecutivo = int.Parse(Session["IdTransporte"].ToString());
                        ViewBag.dropdownUsuario = new SelectList(context.CPUsuario.ToList(), "CPIdUsuario", "CPNombreUsuario");

                        //MaterialesADO cargaMaterialADO = new MaterialesADO();
                        //ViewBag.dropdownMateriales = new SelectList(cargaMaterialADO.cmbMateriales(int.Parse(Session["idPlantaDF"].ToString())), "CPIdMaterial", "CPDescripcionMaterial");

                        ViewBag.Message = mensaje2;
                        return View();
                    }
                }
            }
            catch (Exception e)
            {
                LogErrores.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                LogErrores.CPIdTransporte = 0;
                LogErrores.CPIdDocumento = 0;
                LogErrores.CPIdMaterial = 0;
                LogErrores.CPIdErrorSAP = 0;
                LogErrores.CPDescripcionMensaje = e.ToString();
                LogErrores.CPPartidas = 0;
                LogErrores.CpFechaFinal = DateTime.Now;
                LogErrores.CPFechaInicio = DateTime.Parse(FechaIni.ToString());
                LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                LogErrores.CPIdProceso = 11;
                LogErrores.CPEstatus = "Error";
                LogErrores.CPRol = 1;
                context.CPLogDeProcesos.Add(LogErrores);
                context.SaveChanges();

                ModelState.AddModelError("error al agregar o modificar datos", e);
                return RedirectToAction("Index");

            }
            return View();
        }


        // GET: EditarPesos/Delete/5
        public ActionResult Delete(int? id)
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
            return View(cPBitacora);
        }

        // POST: EditarPesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var IdPlanta = int.Parse(Session["idPlantaDF"].ToString());
            var FechaIni = DateTime.Now;
            CPLogDeProcesos LogErrores = new CPLogDeProcesos();
            BDObtenerPesoSAPEntities context = new BDObtenerPesoSAPEntities();



            CPBitacora cPBitacora = context.CPBitacora.Find(id);
            context.CPBitacora.Remove(cPBitacora);
            context.SaveChanges();

            //CPBitacora cPBitacora = db.CPBitacora.Find(id);
            //db.CPBitacora.Remove(cPBitacora);
            //db.SaveChanges();

            var CierrePasos = context.CPPartidas.Where(w => (w.CPIdEmpresa == IdPlanta) && (w.CPId == id)).FirstOrDefault();
            try
            {
                if (CierrePasos != null)
                {
                    LogErrores.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                    LogErrores.CPIdTransporte = CierrePasos.CPIdTransporte;
                    LogErrores.CPIdDocumento = CierrePasos.CPIdDocumento;
                    LogErrores.CPIdMaterial = long.Parse(CierrePasos.CPIdMaterial.ToString());
                    LogErrores.CPIdErrorSAP = 0;
                    LogErrores.CPDescripcionMensaje = "Se borro el registro completo de Numero de Transporte";
                    LogErrores.CPPartidas = CierrePasos.CPPartida;
                    LogErrores.CpFechaFinal = DateTime.Now;
                    LogErrores.CPFechaInicio = DateTime.Parse(FechaIni.ToString());
                    LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                    LogErrores.CPIdProceso = 11;
                    LogErrores.CPEstatus = "Correcto";
                    LogErrores.CPRol = 1;
                    context.CPLogDeProcesos.Add(LogErrores);
                    context.SaveChanges();

                    CPPartidas cPPartida = context.CPPartidas.Find(CierrePasos.CPId);
                    context.CPPartidas.Remove(cPPartida);
                    context.SaveChanges();

                }

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                LogErrores.CPIdEmpresa = int.Parse(Session["idPlantaDF"].ToString());
                LogErrores.CPIdTransporte = CierrePasos.CPIdTransporte;
                LogErrores.CPIdDocumento = CierrePasos.CPIdDocumento;
                LogErrores.CPIdMaterial = long.Parse(CierrePasos.CPIdMaterial.ToString());
                LogErrores.CPIdErrorSAP = 0;
                LogErrores.CPDescripcionMensaje = e.ToString();
                LogErrores.CPPartidas = CierrePasos.CPPartida;
                LogErrores.CpFechaFinal = DateTime.Now;
                LogErrores.CPFechaInicio = DateTime.Parse(FechaIni.ToString());
                LogErrores.CPIdUsuario = int.Parse(Session["idUsuario"].ToString());
                LogErrores.CPIdProceso = 11;
                LogErrores.CPEstatus = "Error";
                LogErrores.CPRol = 1;
                context.CPLogDeProcesos.Add(LogErrores);
                context.SaveChanges();

                ModelState.AddModelError("error al agregar o modificar datos", e);
                return RedirectToAction("Index");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



















        //public JsonResult Busqueda(string sortOrder, string QueBuscar = "", string FechaIni = "", string FechaFin = "")
        //{
        //    CPLogDeProcesos LogErrores = new CPLogDeProcesos();
        //    CPBitacora Bitacora = new CPBitacora();
        //    var Planta = int.Parse(Session["idPlantaDF"].ToString());



        //    try
        //    {
        //        var Busca = db.CPBitacora.Where(x => (x.CPIdTransporte == int.Parse(QueBuscar.ToString()))).FirstOrDefault();

        //        if (Busca != null)
        //        {

        //            return Json(db.CPBitacora.ToList().Where(x => (x.CPIdTransporte == Consecutivo)).Select(x => new { CPIdEmpresa = x.CPIdEmpresa, CPIdMaterial = x.CPIdMaterial, CPPesoEntrada = x.CPPesoEntrada, CPPesoSalida = x.CPPesoSalida, CPNumEconomico = x.CPNumEconomico, CPPlaca = x.CPPlaca, CPNomConductor = x.CPNomConductor, CPFechaEntrada = x.CPFechaEntrada, CpFechaSalida = x.CpFechaSalida, CPEntrada = x.CPEntrada, CPSalida = x.CPSalida, CPNumPorte = x.CPNumPorte, CPNumCelular = x.CPNumCelular, CPPesoNeto = x.CPPesoNeto, CPEstatus = x.CPEstatus }), JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {


        //                return Json(ValorSAP);
        //        }


        //    }
        //    catch (Exception e)
        //    {

        //        return Json(e);
        //    }

        //}
    }
}
