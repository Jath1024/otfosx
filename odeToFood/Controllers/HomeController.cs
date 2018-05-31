using Microsoft.AspNetCore.Mvc;
using odeToFood.ViewModels;
using odeToFood.Services;
using odeToFood.Entities;

namespace odeToFood.Controllers
{
    public class HomeController: Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [HttpGet]
        public ViewResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model){
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantData.Add(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        public ViewResult Index(){

            //var model = new Restaurant{ Id = 1, Name = "Lombardis" };

            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();
                
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null){
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
