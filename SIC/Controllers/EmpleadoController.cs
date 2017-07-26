using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SIC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult RegistrarEmpleados()
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
        public ActionResult CrearEmpleado(empleados e, HttpPostedFileBase img)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (DbModel db = new DbModel())
                    {
                        if (img != null)
                        {
                            //--Pendiente combobox para tipo empleado--//
                            e.nombre_Emp = e.nombre_Emp.ToUpper();
                            e.apaterno_Emp = e.apaterno_Emp.ToUpper();
                            e.amaterno_Emp = e.amaterno_Emp.ToUpper();
                            e.calle_Emp = e.calle_Emp.ToUpper();
                            e.colonia_Emp = e.colonia_Emp.ToUpper();
                            e.correo_Emp = e.correo_Emp.ToUpper();
                            e.estadoc_Emp = e.estadoc_Emp.ToUpper();
                            e.conquienvive_Emp = e.conquienvive_Emp.ToUpper();
                            e.familia_Emp = e.familia_Emp.ToUpper();
                            e.explaboral_Emp = e.explaboral_Emp.ToUpper();
                            e.especialidad_Emp = e.especialidad_Emp.ToUpper();
                            e.estatus_Emp = 1;
                            e.img_Emp = new byte[img.ContentLength];
                            img.InputStream.Read(e.img_Emp, 0, img.ContentLength);
                            /*byte[] imagen = new byte[img.ContentLength];
                            int readresult = img.InputStream.Read(imagen, 0, img.ContentLength);
                            e.img_Emp = imagen;*/
                            db.empleados.Add(e);
                            db.SaveChanges();

                            if (e.tipo_Emp.Equals("V"))
                            {
                                usuarios u = new usuarios();
                                u.id_Emp = e.id_Emp;
                                u.contraseña_Usu = "xxxx";
                                u.tipo_Usu = 2;
                                db.usuarios.Add(u);
                                db.SaveChanges();
                            }

                            TempData["ConfirmationMessage"] = "Empleado Registrado";
                            return RedirectToAction("RegistrarEmpleados");
                        }else
                        {
                            TempData["ConfirmationMessage"] = "El archivo de imagen seleccionado no es válido";
                           
                        }
                    }
                }
                TempData["ConfirmationMessage"] = "Es necesario proveer la información solicitada antes de continuar";
                return RedirectToAction("RegistrarEmpleados");
            }
            catch
            {
                TempData["ConfirmationMessage"] = "No se pudo registrar al Empleado";
                return RedirectToAction("RegistrarEmpleados");
            }
                
        }

        public ActionResult VerEmpleados()
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

        public ActionResult cargarEmpleados()
        {
            using (DbModel db = new DbModel())
            {
                //db.Configuration.LazyLoadingEnabled = false;
                //IQueryable<usuarios> q = db.usuarios.OrderBy(a => a.id_Emp);
                //var datos = db.niveles.OrderBy(a => a.id_Niv).ToList();
                var datos = db.niveles.Select(a => new
                {
                    a.id_Niv,
                    a.descripcion_Niv,
                    a.pcomision_Niv,
                    a.venta_Niv,
                }).ToList();
                /*var datos = db.empleados.Select(a => new
                {
                    id_Emp = a.id_Emp,
                    nombre_Emp = a.nombre_Emp,
                    apaterno_Emp = a.apaterno_Emp,
                    tipo_Emp = a.tipo_Emp,
                    correo_Emp = a.correo_Emp
                }).ToList();*/
                return Json(new { datos = datos }, JsonRequestBehavior.AllowGet);
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //return Json(Context), JsonRequestBehavior.AllowGet);
            }
        }
    }
}