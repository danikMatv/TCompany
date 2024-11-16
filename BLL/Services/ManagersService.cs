using BLL.IServices;
using DAL.Repository;
using DTO.Entity;
using System.Data.SqlClient;


namespace BLL.Services
{
    public class ManagersService : IManagersService
    {
        private readonly IManagers managers;
        private readonly SqlConnection _connection;

        public ManagersService(IManagers managers)
        {
            //_connection = new SqlConnection(connectionString);
            this.managers = managers;
        }

        public Managers GetById(int id)
        {
            return managers.GetById(id);
        }

        //public Managers login(string username, string password)
        //{
        //    using (SqlCommand command = _connection.CreateCommand())
        //    {
        //        command.CommandText = "SELECT id, first_name, last_name, phone_number, email, password " +
        //                              "FROM managers WHERE email = @Email AND password = @Password";
        //        command.Parameters.AddWithValue("@Email", username);
        //        command.Parameters.AddWithValue("@Password", password);

        //        _connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            var manager = new Managers
        //            {
        //                id = Convert.ToInt32(reader["id"]),
        //                first_Name = reader["first_name"].ToString(),
        //                last_Name = reader["last_name"].ToString(),
        //                phone_Number = reader["phone_number"].ToString(),
        //                email = reader["email"].ToString(),
        //                password = reader["password"].ToString()
        //            };

        //            _connection.Close();
        //            return manager;
        //        }

        //        _connection.Close();
        //        return null;
        //    }
        //}
    }
}
