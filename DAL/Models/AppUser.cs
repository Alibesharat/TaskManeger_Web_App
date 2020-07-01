using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }


        public string UserName { get; set; }


        public string Rols { get; set; }


    }

   
}
