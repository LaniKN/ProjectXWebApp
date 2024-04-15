using Dapper;
using Z.Dapper.Plus;
using Z.BulkOperations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using CoursesDB.Interfaces;
using Microsoft.Data.Sqlite;

namespace CorusesDB.DapperDbConnection{
    // public class HomeController {
    //     public ActionResult CourseTree(){
    // 		List<Courses> customers = new List<Courses>();
    // 		// using (IDbConnection db = new SqlConnection(FiddleHelper.GetConnectionStringSqlServer()))
    // 		// {
    //     	// 	customers = db.Query<Customer>("Select * From Customers").ToList();
    // 		// }
    // 		return View(customers);
    //     }
    // }

	 public class DataContext: HomeController {
        public readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection("Data Source = Courses.db");
        }


        public async Task Init(){
        // create database tables if they don't exist
        using var connection = CreateConnection();
        await _initUsers();

            async Task _initUsers(){
                var sql = """
                    /*SQL Goes Here*/
                """;
                await connection.ExecuteAsync(sql);
            }

        }

    }
}

