using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp
{
    //   public class Employee
    //   {
    //	private int id;
    //	private string name;
    //	private decimal salary;

    //       public Employee()
    //       {
    //		name = string.Empty;
    //       }

    //       public Employee(int id, string name, decimal salary)
    //       {
    //           this.id = id;
    //           this.name = name ?? throw new ArgumentNullException(nameof(name));
    //           this.salary = salary;
    //       }

    //       public decimal Salary
    //	{
    //		get { return salary; }
    //		set { salary = value; }
    //	}


    //	public string Name
    //	{
    //		get { return name; }
    //		set { name = value; }
    //	}


    //	public int Id
    //	{
    //		get { return id; }
    //		set { id = value; }
    //	}

    //}
    public class EmployeeReadOnlyDTO
    {
        public int Id { get; set; }
        //public required string Name { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int? DeptId { get; set; }
        //navigation poperty
        public Department Department { get; set; }

        public Employee()
        {

        }
        public Employee(int id, string name, decimal salary, int deptId, Department department)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Salary = salary;
            DeptId = deptId;
            Department = department;
        }
    }
}
