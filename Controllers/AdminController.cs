using Microsoft.AspNetCore.Mvc;
using MySchoolProject.Models;
using MySchoolProject.Services;
using MySchoolProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISchoolService service;

        public AdminController(ISchoolService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListFaculties()
        {
            var model = await service.GetFacultiesAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddFaculty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFaculty(Faculty faculty)
        {

            if (ModelState.IsValid)
            {
                service.AddFaculty(faculty);
                return RedirectToAction("ListFaculties");
            }


            return View(faculty);
        }


        [HttpGet]
        public IActionResult EditFaculty(int id)
        {
            var model = service.GetFaculty(id);
            return View(model);

        }



        [HttpPost]
        public IActionResult EditFaculty(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                service.EditFaculty(faculty);
                return RedirectToAction("ListFaculties");
            }

            return View(faculty);

        }


        [HttpGet]
        public IActionResult ListDepartments()
        {
            var model = service.GetDepartments();
            return View(model);

        }


        [HttpGet]

        public IActionResult AddDepartment(int? id)
        {
            var model = new AddDepartmentViewModel() ;
            if (id == null)
            {
                 model = new AddDepartmentViewModel
                {
                    Department = new Department(),
                    Faculties = service.GetFaculties()
                };
            }
            else
            {
                model = new AddDepartmentViewModel
                {
                    Department = new Department(),
                    Faculties = service.GetFaculties()

                };

                ViewBag.DepartmentId = service.GetDepartments().First(x => x.Id == id).Id;
                ViewBag.DepartmentName = service.GetDepartments().First(x => x.Id == id).Name;
            }
            return View(model);

        }


        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                service.AddDepartment(department);
                return RedirectToAction("ListDepartments");
            }

            //foreach (var item in ModelState)
            //{
                
            //}

            return View(department);

        }


    }
}
