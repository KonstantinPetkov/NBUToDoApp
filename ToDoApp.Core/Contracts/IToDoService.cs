using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Contracts
{
    public interface IToDoService
    {
        IEnumerable<ToDoItemViewModel> GetToDos();

        void CreateItem(ToDoItemViewModel model);
    }
}
