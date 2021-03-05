using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAnimals.Models
{
    public class Pet
    {// pet entity with identity PetId
        [Key]
        public int PetId { get; set; }
        // name of the pet
        public string PetName { get; set; }
        // arrival date of the pet
        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; }
    // sex of the pet
        public string PetSex { get; set; }
        // weight of the pet
        public double Weight { get; set; }
        // date pf adaption
        [DataType(DataType.Date)]
        public DateTime AdaptionDate { get; set; }
        public bool AdoptionStatus { get; set; }

        public int SpecieId { get; set; }
        public Specie Specie { get; set; }

    }
}