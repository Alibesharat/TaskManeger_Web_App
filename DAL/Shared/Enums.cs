using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public enum Statuse
    {
        [Display(Name = "در انتظار")]
        Pending,
        [Display(Name = "در حال انجام")]
        Doing,
        [Display(Name = "انجام شده")]
        Done
    }


    public enum Rol
    {
        [Display(Name = "مدیر")]
        Manager,
        [Display(Name = "کارمند")]
        Employee
    }
}
