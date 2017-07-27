using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace SIC.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult RegistrarProveedores()
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
            return View();
        }

        [HttpPost]
        public ActionResult CrearProveedor(proveedores p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModel db = new DbModel())
                    {
                        p.nombre_Pro = p.nombre_Pro.ToUpper();
                        p.giro_Pro = p.giro_Pro.ToUpper();
                        p.direccion_Pro = p.direccion_Pro.ToUpper();
                        p.pagweb_Pro = p.pagweb_Pro.ToUpper();
                        p.estatus_Pro = 1;
                        db.proveedores.Add(p);
                        db.SaveChanges();

                        TempData["ConfirmationMessage"] = "Proveedor Registrado";
                        return RedirectToAction("RegistrarProveedores");
                    }
                }
                TempData["ConfirmationMessage"] = "Es necesario proveer la información solicitada antes de continuar";
                return RedirectToAction("RegistrarProveedores");
            }
            catch
            {
                TempData["ConfirmationMessage"] = "No se pudo registrar al Proveedor";
                return RedirectToAction("RegistrarProveedor");
            }

        }

        public ActionResult VerProveedores(int page = 1, string sort = "nombre_Pro", string sortdir = "asc", string search = "")
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

            //WebGridProveedores
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = cargarProveedores(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;

            return View(data);
        }

        public List<proveedores> cargarProveedores(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.proveedores
                         where
                            a.nombre_Pro.Contains(search) ||
                            a.giro_Pro.Contains(search) ||
                            a.direccion_Pro.Contains(search) ||
                            a.pagweb_Pro.Contains(search)
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
    }
}