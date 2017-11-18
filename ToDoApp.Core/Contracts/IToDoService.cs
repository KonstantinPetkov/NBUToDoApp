using System.Collections.Generic;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Contracts
{
    /// <summary>
    /// Business logic for working with ToDos
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// Get ToDos from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<ToDoItemViewModel> GetToDos();

        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="model">Information about ToDo</param>
        void CreateItem(ToDoItemViewModel model);
    }
}
