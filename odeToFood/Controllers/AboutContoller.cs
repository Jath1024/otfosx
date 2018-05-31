using Microsoft.AspNetCore.Mvc;
namespace odeToFood.Controllers
{
    public class AboutContoller: Controller
    {
        public IActionResult Phone(){
            return Content("+440778877434");
        }
        public IActionResult Country(){
            return Content("UK");
        }
    }
}
