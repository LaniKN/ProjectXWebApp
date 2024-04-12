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
using SchedulingWebApp.Controller.Interfaces;
using Microsoft.Data.Sqlite;

namespace SchedulingWebApp.Controller.DapperDbConnection;
    public class DataContext : HomeController
    {
        public readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection("Data Source = Courses.db");
        }

        public void Init(string[] MajorName, int[] CourseID)
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
       
        private void InsertPair(IDbConnection connection, string[] MajorName, int[] CourseID)
        {
            string insertQuery = @"
                INSERT INTO Pairs (MajorName, CourseID)
                VALUES (@MajorName, @CourseID);
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

        public void UpdatePair(IDbConnection connection, string[] MajorName, int[] CourseID)
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

        public void DeletePair(IDbConnection connection, string[] MajorName, int[] CourseID)
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

