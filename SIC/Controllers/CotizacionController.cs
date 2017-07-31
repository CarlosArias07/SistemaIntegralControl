using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace SIC.Controllers
{
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        public ActionResult VerCotizacionesAsignacion(int page = 1, string sort = "nombre_Emp", string sortdir = "asc", string search = "")
        {
            int idEmp = Convert.ToInt32(Session["idEmp"]);
            int tipoUsu = Convert.ToInt32(Session["tipoUsu"]);
            
            ViewBag.idemp = idEmp;
            ViewBag.tipousu = tipoUsu;

            if (tipoUsu == 1)
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
            }

            //WebGridCotizaciones
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = cargarCotizacionesAsignacion(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;

            return View(data);
        }

        public List<cotizaciones_info> cargarCotizacionesAsignacion(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.cotizaciones_info

                         where
                            (a.tipo_Pro.Contains(search) ||
                            a.nombre_Emp.Contains(search) ||
                            a.nombre_Art.Contains(search)) &&
                            a.estatus_CotIns == 1
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

        public static String ConvertByteArrayToBase64(int id)
        {
            using (DbModel db = new DbModel())
            {
                return Convert.ToBase64String(db.empleados.Where(c => c.id_Emp == id).First().img_Emp);
            }
        }

        [HttpGet]
        public ActionResult AsignarCotizaciones(string id)
        {
            int Id = Convert.ToInt32(id);
            using (DbModel db = new DbModel())
            {
                var model = (from a in db.cotizaciones_info
                             where a.id_CotIns == Id
                             select a).ToList();

                int page = 1;
                string sort = "nombre_Emp";
                string sortdir = "asc";
                string search = "";
                int pageSize = 10;
                int totalRecord = 0;
                if (page < 1) page = 1;
                int skip = (page * pageSize) - pageSize;
                var model2 = cargarEmpleados(search, sort, sortdir, skip, pageSize, out totalRecord);
                ViewBag.TotalRows = totalRecord;
                ViewBag.Search = search;
                ViewBag.idCot = Id;

                return PartialView(new cotizacionesInfo_empleados { Model1 = model, Model2 = model2 });
            }
        }

        public List<empleados> cargarEmpleados(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.empleados
                         where
                            a.tipo_Emp.Equals("T") &&
                            (a.nombre_Emp.Contains(search) ||
                            a.apaterno_Emp.Contains(search) ||
                            a.amaterno_Emp.Contains(search) ||
                            a.correo_Emp.Contains(search) ||
                            a.tipo_Emp.Contains(search))
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
        public ActionResult Asignar(int ide, int idc)
        {
            try
            {
                empleados_asignados_instalacion eai = new empleados_asignados_instalacion();
                
                using (DbModel db = new DbModel())
                {
                    /*var s = (from a in db.servicios_instalacion
                             where
                             a.id_CotIns == idc
                             select a
                               );*/
                    int s = db.servicios_instalacion.Where(c => c.id_CotIns == idc).First().id_SerIns;
                    eai.id_SerIns = s;
                    eai.id_Emp = ide;
                    //eai.fasignacion_EmpAsiIns = DateTime.Now;
                    DateTime date = DateTime.Now;
                    string fd = date.ToString("yyyy-MM-dd");
                    eai.fasignacion_EmpAsiIns = Convert.ToDateTime(fd);
                    db.empleados_asignados_instalacion.Add(eai);
                    db.SaveChanges();

                    cotizaciones_instalacion ci = db.cotizaciones_instalacion.First(c => c.id_CotIns == idc);
                    ci.estatus_CotIns = 3;
                    db.SaveChanges();

                    TempData["ConfirmationMessage"] = "Empleado Asignado";
                    return RedirectToAction("VerCotizacionesAsignacion");
                }
            }catch
            {

            }
            TempData["ConfirmationMessage"] = "No se pudo asignar al Empleado";
            return RedirectToAction("VerCotizacionesAsignacion");
        }
    }
}