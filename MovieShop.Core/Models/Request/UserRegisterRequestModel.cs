using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage ="Email cannot be empty")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage ="Email should be in valid format (abc123@example.com)")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password cannot be empty")]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength =8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", 
            ErrorMessage = "password must have at least one capital, small, number and special character, 8 length long")]
        // 1 capital, small, number and special character, 8 length, max 100
        public string Password { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [Compare("Password", ErrorMessage ="password must be same")]
        // 1 capital, small, number and special character, 8 length, max 100
        public string RePassword { get; set; }

        [Required(ErrorMessage ="First Name cannot be empty")]
        [StringLength(50)]
        public string FirtName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
