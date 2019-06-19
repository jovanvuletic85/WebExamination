using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebExamination.Models
{
    [Table("Patient")]
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Enter a dentist")]
        public string Dentist { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter a MM/dd/yyyy")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Enter a identification number")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "You must enter numbers")]
        public int IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter a review")]
        [StringLength(300, ErrorMessage = "Enter minimum 10 and maximum 300 characters", MinimumLength = 10)]
        [Display(Name = "Review")]
        [DataType(DataType.MultilineText)]
        public string Review { get; set; }
    }
}