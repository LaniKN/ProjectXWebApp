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

	 public class DapperDbConnection: HomeController
    {
        public read-only string _connectionString;

        public DapperDbConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }

}

