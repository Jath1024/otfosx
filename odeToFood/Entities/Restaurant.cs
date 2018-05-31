﻿using System.ComponentModel.DataAnnotations;

namespace odeToFood.Entities
{
    public enum CuisineType{
        None,
        Italian,
        French,
        American
    }

    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}