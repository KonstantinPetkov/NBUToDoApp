using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Contracts;
using ToDoApp.Core.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService toDoService;

        public ToDoController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = toDoService.GetToDos();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ToDoItemViewModel();

            return View(model);
        }

        public IActionResult Create(ToDoItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                toDoService.CreateItem(model);
            }
            catch (Exception)
            {
                // Log the Error

                throw new Exception("Something happened!"); 
            }

            return RedirectToAction(nameof(this.Index));
        }
    }
}