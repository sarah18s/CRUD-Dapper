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

        Wallet  walletToUpdate = new()
        {
            Id = 8,
            Holder = "Sarah",
            Balance = 9000m
        };

        var sql = "UPDATE WALLETS SET Holder = @Holder , Balance =@Balance Where Id = @Id";

        db.Execute(sql, new
        {
            Id = walletToUpdate.Id,
            Holder = walletToUpdate.Holder,
            Balance = walletToUpdate.Balance
        });


    }
}