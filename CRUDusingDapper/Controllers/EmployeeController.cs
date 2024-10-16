﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDusingDapper.Models;
using CRUDusingDapper.Repository;

namespace CRUDusingDapper.Controllers
{
    public class EmployeeController : Controller
    {
        EmpRepository empRepo = new EmpRepository();
        // GET: Employee
        public ActionResult Index()
        {
            return View(empRepo.GetAllEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(empRepo.GetAllEmployees().Find(e => e.Id == id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
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
            return View(empRepo.GetAllEmployees().Find(e=>e.Id==id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmpModel objEmp)
        {
            try
            {
                empRepo.UpdateEmployee(objEmp);
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
            if (empRepo.DeleteEmployee(id))
            {
                ViewBag.AlertMsg = "Employee details deleted successfully";
            }
            return View("Index");
        }
    }
}
