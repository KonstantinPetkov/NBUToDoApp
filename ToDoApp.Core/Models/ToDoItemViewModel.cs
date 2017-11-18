using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.Models
{
    /// <summary>
    /// ViewModel used to abstract DTO from View
    /// </summary>
    public class ToDoItemViewModel
    {
        /// <summary>
        /// Identificator of ToDo
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ToDo's name
        /// Demostrating the use of Display Data Anotation Attribute
        /// </summary>
        [Display(Name = "To Do")]
        public string Name { get; set; }

        /// <summary>
        /// ToDo's description
        /// Demostrating data validation with attributes
        /// </summary>
        [StringLength(100, MinimumLength = 6)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// If ToDo is completed
        /// </summary>
        public bool Completed { get; set; }
    }
}
