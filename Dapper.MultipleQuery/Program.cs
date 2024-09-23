using Dapper;
using Dapper.SelectAll;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

class Program
{

    public static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        IDbConnection db = new SqlConnection(configuration.GetSection("ConnectionString").Value);

        var sql = "SELECT MIN(Balance) FROM Wallets;" +
                   "SELECT MAX(Balance) FROM Wallets;";

        var multi = db.QueryMultiple(sql);




        Console.WriteLine(
          @$"Min = {multi.Read<decimal>().Single()} 
          Max = {multi.Read<decimal>().Single()}");

     
    }
}
