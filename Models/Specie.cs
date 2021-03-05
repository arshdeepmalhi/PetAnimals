using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAnimals.Models
{
    public class Specie
    {
        // specie of the animal separate entity to form relation with pet entity
        [Key]
        // identity
        public int SpecieId { get; set; }
        // name of the specie
        public string SpecieName { get; set; }
    }
}