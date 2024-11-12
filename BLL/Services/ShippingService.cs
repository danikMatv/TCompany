using BLL.IServices;
using DTO.Entity;
using System.Data.SqlClient;


namespace BLL.Services
{
    public class ShippingService : IShippingSevice
    {
        private readonly SqlConnection _connection;

        public ShippingService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public List<Shipping> GetAllByStatus(string status)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, start_adress, destination, goods_id, status, destination_date FROM shipping WHERE status = @Status";
                command.Parameters.AddWithValue("@Status", status);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var shippings = new List<Shipping>();
                while (reader.Read())
                {
                    shippings.Add(new Shipping
                    {
                        id = Convert.ToInt32(reader["id"]),
                        start_adress = reader["start_adress"].ToString(),
                        destination = reader["destination"].ToString(),
                        goods_id = Convert.ToInt32(reader["goods_id"]),
                        status = reader["status"].ToString(),
                        destination_date = Convert.ToDateTime(reader["destination_date"])
                    });
                }

                _connection.Close();
                return shippings;
            }
        }
        public Shipping GetById(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, start_adress, destination, goods_id, status, destination_date FROM shipping WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var shipping = new Shipping
                    {
                        id = Convert.ToInt32(reader["id"]),
                        start_adress = reader["start_adress"].ToString(),
                        destination = reader["destination"].ToString(),
                        goods_id = Convert.ToInt32(reader["goods_id"]),
                        status = reader["status"].ToString(),
                        destination_date = Convert.ToDateTime(reader["destination_date"])
                    };

                    _connection.Close();
                    return shipping;
                }

                _connection.Close();
                return null;
            }
        }
    }
}
