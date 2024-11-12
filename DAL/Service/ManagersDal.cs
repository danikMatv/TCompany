using DAL.Repository;
using DTO.Entity;
using System.Data.SqlClient;

namespace DAL.Repo
{
    public class ManagersDal : IManagers
    {
        private readonly SqlConnection _connection;

        public ManagersDal(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public Managers Create(Managers manager)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO managers (first_name, last_name, phone_number, email,password) " +
                                      "VALUES (@FirstName, @LastName, @PhoneNumber, @Position, @Email,@password); " +
                                      "SELECT SCOPE_IDENTITY();";

                command.Parameters.AddWithValue("@FirstName", manager.first_Name);
                command.Parameters.AddWithValue("@LastName", manager.last_Name);
                command.Parameters.AddWithValue("@PhoneNumber", manager.phone_Number);
                command.Parameters.AddWithValue("@Email", manager.email);
                command.Parameters.AddWithValue("@password", manager.password);

                _connection.Open();
                manager.id = Convert.ToInt32(command.ExecuteScalar());
                _connection.Close();

                return manager;
            }
        }

        public Managers Delete(int id)
        {
            Managers deletedManager = GetById(id);
            if (deletedManager == null)
                return null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM managers WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

            return deletedManager;
        }

        public List<Managers> GetAll()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, first_name, last_name, phone_number, email ,password FROM managers";

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var managers = new List<Managers>();
                while (reader.Read())
                {
                    managers.Add(new Managers
                    {
                        id = Convert.ToInt32(reader["id"]),
                        first_Name = reader["first_name"].ToString(),
                        last_Name = reader["last_name"].ToString(),
                        phone_Number = reader["phone_number"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString()
                    });
                }

                _connection.Close();
                return managers;
            }
        }

        public Managers GetById(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, first_name, last_name, phone_number, email,password " +
                                      "FROM managers WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var manager = new Managers
                    {
                        id = Convert.ToInt32(reader["id"]),
                        first_Name = reader["first_name"].ToString(),
                        last_Name = reader["last_name"].ToString(),
                        phone_Number = reader["phone_number"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString()
                    };

                    _connection.Close();
                    return manager;
                }

                _connection.Close();
                return null;
            }
        }

        public Managers Update(int id, Managers manager)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE managers SET first_name = @FirstName, last_name = @LastName, " +
                                      "phone_number = @PhoneNumber, email = @Email, password = @password " +
                                      "WHERE id = @Id";

                command.Parameters.AddWithValue("@FirstName", manager.first_Name);
                command.Parameters.AddWithValue("@LastName", manager.last_Name);
                command.Parameters.AddWithValue("@PhoneNumber", manager.phone_Number);
                command.Parameters.AddWithValue("@Email", manager.email);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@password", manager.password);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

                return GetById(id);
            }
        }
    }
}
