using System;
using System.Collections.Generic;
using odeToFood.Entities;

namespace odeToFood.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public String CurrentGreeting { get; set; }
    }
}
