using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            int idEmp = Convert.ToInt32(Session["idEmp"]);
            int tipoEmp = Convert.ToInt32(Session["tipoEmp"]);

            ViewBag.idemp = idEmp;
            ViewBag.tipoemp = tipoEmp;

            using (DbModel db = new DbModel())
            {
                var v = db.empleados.Where(a => a.id_Emp.Equals(idEmp)).FirstOrDefault();
                ViewBag.nombreemp = v.nombre_Emp;
            }

                return View();
        }
    }
}