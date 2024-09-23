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

        Wallet walletToDelete = new()
        {
            Id = 4
        };
        var sql = "DELETE FROM WALLETS WHERE Id =@Id";
        db.Execute(sql,new { walletToDelete.Id });
    }
}