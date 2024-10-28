using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Service
{
    public class UsersDal
    {
        private readonly SqlConnection _connection;

        public UsersDal(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public Users Create(Users users)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO users (name, login, hashed_password, role) " +
                                      "VALUES (@name, @login, @hashed_password, @role); " +
                                      "SELECT SCOPE_IDENTITY();";

                command.Parameters.AddWithValue("@name", users.name);
                command.Parameters.AddWithValue("@login", users.login);
                command.Parameters.AddWithValue("@hashed_password", users.password);
                command.Parameters.AddWithValue("@role", users.role);

                _connection.Open();
                users.id = Convert.ToInt32(command.ExecuteScalar());
                _connection.Close();

                return users;
            }
        }

        public bool Delete(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM users WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                _connection.Close();

                return rowsAffected > 0;
            }
        }

        public List<Users> GetAll()
        {
            var usersList = new List<Users>();

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, login, hashed_password, role FROM users";

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var user = new Users
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["name"].ToString(),
                        login = reader["login"].ToString(),
                        password = reader["hashed_password"].ToString(),
                        role = reader["role"].ToString()
                    };
                    usersList.Add(user);
                }

                _connection.Close();
            }

            return usersList;
        }

        public Users GetById(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, login, hashed_password, role FROM users WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var user = new Users
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["name"].ToString(),
                        login = reader["login"].ToString(),
                        password = reader["hashed_password"].ToString(),
                        role = reader["role"].ToString()
                    };

                    _connection.Close();
                    return user;
                }

                _connection.Close();
                return null;
            }
        }

        public Users Update(int id, Users user)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE users SET name = @name, login = @login, " +
                                      "hashed_password = @hashed_password, role = @role WHERE id = @id";

                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@login", user.login);
                command.Parameters.AddWithValue("@hashed_password", user.password);
                command.Parameters.AddWithValue("@role", user.role);
                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                _connection.Close();

                if (rowsAffected > 0)
                {
                    return GetById(id);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
