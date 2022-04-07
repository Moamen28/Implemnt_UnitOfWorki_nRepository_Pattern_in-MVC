using lab_Model;
using Lab_PL.filter;
using Lab_Reposterys;
using Lab_ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_PL.Controllers
{
    // [HandleError]
    public class userController : Controller
    {
        private IUnitOfWork unitOfWork;
        private IModelRepository<User> userRepo;

        // GET: user
        public userController(IUnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
            userRepo = unitOfWork.Getuserrepo();
        }

        public ActionResult login()
        {
            //if (Request.Cookies["mycookies"] != null)
            //{
            //    Session["userName"] = Request.Cookies["mycookies"].Values["username"];
            //    return RedirectToAction("index", "student");
            //}

            return View();
        }

        [HttpPost]
        public ActionResult login(LoginData lo, bool remeber)
        {
            // var usser = userRepo.GetAll().ToList().Select(i => i.ToViewModel());
            User user = userRepo.GetAll().ToList().Where(n => n.UserName == lo.User_Name && n.Password == lo.password).FirstOrDefault();
            if (user != null)
            {
                if (remeber)
                {
                    HttpCookie co = new HttpCookie("mycookies");
                    co.Values.Add("username", user.UserName);
                    co.Expires = DateTime.Now.AddDays(5);
                    Response.Cookies.Add(co);
                }
                Session["userName"] = user.UserName;
                // Session.Add("userName", user.UserName);
                // return PartialView("_pariatlloginview", lo);
                return RedirectToAction("Index", "student", new { UserName = user.UserName });
            }
            else
            {
                ViewBag.mess = "Incorrect user Name or Password";
                return View();
            }
        }

        public ActionResult logout()
        {
            // throw new Exception();
            Session["userName"] = null;
            HttpCookie c = new HttpCookie("mycookies");
            c.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(c);
            return RedirectToAction("login");
        }
    }
}