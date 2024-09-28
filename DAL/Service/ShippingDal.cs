using DAL.Repository;
using DTO.Entity;
using System.Data.SqlClient;

namespace DAL.Service
{
    public class ShippingDal : IShipping
    {
        private readonly SqlConnection _connection;

        public ShippingDal(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public Shipping Create(Shipping shipping)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO shipping (start_adress, destination,goods_id) " +
                                      "VALUES (@StartAdress, @Destination,@goods_id); " +
                                      "SELECT SCOPE_IDENTITY();";

                command.Parameters.AddWithValue("@StartAdress", shipping.start_adress);
                command.Parameters.AddWithValue("@Destination", shipping.destination);
                command.Parameters.AddWithValue("@Destination", shipping.goods_id);

                _connection.Open();
                shipping.id = Convert.ToInt32(command.ExecuteScalar());
                _connection.Close();

                return shipping;
            }
        }

        public Shipping Delete(int id)
        {
            Shipping deletedShipping = GetById(id);
            if (deletedShipping == null)
                return null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM shipping WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

            return deletedShipping;
        }

        public List<Shipping> GetAll()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, start_adress,goods_id, destination FROM shipping";

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
                        goods_id = Convert.ToInt32(reader["goods_id"])
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
                command.CommandText = "SELECT id, start_adress, destination,goods_id FROM shipping WHERE id = @Id";
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
                        goods_id = Convert.ToInt32(reader["goods_id"])
                    };

                    _connection.Close();
                    return shipping;
                }

                _connection.Close();
                return null;
            }
        }

        public Shipping Update(int id, Shipping shipping)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE shipping SET start_adress = @StartAdress,goods_id = @goods_id, destination = @Destination " +
                                      "WHERE id = @Id";

                command.Parameters.AddWithValue("@StartAdress", shipping.start_adress);
                command.Parameters.AddWithValue("@goods_id", shipping.goods_id);
                command.Parameters.AddWithValue("@Destination", shipping.destination);
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

                return GetById(id);
            }
        }
    }
}
