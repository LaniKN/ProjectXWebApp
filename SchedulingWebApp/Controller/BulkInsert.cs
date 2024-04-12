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

	 public class DataContext: DatabaseConnection {
        public readonly IConfiguration Configuration;
        private readonly FileStream fs = new FileStream("courseData.js", FileMode.Open);
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection("Data Source = Courses.db");
        }
        public void insertAll(IDbConnection connection) {
            var json = File.ReadAllText("courseData.js");
            var data = JsonSerializer.Deserialize<List<Course>>(json);
            if (data is null) {
                return;
            }
            foreach (Course course in data) {
                InsertCourse(connection, course);
            }
        }

        public void InsertCourse(IDbConnection connection, Course course) {
            string sqlString = $"INSERT INTO COURSE(CourseOID, CourseCode, Name, PreReqs) VALUES(${course.CourseOID},${course.CourseCode}, ${course.Name}, ${course.PreReqs})";
            
            // SqliteCommand command = new SqliteCommand(sqlString,connection)
            // check to finish up here. Josh sent you the "stuff"
            int rowsAffected = connection.Execute(sqlString, new { MajorName = MajorName, CourseID = CourseID });

            if (rowsAffected > 0)
            {
                Console.WriteLine("Pair inserted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to insert pair.");
            }
        }
    

        public void Init(string MajorName, int CourseID)
        {
            using (var connection = CreateConnection())
            {
                InitTables(connection);
                InsertPair(connection, MajorName, CourseID);
                UpdatePair(connection, MajorName, CourseID); 
                DeletePair(connection, MajorName, CourseID); 
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

