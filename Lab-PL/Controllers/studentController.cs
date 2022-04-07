using lab_Model;
using Lab_Reposterys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Lab_PL.filter;

namespace Lab_PL.Controllers
{
    // [HandleError]
    public class studentController : Controller
    {
        //to inject the to contro we need to make interface to make it Genarl for all
        private IUnitOfWork unitOfWork;

        // GET: user

        //it is not a logic to save all operation here so we will use  {UnitOfWork Layer} to make it Reponble For Saving
        // in case ofF UnitOfWork controllers Now Deals With UnitOFWork layer Insted Off user or student Repo
        // UnitOfWork contians save method And which Repo You need
        /// <summary>
        /// we cal Imodelrepo to  to specifi which repo it work on
        /// userRepo exist in my unitofwork
        /// </summary>

        private IModelRepository<Student> studenrrepo;

        /// <summary>
        /// here as wo inject the constructor when we will run the project it will show error
        /// that contstructor shoud be parmaterless
        /// in this case we use the autfac
        /// </summary>

        public studentController(IUnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;

            studenrrepo = unitOfWork.GetStudentrepo();
        }

        [Authantaction]
        [Authorization]
        [ActionFilter]
        public ActionResult Index()
        {
            //
            //if (Session["userName"] == null)
            //    return RedirectToAction("login", "user");

            var students = studenrrepo.GetAll();

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //if (Session["userName"] == null)
            //    return RedirectToAction("login", "user");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            studenrrepo.Add(s);
            unitOfWork.Save();
            return RedirectToAction("Index", "student");
        }

        [HttpGet]
        public ActionResult Update(int ID)
        {
            Student model = studenrrepo.GetById(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Student model, long id)
        {
            studenrrepo.Update(model, id);
            unitOfWork.Save();
            return RedirectToAction("Index", "student");
        }

        public ActionResult Delete(int ID)
        {
            Student s = studenrrepo.GetById(ID);
            studenrrepo.Remove(s);
            unitOfWork.Save();
            return PartialView("_ListPartial", studenrrepo.GetAll());
            //return View("Index", studenrrepo.GetAll());
        }
    }
}