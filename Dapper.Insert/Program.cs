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

        Wallet insertWallet = new()
        {
            Holder = "sarah",
            Balance = 10000m,
        };
        var sql = "INSERT INTO WALLETS (Holder , Balance) VALUES (@Holder , @Balance)";


        db.Execute(sql,
            new
            {
                insertWallet.Holder,
                insertWallet.Balance,
            });

    }
}