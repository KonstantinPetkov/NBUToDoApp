using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.Core.Contracts;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Data.Contracts;
using ToDoApp.Infrastructure.Data.Models;

namespace ToDoApp.Core.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRDBERepository<ToDoItem> itemsRepo;

        public ToDoService(IRDBERepository<ToDoItem> itemsRepo)
        {
            this.itemsRepo = itemsRepo;
        }

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
