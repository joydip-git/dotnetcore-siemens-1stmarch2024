using OOPApp;

Console.WriteLine("Hello, World!");
Console.ReadLine();

List<Department> departments = new List<Department>
{
    new Department { Id=1, Name="HR"},
};

EmployeeReadOnlyDTO anilEmployee = new EmployeeReadOnlyDTO { Id = 1, Name = "", Salary = 0, Department = departments[0] };

//anilEmployee.Department.Name