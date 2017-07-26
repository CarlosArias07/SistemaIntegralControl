using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}