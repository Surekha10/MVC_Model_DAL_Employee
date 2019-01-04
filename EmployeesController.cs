using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Model_DAL_Employee.Models;

namespace MVC_Model_DAL_Employee.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)//Server Side Validation
            {
                EmployeeDAL dal = new EmployeeDAL();
                bool status = dal.Login(model);
                if (status == true)
                {
                    Session["loginid"] = model.LoginID;
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ViewBag.msg = "Invalid User ID or Password";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            int loginid = Convert.ToInt32(Session["loginid"]);
            ViewBag.loginid = loginid;
            return View();
        }
        public ActionResult NewEmployee()
        {
            EmployeeDAL dal = new EmployeeDAL();
            ViewBag.cities = dal.GetCities();
            return View();
        }
        [HttpPost]
        public ActionResult NewEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.EmpoyeeImageAddress = "/Images/" + Guid.NewGuid() + ".jpg";
                model.EmployeeImageFile.SaveAs(Server.MapPath(model.EmpoyeeImageAddress));
                EmployeeDAL dal = new EmployeeDAL();
                int id = dal.AddEmployee(model);
                ViewBag.msg = "Employee Added : " + id;
                ModelState.Clear();
                ViewBag.cities = dal.GetCities();
                return View();
            }
            else
            {
                EmployeeDAL dal = new EmployeeDAL();
                ViewBag.cities = dal.GetCities();
                return View();
            }
        }
        public ActionResult Search()
        {
            List<EmployeeProjectionModel> list = new List<EmployeeProjectionModel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult Search(string key)
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeProjectionModel> list = dal.Search(key);
            return View(list);
        }
        public ActionResult Find(int id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            EmployeeModel model = dal.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            bool status = dal.Delete(id);
            return View();
        }
        public ActionResult Edit(int id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            EmployeeModel model = dal.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            EmployeeDAL dal = new EmployeeDAL();
            dal.Update(model.EmployeeID, model.EmployeePassword);
            return View("View_Updated");
        }
    }
}