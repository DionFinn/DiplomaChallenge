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
    public class CustomerHandler : DatabaseHandler
    {
        public static List<Customer> GetCustomer()
        {
            List<Customer> CustomerList = new List<Customer>();
            var conn = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";
            using (SqlConnection Connection = new SqlConnection(conn))
            {
                try
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SELECT * FROM Customer", Connection))
                    {
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                CustomerList.Add(new Customer()
                                {
                                    CustID = Reader.GetString(0),
                                    FullName = Reader.GetString(1),
                                    SegID = Reader.GetInt32(2),
                                    Country = Reader.GetString(3),
                                    City = Reader.GetString(4),
                                    State = Reader.GetString(5),
                                    PostCode = Reader.GetInt32(6),
                                    Region = Reader.GetString(7)
                                });
                            }
                        }
                    }
                }
                catch (Exception excep)
                {
                    throw new Exception("Error in Customer Handler() " + excep.Message);
                }
                finally
                {
                    Connection.Close();
                }
                return CustomerList;
            }
        }
    }
}
