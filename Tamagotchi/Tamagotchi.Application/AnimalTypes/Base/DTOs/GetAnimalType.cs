﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Application.AnimalTypes.Base.DTOs
{
    public class GetAnimalType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Must Enter a Name")]
        public string Name { get; set; }
        public string? Coats { get; set; }
        public string? Colors { get; set; }
        //[Range(1,100,ErrorMessage = "Enter number between 1 and 100 only!")]
        public string? Genders { get; set; }
    }
}