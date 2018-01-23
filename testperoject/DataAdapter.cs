using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.Sqlite;
using testperoject.Models;

namespace testperoject
{
    public class DataAdapter
    {

        private static string Connection = "Data Source =" + AppDomain.CurrentDomain.BaseDirectory + "Clients.db;";


        public static bool HasClient(Client c)
        {
            using (var conn = new SqliteConnection(Connection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT Account FROM Client WHERE FirstName == @FIRSTNAME AND LastName == @LASTNAME";
                cmd.Parameters.Add(new SqliteParameter("@FIRSTNAME", c.FirstName));
                cmd.Parameters.Add(new SqliteParameter("@LASTNAME", c.LastName));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return true;             
                }

                return false;
            }
        }

        public static void AddClient(Client c)
        {
            using (var conn = new SqliteConnection(Connection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Client(FirstName,LastName,DOB,Account) Values(@FIRSTNAME, @LASTNAME, @DOB, @ACCOUNT)";
                cmd.Parameters.Add(new SqliteParameter("@FIRSTNAME", c.FirstName ));
                cmd.Parameters.Add(new SqliteParameter("@LASTNAME", c.LastName));
                cmd.Parameters.Add(new SqliteParameter("@DOB", c.DOB));
                cmd.Parameters.Add(new SqliteParameter("@ACCOUNT", c.Account));
                cmd.ExecuteReader();
            }
        }



        public static void UpdateClient(Client c)
        {
            using (var conn = new SqliteConnection(Connection))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "UPDATE Client SET Account = @ACCOUNT WHERE FirstName == @FIRSTNAME AND LastName == @LASTNAME";
                cmd.Parameters.Add(new SqliteParameter("@FIRSTNAME", c.FirstName));
                cmd.Parameters.Add(new SqliteParameter("@LASTNAME", c.LastName));
                cmd.Parameters.Add(new SqliteParameter("@ACCOUNT", c.Account));
                cmd.ExecuteReader();
            }
        }
    }
}