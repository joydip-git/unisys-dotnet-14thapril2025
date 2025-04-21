using DataAccessUsingADO;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, ADO");

Products()?.ForEach(p => Console.WriteLine(p.Name + "\t" + p.Id + "\t" + p.Price));

static List<Product>? Products()
{

    string constr = @"server=localhost\sqlexpress;database=unisysdb;user id=sa;password=sqlserver2024;TrustServerCertificate=true";

    string query = "select * from products";

    SqlConnection? connection = null;
    SqlCommand? cmd = null;
    SqlDataReader? reader = null;
    List<Product>? products = null;
    try
    {
        connection = new SqlConnection(constr);
        //cmd = new SqlCommand("select * from products", connection);
        cmd = connection.CreateCommand();
        cmd.CommandText = query;

        connection.Open();
        //to execute a INSERT, UPDATE, DELETE, CREATE, ALTER etc. query returning single value (number of rows affected etc.)
        //int result = cmd.ExecuteNonQuery();

        //to execute a SELECT query returning single value
        //object data = cmd.ExecuteScalar();

        //to execute a SELECT query returning multiple values
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            products = [];
            while (reader.Read())
            {
                Product product = new()
                {
                    Id = (int)reader["product_id"],
                    Name = (string)reader["product_name"],
                    Price = (decimal)reader.GetValue("product_price")
                };
                products.Add(product);
                //Console.Write(
                //    reader["product_id"]
                //    + "\t"
                //    + reader.GetString(1)
                //    + "\t"
                //    + reader.GetValue("product_price") + "\n");
            }
            reader.Close();
        }
        return products;
    }
    catch (SqlException)
    {
        throw;
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        connection?.Close();
    }

}
