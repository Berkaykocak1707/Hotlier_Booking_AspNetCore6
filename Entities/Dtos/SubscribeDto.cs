using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record SubscribeDto
    {
        public int SubscribeID
        {
            get; init;
        }

        [Required]
        [EmailAddress]
        public string SubscribeEmail
        {
            get; init;
        }
    }
}
