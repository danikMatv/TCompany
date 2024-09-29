using DAL.Repository;
using DTO.Entity;
using System.Data.SqlClient;

namespace DAL.Repo
{
    public class EmployeesDal : IEmployees
    {
        private readonly SqlConnection _connection;

        public EmployeesDal(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public Employees Create(Employees employee)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO employees (first_name, last_name, phone_number, position, email,password) " +
                                      "VALUES (@FirstName, @LastName, @PhoneNumber, @Position, @Email,@password); " +
                                      "SELECT SCOPE_IDENTITY();";

                command.Parameters.AddWithValue("@FirstName", employee.first_Name);
                command.Parameters.AddWithValue("@LastName", employee.last_Name);
                command.Parameters.AddWithValue("@PhoneNumber", employee.phone_Number);
                command.Parameters.AddWithValue("@Position", employee.position);
                command.Parameters.AddWithValue("@Email", employee.email);
                command.Parameters.AddWithValue("@password", employee.password);

                _connection.Open();
                employee.id = Convert.ToInt32(command.ExecuteScalar());
                _connection.Close();

                return employee;
            }
        }

        public Employees Delete(int id)
        {
            Employees deletedEmployee = GetById(id);
            if (deletedEmployee == null)
                return null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM employees WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

            return deletedEmployee;
        }

        public List<Employees> GetAll()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, first_name, last_name, phone_number, position, email ,password FROM employees";

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var employees = new List<Employees>();
                while (reader.Read())
                {
                    employees.Add(new Employees
                    {
                        id = Convert.ToInt32(reader["id"]),
                        first_Name = reader["first_name"].ToString(),
                        last_Name = reader["last_name"].ToString(),
                        phone_Number = reader["phone_number"].ToString(),
                        position = reader["position"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString()
                    });
                }

                _connection.Close();
                return employees;
            }
        }

        public Employees GetById(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, first_name, last_name, phone_number, position, email,password " +
                                      "FROM employees WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var employee = new Employees
                    {
                        id = Convert.ToInt32(reader["id"]),
                        first_Name = reader["first_name"].ToString(),
                        last_Name = reader["last_name"].ToString(),
                        phone_Number = reader["phone_number"].ToString(),
                        position = reader["position"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString()
                    };

                    _connection.Close();
                    return employee;
                }

                _connection.Close();
                return null;
            }
        }

        public Employees login(string username, string password)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, first_name, last_name, phone_number, position, email, password " +
                                      "FROM employees WHERE email = @Email AND password = @Password";
                command.Parameters.AddWithValue("@Email", username);
                command.Parameters.AddWithValue("@Password", password);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var employee = new Employees
                    {
                        id = Convert.ToInt32(reader["id"]),
                        first_Name = reader["first_name"].ToString(),
                        last_Name = reader["last_name"].ToString(),
                        phone_Number = reader["phone_number"].ToString(),
                        position = reader["position"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString()
                    };

                    _connection.Close();
                    return employee;
                }

                _connection.Close();
                return null;
            }
        }


        public Employees Update(int id, Employees employee)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE employees SET first_name = @FirstName, last_name = @LastName, " +
                                      "phone_number = @PhoneNumber, position = @Position, email = @Email, password = @password " +
                                      "WHERE id = @Id";

                command.Parameters.AddWithValue("@FirstName", employee.first_Name);
                command.Parameters.AddWithValue("@LastName", employee.last_Name);
                command.Parameters.AddWithValue("@PhoneNumber", employee.phone_Number);
                command.Parameters.AddWithValue("@Position", employee.position);
                command.Parameters.AddWithValue("@Email", employee.email);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@password", employee.password);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

                return GetById(id);
            }
        }
    }
}
