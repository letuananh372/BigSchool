using Bigchool1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bigchool1.Controllers
{
    public class CoursesController : Controller
    {
        public ActionResult Create()
        {
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.listCategory = context.Category.ToList();
            return View(objCourse);
        }

        [Authorize]
        [HttpPost]
      [ValidateAntiForgeryToken]
        // GET: Courses
        public ActionResult Create( Course objCourse)
        {

            BigSchoolContext context = new BigSchoolContext();
            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
                objCourse.listCategory= context.Category.ToList();
                return View("Create", objCourse);
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LecturerId = user.Id;
            context.Course.Add(objCourse);
            context.SaveChangesAsync();


            return RedirectToAction("Index","Home");
        }
    }
}