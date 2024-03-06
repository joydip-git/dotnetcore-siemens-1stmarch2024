using System.Data;
using System.Data.SqlClient;

namespace DataApp
{
    internal class Program
    {
        static IEnumerable<Employee> FetchData()
        {
            //windows authentication for sql server
            //string connectionString = @"server=joydip-pc\sqlexpress;database=testdb;integrated security=sspi";

            //sql server authentication for sql server
            string connectionString = @"server=joydip-pc\sqlexpress;database=testdb;user id=sa;password=SqlServer@2022";
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            //string query = "select id as emp_id, name as emp_name, salary as emp_sal from employeerecords";
            string query = "GetRecords";
            HashSet<Employee> employees = null;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {                    
                    //Console.WriteLine(connection.State.ToString());
                    command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            employees = new HashSet<Employee>();
                            while (reader.Read())
                            {
                                employees.Add(
                                    new Employee
                                    {
                                        Id = int.Parse(reader["emp_id"].ToString()),
                                        Name = reader["emp_name"].ToString(),
                                        Salary = decimal.Parse(reader["emp_sal"].ToString())
                                    }
                                    );
                            }
                            reader.Close();
                        }
                    }
                }
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    //Console.WriteLine(connection.State.ToString());
                }
            }
        }
        static int Insert(Employee employee)
        {
            string connectionString = @"server=joydip-pc\sqlexpress;database=testdb;user id=sa;password=SqlServer@2022";
            //string query = "insert into employeerecords(name,salary) values(@name,@salary)";
            string query = "AddRecord";
            SqlConnection? connection = null;
            SqlCommand? command = null;
            int res = 0;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    command = connection.CreateCommand();
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@salary", employee.Salary);

                    connection.Open();
                    res = command.ExecuteNonQuery();
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void Main()
        {
            int res = Insert(new Employee("mahesh", 4000));
            Console.WriteLine(res==0?"no record added":$"{res} record added");
            var employees = FetchData();
            employees.ToList<Employee>().ForEach(e => { Console.WriteLine(e); });
        }
    }
}
