using Microsoft.AspNetCore.Mvc;
using System;
using ToDoApp.Core.Contracts;
using ToDoApp.Core.Models;

namespace ToDoApp.Controllers
{
    /// <summary>
    /// Manage ToDos
    /// </summary>
    public class ToDoController : Controller
    {
        /// <summary>
        /// Injected implementation of business logic and data handling
        /// </summary>
        private readonly IToDoService toDoService;

        /// <summary>
        /// Public constructor used for injecting of dependancies
        /// </summary>
        /// <param name="toDoService">Implementation of business logic and data handling</param>
        public ToDoController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        /// <summary>
        /// Display list of ToDos
        /// </summary>
        /// <returns>View with list of todos</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var model = toDoService.GetToDos();

            return View(model);
        }

        /// <summary>
        /// Generates view for creating new ToDo
        /// </summary>
        /// <returns>View with form for new ToDo creation</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ToDoItemViewModel();

            return View(model);
        }

        /// <summary>
        /// Handles creating of new ToDo
        /// </summary>
        /// <param name="model">Information about the ToDo to be created</param>
        /// <returns>Redirects to list of ToDos</returns>
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