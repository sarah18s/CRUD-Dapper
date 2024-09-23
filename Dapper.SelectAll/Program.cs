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

        //open connection with database source
        IDbConnection db = new SqlConnection(configuration.GetSection("ConnectionString").Value);

        var sql = "SELECT * FROM WALLETS";

        Console.WriteLine("---------------- using Dynamic Query -------------");
        var resultAsDynamic = db.Query(sql);

        foreach (var item in resultAsDynamic)
        {

            Console.WriteLine(item);
        }

        Console.WriteLine("---------------- using Typed Query -------------");
        var resultAsTyped = db.Query<Wallet>(sql);

        foreach (var item in resultAsTyped)
        {

            Console.WriteLine(item);
        }

    }
}