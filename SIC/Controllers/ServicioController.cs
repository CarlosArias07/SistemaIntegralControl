using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace SIC.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult VerServiciosEnDesarrollo(int page = 1, string sort = "finicio", string sortdir = "desc", string search = "")
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

            //WebGridServicios
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = cargarServiciosEnDesarrollo(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;

            return View(data);
        }

        public List<servicios_info> cargarServiciosEnDesarrollo(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.servicios_info

                         where
                            (a.tipo_Pro.Contains(search) ||
                            a.nombre_EmpT.Contains(search) ||
                            a.nombre_Art.Contains(search)) &&
                            a.estatus_SerIns == 1
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
        public ActionResult VerServiciosEnDesarrolloD(string id)
        {
            int Id = Convert.ToInt32(id);
            using (DbModel db = new DbModel())
            {
                var model = (from a in db.servicios_info
                             where a.id_SerIns == Id
                             select a).ToList();

                return PartialView(model);
            }
        }

        public ActionResult VerServiciosSinIniciar(int page = 1, string sort = "finicio", string sortdir = "desc", string search = "")
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

            //WebGridServicios
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = cargarServiciosSinIniciar(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;

            return View(data);
        }

        public List<servicios_info> cargarServiciosSinIniciar(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.servicios_info

                         where
                            (a.tipo_Pro.Contains(search) ||
                            a.nombre_EmpT.Contains(search) ||
                            a.nombre_Art.Contains(search)) &&
                            a.estatus_SerIns == 0
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
        public ActionResult VerServiciosSinIniciarD(string id)
        {
            int Id = Convert.ToInt32(id);
            using (DbModel db = new DbModel())
            {
                var model = (from a in db.servicios_info
                             where a.id_SerIns == Id
                             select a).ToList();

                return PartialView(model);
            }
        }

        public ActionResult VerServiciosFinalizados(int page = 1, string sort = "ffinal", string sortdir = "desc", string search = "")
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

            //WebGridServicios
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = cargarServiciosFinalizados(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;

            return View(data);
        }

        public List<servicios_info> cargarServiciosFinalizados(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.servicios_info

                         where
                            (a.tipo_Pro.Contains(search) ||
                            a.nombre_EmpT.Contains(search) ||
                            a.nombre_Art.Contains(search)) &&
                            a.estatus_SerIns == 0
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
        public ActionResult VerServiciosSinIniciarD(string id)
        {
            int Id = Convert.ToInt32(id);
            using (DbModel db = new DbModel())
            {
                var model = (from a in db.servicios_info
                             where a.id_SerIns == Id
                             select a).ToList();

                return PartialView(model);
            }
        }
    }
}