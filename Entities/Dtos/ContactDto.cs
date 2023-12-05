using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ContactDto
    {
        public int ContactID
        {
            get; init;
        }

        [Required]
        [StringLength(100)]
        public string ContactName
        {
            get; init;
        }

        [Required]
        [EmailAddress]
        public string ContactEmail
        {
            get; init;
        }

        [Required]
        public string ContactSubject
        {
            get; init;
        }

        [Required]
        public string ContactMessage
        {
            get; init;
        }
    }
}
