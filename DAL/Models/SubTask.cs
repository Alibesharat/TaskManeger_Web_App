using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class SubTask
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public Statuse Statuse { get; set; }

        [ForeignKey(nameof(TaskItem))]
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}
