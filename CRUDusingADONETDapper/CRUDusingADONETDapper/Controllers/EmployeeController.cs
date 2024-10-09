using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDusingADONETDapper.Models;
using CRUDusingADONETDapper.Repository;

namespace CRUDusingADONETDapper.Controllers
{
    public class EmployeeController : Controller
    {
        //ttps://www.c-sharpcorner.com/UploadFile/0c1bb2/crud-operations-in-Asp-Net-mvc-5-using-dapper-orm/
        EmpRepositry empRepo = new EmpRepositry();
        public ActionResult Index()
        {
            return View(empRepo.GetAllEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpModel objEmp)
        {
            try
            {
                empRepo.AddEmployee(objEmp);              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
