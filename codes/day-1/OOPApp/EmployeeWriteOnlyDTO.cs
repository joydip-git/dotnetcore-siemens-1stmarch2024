using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp
{
    public class EmployeeWriteOnlyDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
    }
}
