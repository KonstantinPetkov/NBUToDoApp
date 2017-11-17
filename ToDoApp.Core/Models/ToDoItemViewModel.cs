using System.ComponentModel.DataAnnotations;
using ToDoApp.Infrastructure.Data.Models;

namespace ToDoApp.Core.Models
{
    public class ToDoItemViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 6)]
        [Required]
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
