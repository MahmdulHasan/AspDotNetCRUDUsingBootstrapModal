using BootstrapModalCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapModalCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<Employee> employeeList = _db.Employees.ToList<Employee>();
            return Json(new { data = employeeList }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }

            else
            {
                return Json(_db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            if (emp.EmployeeId == 0)
            {
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _db.Entry(emp).State = EntityState.Modified;
                _db.SaveChanges();
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
                return Json(new { success = true, message = " Not Deleted" }, JsonRequestBehavior.AllowGet);

            var empDetails = _db.Employees.Find(id);
            _db.Employees.Remove(empDetails);
            _db.SaveChanges();

            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}