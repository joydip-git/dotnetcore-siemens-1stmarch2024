using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp.Models
{
    public class EmployeeInfo
    {
        //model building through Data Annotation
        //[Key]
        //[Required]       
        public int Id { get; set; }

        //[Required]
        //[Column("empname", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        //[Required]
        //[Column("empsal", TypeName = "decimal(18,2)"]
        public decimal Salary { get; set; }

        public string Department { get; set; }=string.Empty;
    }
}
