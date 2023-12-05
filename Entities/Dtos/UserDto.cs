using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Username is required.")]
        public string? UserName
        {
        get; init; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        public string? Email
        {
        get; init;}
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber
        {
        get; init;}
        public HashSet<string> Roles
        {
        get; set;} = new HashSet<string>();
    }
}
