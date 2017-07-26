using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIC.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult RegistrarArticulos()
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

                //DDList Proveedores
                var getPro = db.proveedores.ToList();
                SelectList listPro = new SelectList(getPro, "id_Pro", "nombre_Pro");
                ViewBag.listpro = listPro;
            }
            return View();
        }

        public ActionResult CrearArticulo(articulos a, HttpPostedFileBase img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModel db = new DbModel())
                    {
                        a.nombre_Pro = a.nombre_Pro.ToUpper();
                        a.descripcion_Pro = a.descripcion_Pro.ToUpper();
                        a.imagen_Pro = new byte[img.ContentLength];
                        img.InputStream.Read(a.imagen_Pro, 0, img.ContentLength);
                        a.estatus_Pro = 1;
                        db.articulos.Add(a);
                        db.SaveChanges();

                        TempData["ConfirmationMessage"] = "Artículo Registrado";
                        return RedirectToAction("RegistrarArticulos");
                    }
                }
                TempData["ConfirmationMessage"] = "Es necesario proveer la información solicitada antes de continuar";
                return RedirectToAction("RegistrarArticulos");
            }
            catch
            {
                TempData["ConfirmationMessage"] = "No se pudo registrar el Artículo";
                return RedirectToAction("RegistrarArticulos");
            }

        }
    }
}