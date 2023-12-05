using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Subscribe
    {
        public int SubscribeID
        {
            get; set;
        }
        public string? SubscribeEmail
        {
            get; set;
        }
    }
}
