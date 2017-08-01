using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace SIC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index(int page = 1, string sort = "fecha_CotIns", string sortdir = "desc", string search = "")
        {
            int idEmp = Convert.ToInt32(Session["idEmp"]);
            int tipoUsu = Convert.ToInt32(Session["tipoUsu"]);

            ViewBag.idemp = idEmp;
            ViewBag.tipousu = tipoUsu;

            if(tipoUsu == 1)
            {
                ViewBag.tusu = "Administrador";
            }
            else
            {
                ViewBag.tusu = "Empleado";
            }

            using (DbModel db = new DbModel())
            {
                var v = db.empleados.Where(a => a.id_Emp.Equals(idEmp)).FirstOrDefault();
                ViewBag.nombreemp = v.nombre_Emp;

                if (tipoUsu == 1)
                {
                    var x = (from b in db.empleados_venta_instalacion
                             where b.considerada_EmpVenIns == 0
                             select b).Count();
                    ViewBag.ventas = x;

                    var y = (from b in db.empleados
                             where b.tipo_Emp == "V"
                             select b).Count();

                    ViewBag.vendedores = y;

                    var t = db.empleados_venta_instalacion.Sum(i => i.totalventa_EmpVenIns);

                    ViewBag.total = t;
                }

                if (tipoUsu == 2)
                {
                    var x = (from b in db.empleados_venta_instalacion
                             where b.id_Emp == idEmp &&
                             b.considerada_EmpVenIns == 0
                             select b).Count();
                    ViewBag.ventas = x;

                    var y = (from c in db.niveles_empleados
                             join n in db.niveles on c.id_Niv equals n.id_Niv
                             where c.id_Emp == idEmp
                             select n.descripcion_Niv).FirstOrDefault();

                    ViewBag.nivel = y;

                    var t = db.empleados_venta_instalacion.Where(u => u.id_Emp == idEmp).Sum(i => i.totalventa_EmpVenIns);

                    ViewBag.total = t;

                    //WebGridCotizaciones
                    int pageSize = 10;
                    int totalRecord = 0;
                    if (page < 1) page = 1;
                    int skip = (page * pageSize) - pageSize;
                    var data = cargarCotizacionesAceptadas(search, sort, sortdir, skip, pageSize, out totalRecord);
                    ViewBag.TotalRows = totalRecord;
                    ViewBag.Search = search;
                    return View(data);
                }
                    
            }
                return View();
        }

        public List<cotizaciones_info> cargarCotizacionesAceptadas(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        { 
            int ide = Convert.ToInt32(Session["idEmp"]);
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.cotizaciones_info

                         where
                            (a.tipo_Pro.Contains(search) ||
                            a.nombre_Emp.Contains(search) ||
                            a.nombre_Art.Contains(search)) &&
                            (a.estatus_CotIns == 1 ||
                             a.estatus_CotIns == 3) &&
                            a.id_Emp == ide
                         select a
                         );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                if (pageSize > 0)
                {
                    v = v.Skip(skip).Take(pageSize);
                }
                return v.ToList();
            }
        }

        [HttpGet]
        public ActionResult VerCotizacionesAceptadas(string id)
        {
            int Id = Convert.ToInt32(id);
            using (DbModel db = new DbModel())
            {
                var model = (from a in db.cotizaciones_info
                             where a.id_CotIns == Id
                             select a).ToList();

                return PartialView("~/Views/Cotizacion/VerCotizacionesAceptadas.cshtml", model);
            }
        }

        public static String ConvertByteArrayToBase64(int id)
        {
            using (DbModel db = new DbModel())
            {
                return Convert.ToBase64String(db.empleados.Where(c => c.id_Emp == id).First().img_Emp);
            }
        }
    }
}