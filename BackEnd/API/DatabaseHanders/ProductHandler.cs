using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Classes;
using Microsoft.AspNetCore.Mvc;
using DatabaseHandlers;

namespace Backend.DatabaseHandlers
{
    public class ProductHandler : DatabaseHandler
    {
        public static List<Product> GetProduct()
        {
            List<Product> ProductList = new List<Product>();
            var conn = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
            using (SqlConnection Connection = new SqlConnection(conn))
            {
                try
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SELECT * FROM Product", Connection))
                    {
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                ProductList.Add(new Product()
                                {
                                    ProdID = Reader.GetString(0),
                                    CatID = Reader.GetInt32(1),
                                    Description = Reader.GetString(2),
                                    UnitPrice = Reader.GetInt32(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception excep)
                {
                    throw new Exception("Error in Product Handler() " + excep.Message);
                }
                finally
                {
                    Connection.Close();
                }
                return ProductList;
            }
        }
    }
}
  