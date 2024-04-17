//no use

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
using SchedulingWebApp.Controller.Interface;
using Microsoft.Data.Sqlite;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
using SchedulingWebApp.Data.Model;
using System.Text.Json;
using System.Data.SqlTypes;
namespace SchedulingWebApp.Controller.DapperDbConnection;

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
	// Depreciated
	 public class DataContext: DatabaseConnection {
        public readonly IConfiguration Configuration;
        private readonly string _testFile = "../SqliteDB/database/table_info/courseData.js";
		  private readonly string _tableLocation;
       
		 public DataContext() {}
		 
		  public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection("Data Source=../SqliteDB/database/courses.db");
        }
        public void insertAll(IDbConnection connection) {
				
				connection.Execute("DELETE FROM Course");
            var json = File.ReadAllText(_testFile);
				try {
            	var data = JsonSerializer.Deserialize<List<Course>>(json);
					connection.BulkInsert(data);


				} catch (JsonException e) {
					Console.WriteLine("Invalid Course: {0} \n halting additions",e.Message);
					
				} catch (SqliteException e) {
					Console.WriteLine("SQL Rules violatd: {0}", e.Message);
				};
        }

    

        public void Init()
        {
            using (var connection = CreateConnection())
            {
               InitTables(connection);
					insertAll(connection);
            }
        }

        private void InitTables(IDbConnection connection)
        {
            var createPairsTableSql = @"
                CREATE TABLE IF NOT EXISTS Pairs (
                    MajorName TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
                );
			
            ";
            connection.Execute(createPairsTableSql);
        }
       
        private void InsertPair(IDbConnection connection, string MajorName, int CourseID)
        {
            string insertQuery = @"
                INSERT INTO Pairs (MajorName, CourseID)
                VALUES (" + MajorName + ", " + CourseID + @");
            ";


            int rowsAffected = connection.Execute(insertQuery, new { MajorName = MajorName, CourseID = CourseID });

            if (rowsAffected > 0)
            {
                Console.WriteLine("Pair inserted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to insert pair.");
            }
        }

        public void UpdatePair(IDbConnection connection, string MajorName, int CourseID)
        {
            string updateQuery = @"
                UPDATE Pairs 
                SET MajorName = @MajorName,
                    CourseID = @CourseID
                WHERE CourseId = @CourseId
            ";

            int rowsAffected = connection.Execute(updateQuery, new { MajorName = MajorName, CourseID = CourseID });

            if (rowsAffected > 0)
            {
                Console.WriteLine("Pair updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update pair.");
            } 
        }

        public void DeletePair(IDbConnection connection, string MajorName, int CourseID)
        {
            string deleteQuery = @"
                DELETE FROM Pairs 
                WHERE CourseID = @CourseID ;
            ";

            int rowsAffected = connection.Execute(deleteQuery, new { CourseID = CourseID });

            if (rowsAffected > 0)
            {
                Console.WriteLine("Pair Deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Delete pair.");
            } 
        }
    }

