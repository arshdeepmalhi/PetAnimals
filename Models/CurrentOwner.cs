using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAnimals.Models
{
    public class CurrentOwner
    {
        [Key] // creating a spearate ownership entity
        public int CurrentId { get; set; } // id field
                                         // 1 to many relation
        public int PetId { get; set; }
        public Pet  Pet{ get; set; }
        // 1 to many
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

    }
}