using firstmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstmvc.Controllers
{
    public class HomeController : Controller
    {
        studentEntities db = new studentEntities();
        public ActionResult Index()
        {
            ViewBag.allStudents = db.Users.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Qeydiyyat()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Elementler()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                ViewBag.activeStudent = db.Users.FirstOrDefault(st => st.id == id);
            }
            else
            {
                ViewBag.Error = "bele bir telebe yoxdur";
            }

            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Bele bir istifadeci yoxdur";
            }
            ViewBag.activeStudent = db.Users.FirstOrDefault(st => st.id == id);
            ViewBag.SelectedGroup = db.Groups.ToList();

            return View();
        }


        [HttpPost]

        public ActionResult Edit(int? id,string firstname,string lastname,string email,int group_id)
        {
            if (firstname != "" && lastname != "" && email != ""  )
            { User usr = db.Users.FirstOrDefault(us => us.id == id);
                usr.Firstname = firstname;
                usr.Lastname = lastname;
                usr.Email = email;
                usr.Group_id = group_id;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Error = "Zehmet olmasa butun xanalari doldurun";
            }

            return View();
        }
    }
}