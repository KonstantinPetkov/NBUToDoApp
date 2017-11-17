namespace ToDoApp.Infrastructure.Data.Models
{
    /// <summary>
    /// ToDoItems data table model
    /// </summary>
    public class ToDoItem
    {
        /// <summary>
        /// Primary key, record identificator
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the ToDo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description of the ToDo item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Flag shows if current ToDo completed
        /// </summary>
        public bool Completed { get; set; }
    }
}
