using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAnimals.Models
{
    public class Owner
    {
        // member entitty with Identity memberid
        [Key]
        public int OwnerId { get; set; }
        // filed for storing name of the member
        public string Name { get; set; }
        [DataType(DataType.Date)]
        // Date of birth
        public DateTime DOB { get; set; }
        // gender of the member
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        // data of registration
        public DateTime DateRegistration { get; set; }
       // member's mobile and address
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}