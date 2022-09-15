using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Classes;
using Microsoft.AspNetCore.Mvc;
using DatabaseHandlers;
namespace DatabaseHandlers
{
    public abstract class DatabaseHandler
    {
        public static string GetConnectionString()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ChallengeDB.mssql.somee.com";
                builder.UserID = "DionFinnerty_SQLLogin_2";
                builder.Password = "q7y2v767uo";
                builder.InitialCatalog = "workstation id=ChallengeDB.mssql.somee.com;packet size=4096;user id=DionFinnerty_SQLLogin_2;pwd=q7y2v767uo;data source=ChallengeDB.mssql.somee.com;persist security info=False;initial catalog=ChallengeDB; TrustServerCertificate = True;";

                return builder.ConnectionString;
            }
            catch (Exception exec)
            {
                throw new Exception("error in this function GetConnectionString() " + exec.Message);
            }
        }
    }
}