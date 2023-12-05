using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required")]
        public string Username
        {
            get; init;
        }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get; init;
        }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password",ErrorMessage = "Password and ConfirmPassword must be same.")]
        public string ConfirmPassword
        {
        get; init; }
    }
}
