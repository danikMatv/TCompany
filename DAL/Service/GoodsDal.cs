using DAL.Repository;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Service
{
    public class GoodsDal : IGoods
    {
        private readonly SqlConnection _connection;

        public GoodsDal(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public Goods Create(Goods goods)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO goods (name, price, manager_id) " +
                                      "VALUES (@Name, @Price, @manager_id); " +
                                      "SELECT SCOPE_IDENTITY();";

                command.Parameters.AddWithValue("@Name", goods.name);
                command.Parameters.AddWithValue("@Price", goods.price);
                command.Parameters.AddWithValue("@manager_id", goods.manager_id);

                _connection.Open();
                goods.id = Convert.ToInt32(command.ExecuteScalar());
                _connection.Close();

                return goods;
            }
        }

        public Goods Delete(int id)
        {
            Goods deletedGoods = GetById(id);
            if (deletedGoods == null)
                return null;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM goods WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

            return deletedGoods;
        }

        public List<Goods> GetAll()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, price, manager_id FROM goods";

                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var goodsList = new List<Goods>();
                while (reader.Read())
                {
                    goodsList.Add(new Goods
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["name"].ToString(),
                        price = Convert.ToInt32(reader["price"]),
                        manager_id = Convert.ToInt32(reader["manager_id"])
                    });
                }

                _connection.Close();
                return goodsList;
            }
        }

        public Goods GetById(int id)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, price, manager_id " +
                                      "FROM goods WHERE id = @Id";
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

        public Goods Update(int id, Goods goods)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE goods SET name = @Name, price = @Price, manager_id = @MenegerId " +
                                      "WHERE id = @Id";

                command.Parameters.AddWithValue("@Name", goods.name);
                command.Parameters.AddWithValue("@Price", goods.price);
                command.Parameters.AddWithValue("@MenegerId", goods.manager_id);
                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

                return GetById(id); // Return upd goods
            }
        }
    }
}
