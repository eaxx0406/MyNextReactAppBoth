using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiderContext.Application.DTOs
{
    public class RiderDTO
    {
        public string RiderName { get; set; } = string.Empty;
        public int? Id { get; set; }
        public string Email { get; set; }
        public int BirthYear { get; set; }
    }
    
}
