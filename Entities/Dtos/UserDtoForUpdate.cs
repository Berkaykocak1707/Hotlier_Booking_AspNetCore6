using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserDtoForUpdate : UserDto
    {
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Password is required.")]
        //public string? Password
        //{
        //    get; init;
        //}
        public HashSet<string> UserRoles{ get; set;} = new HashSet<string>();
    }
}
