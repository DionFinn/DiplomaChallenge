using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Classes;
using DatabaseHandlers;


namespace Backend.DatabaseHandlers
{
    public class OrderHandler : DatabaseHandler
    {
       

        public static IEnumerable<Order> GetOrderProduct()
        {
            List<Order> OrderList = new List<Order>();
            var conn = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
            using (SqlConnection Connection = new SqlConnection(conn))
            {
                Connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM [Order];", Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ProdID = reader.GetString(3);
                            Product prod = new Product();
                            prod.ProdID = ProdID;
                            var connii = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
                            using (SqlConnection Connectionii = new SqlConnection(connii))
                            {
                                Connectionii.Open();
                                using (SqlCommand Comandii = new SqlCommand($"SELECT * FROM Product WHERE ProdID = '{ProdID}';", Connectionii))
                                {
                                    using (SqlDataReader Readerii = Comandii.ExecuteReader())
                                    {
                                        while (Readerii.Read())
                                        {
                                            prod.CatID = Readerii.GetInt32(1);
                                            prod.Description = Readerii.GetString(2);
                                            prod.UnitPrice = Readerii.GetInt32(3);
                                            
                                        }
                                    }
                                }
                            }
                            OrderList.Add(new Order()
                            {
                                OrderDate = reader.GetString(0),
                                CustID = reader.GetString(1),
                                ShipMode = reader.GetString(2),
                                Quantity = reader.GetInt32(4),
                                ShipDate = reader.GetString(5),
                                Prod = prod
                            });
                        }
                    }
                }

            }
            return OrderList;
        }
        

        public static float Total(Order order)
        {
            return order.Total(order.Quantity, (float)order.Prod.UnitPrice);
        }

        public static float GST(Order order)
        {
            return order.GST(order.Quantity, (float)order.Prod.UnitPrice);
        }

        
        public static int PutOrder(Order order)
        {
            var conn = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
            using (SqlConnection Connection = new SqlConnection(conn))
            {
                Connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO [Order] VALUES (@OrderDate, @CustID, @ShipMode, @ProdID, @Qty, @ShipDate )", Connection))
                {
                    
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@CustID", order.CustID);
                    command.Parameters.AddWithValue("@ShipMode", order.ShipMode);
                    command.Parameters.AddWithValue("@ProdID", order.Prod.ProdID);
                    command.Parameters.AddWithValue("@Qty", order.Quantity);
                    command.Parameters.AddWithValue("@ShipDate", order.ShipDate);
 
                    int rowsAffected = command.ExecuteNonQuery();
                    Connection.Close();
                    return rowsAffected;
                }
   
            }

        }

        public static string OrderPost(Order order)
        {
           var conn = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
            using (SqlConnection Connection = new SqlConnection(conn))
            {
                Connection.Open();
                using (SqlCommand Command = new SqlCommand("OrderPost", Connection))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@postOrderDate", order.OrderDate);
                    Command.Parameters.AddWithValue("@postCustID", order.CustID);
                    Command.Parameters.AddWithValue("@postShipMode", order.ShipMode);
                    Command.Parameters.AddWithValue("@postQuantity", order.Quantity);
                    Command.Parameters.AddWithValue("@postShipDate", order.ShipDate);

                    int counter = Command.ExecuteNonQuery();
                    Connection.Close();
                    if (counter >= 1)
                    {
                        return "post successful";
                    }
                    else{
                        return "failed";
                    }
                }
            }
        }

          public static int DeleteOrder(Order order)
        {
            var conn = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
            using (SqlConnection Connection = new SqlConnection(conn))
            {
                Connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM [ORDER] WHERE OrderDate = @OrderDate AND ProdID = @ProdID AND CustID = @CustID", Connection))
                {
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@ProdID", order.Prod.ProdID);
                    command.Parameters.AddWithValue("@CustID", order.CustID);

                    int rowsAffected = command.ExecuteNonQuery();
                    Connection.Close();
                    return rowsAffected;
                }
            }
        }
    }
}
