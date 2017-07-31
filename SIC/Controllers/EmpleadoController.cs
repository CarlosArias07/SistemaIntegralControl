using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;

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
                            db.empleados.Add(e);
                            db.SaveChanges();

                            if (e.tipo_Emp.Equals("V") || e.tipo_Emp.Equals("T"))
                            {
                                usuarios u = new usuarios();
                                u.id_Emp = e.id_Emp;
                                u.contraseña_Usu = "xxxx";
                                u.tipo_Usu = 2;
                                db.usuarios.Add(u);
                                db.SaveChanges();
                            }

                            if (e.tipo_Emp.Equals("V"))
                            {
                                niveles_empleados ne = new niveles_empleados();
                                ne.id_Emp = e.id_Emp;
                                ne.id_Niv = 1;
                                db.niveles_empleados.Add(ne);
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

        public ActionResult VerEmpleados(int page = 1, string sort = "nombre_Emp", string sortdir = "asc", string search = "")
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

            //WebGridEmpleados
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = cargarEmpleados(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.Search = search;

            return View(data);
        }

        public List<empleados> cargarEmpleados(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (DbModel db = new DbModel())
            {
                var v = (from a in db.empleados
                         where
                            a.nombre_Emp.Contains(search) ||
                            a.apaterno_Emp.Contains(search) ||
                            a.amaterno_Emp.Contains(search) ||
                            a.correo_Emp.Contains(search) ||
                            a.tipo_Emp.Contains(search)
                         select a
                         );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                if(pageSize > 0)
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
    }
}