using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Configuration;

namespace DatabazovyProjekt
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        public void InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "INSERT INTO Products (Nazev, Cena, Skladem, VyrobniDatum) VALUES (@Nazev, @Cena, @Skladem, @VyrobniDatum)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nazev", product.Nazev);
                    command.Parameters.AddWithValue("@Cena", product.Cena);
                    command.Parameters.AddWithValue("@Skladem", product.Skladem);
                    command.Parameters.AddWithValue("@VyrobniDatum", product.VyrobniDatum);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "SELECT ProductID, Nazev, Cena, Skladem, VyrobniDatum FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                //ProductID = reader.GetInt32(0),
                                Nazev = reader.GetString(1),
                                Cena = (float)reader.GetDouble(2), 
                                Skladem = reader.GetBoolean(3),
                                VyrobniDatum = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return products;
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "UPDATE Products SET Nazev = @Nazev, Cena = @Cena, Skladem = @Skladem, VyrobniDatum = @VyrobniDatum WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@Nazev", product.Nazev);
                    command.Parameters.AddWithValue("@Cena", product.Cena);
                    command.Parameters.AddWithValue("@Skladem", product.Skladem);
                    command.Parameters.AddWithValue("@VyrobniDatum", product.VyrobniDatum);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "DELETE FROM Products WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void ImportProductsFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var products = csv.GetRecords<Product>();
                foreach (var product in products)
                {
                    InsertProduct(product);
                }
            }
        }



        public void ImportCustomersFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var customers = csv.GetRecords<Customer>();
                foreach (var customer in customers)
                {
                    InsertCustomer(customer);
                }
            }
        }

        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "INSERT INTO Customers (Jmeno, Prijmeni, Email, RegistraceDatum) VALUES (@Jmeno, @Prijmeni, @Email, @RegistraceDatum)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Jmeno", customer.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", customer.Prijmeni);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@RegistraceDatum", customer.RegistraceDatum);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }





    }
}
