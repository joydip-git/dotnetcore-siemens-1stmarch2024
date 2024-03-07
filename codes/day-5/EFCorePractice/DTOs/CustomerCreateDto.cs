using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.DTOs
{
    public class CustomerCreateDto
    {
        public string Name { get; set; } = "";
        public string MailId { get; set; } = "";
        public long Mobile { get; set; }
    }
}
