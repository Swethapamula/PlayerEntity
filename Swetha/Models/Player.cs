using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Swetha.Models
{
    public class Player
    {
        [Display(Name ="Player ID")]
        [Range(10000,999999,ErrorMessage ="you need to enter a valid EmployeeID(should be 6 digits)")]
        public int PlayerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="You need to enter the First name.")]
        public String FirstName{ get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to enter the Last name.")]
        public String LastName {get; set; }


        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to enter the email address.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Email Address")]
        [Compare("EmailAddress", ErrorMessage = "The Email address and confirm Email should match")]
        public string ConfirmEmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="you must have a password")]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength = 7,ErrorMessage ="Password length must be more than 7 char and less than 50 char")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }

    }
}