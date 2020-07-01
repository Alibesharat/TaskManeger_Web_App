using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }



        public string Description { get; set; }

        public Statuse Statuse { get; set; }




        public virtual ICollection<SubTask> SubTasks { get; set; }


    }
}
