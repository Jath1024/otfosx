using odeToFood.Entities;
using System.Collections.Generic;
using System.Linq;

namespace odeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant newRestaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>{
                    new Restaurant { Id = 1, Name = "Mighty Quinn's"},
                    new Restaurant { Id = 2, Name = "Smokey Joe's"},
                    new Restaurant { Id = 3, Name = "Kings"}
                };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public void Add(Restaurant newRestaurant){
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }

        public Restaurant Get(int id){
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        static List<Restaurant> _restaurants;
    }
}
