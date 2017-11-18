using System.Collections.Generic;
using System.Linq;
using ToDoApp.Core.Contracts;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Data.Contracts;
using ToDoApp.Infrastructure.Data.Models;

namespace ToDoApp.Core.Services
{
    /// <summary>
    /// Business logic for working with ToDos
    /// </summary>
    public class ToDoService : IToDoService
    {
        /// <summary>
        /// Repository to access ToDoItems table in the DB
        /// </summary>
        private readonly IRDBERepository<ToDoItem> itemsRepo;

        /// <summary>
        /// Public constructor used to inject dependancies 
        /// </summary>
        /// <param name="itemsRepo"></param>
        public ToDoService(IRDBERepository<ToDoItem> itemsRepo)
        {
            this.itemsRepo = itemsRepo;
        }

        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="model">Information about ToDo</param>
        public void CreateItem(ToDoItemViewModel model)
        {
            ToDoItem item = new ToDoItem()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Completed = model.Completed
            };

            itemsRepo.Add(item);
            itemsRepo.SaveChanges();
        }

        /// <summary>
        /// Get ToDos from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ToDoItemViewModel> GetToDos()
        {
            return itemsRepo.AllReadonly()
                .Where(t => t.Completed == false)
                .Select(t => new ToDoItemViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Completed = t.Completed
                });
        }
    }
}
