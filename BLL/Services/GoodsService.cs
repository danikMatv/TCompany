using BLL.IServices;
using DTO.Entity;
using System.Data.SqlClient;

namespace BLL.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly SqlConnection _connection;

        public GoodsService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public Goods GetById(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, price, manager_id FROM goods WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var goods = new Goods
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["name"].ToString(),
                        price = Convert.ToInt32(reader["price"]),
                        manager_id = Convert.ToInt32(reader["manager_id"])
                    };

                    _connection.Close();
                    return goods;
                }

                _connection.Close();
                return null;
            }
        }
    }
}
