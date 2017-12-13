namespace BookDoctor.Web.Models.AccountViewModels
{
    using BookDoctor.Data.Models.EnumTypes;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class RegisterViewModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public Sex Sex { get; set; }

        public string Info { get; set; }

        [Display(Name = "Register as a doctor?")]
        public bool IsDoctor { get; set; }

        public int MedicalCenterId { get; set; }

        public IEnumerable<SelectListItem> MedicalCenters { get; set; }

        public int SpecialtyId { get; set; }

        public IEnumerable<SelectListItem> Specialties { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
