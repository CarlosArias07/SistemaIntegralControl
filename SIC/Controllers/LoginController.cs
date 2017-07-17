using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuarios u)
        {
            if(ModelState.IsValid)
            {
                using (DbModel db = new DbModel())
                {
                    var v = db.usuarios.Where(a => a.id_Emp.Equals(u.id_Emp) && a.contraseña_Usu.Equals(u.contraseña_Usu)).FirstOrDefault();
                    if(v != null)
                    {
                        Session["IDEmp"] = v.id_Emp.ToString();
                        return RedirectToAction("Index");
                    }

                    return RedirectToAction("Login");
                }
            }

            return View(u);
        }
    }
}