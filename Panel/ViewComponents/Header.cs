using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;


namespace Panel.Controllers
{
    public class Header : ViewComponent
    {


        private readonly TaskManagerContext _Context;

        public Header(TaskManagerContext Context)
        {
            _Context = Context;
        }

        [ResponseCache(Duration = 45000, Location = ResponseCacheLocation.Any)]
        public IViewComponentResult Invoke()
        {
            
            return View();


        }
    }
}
