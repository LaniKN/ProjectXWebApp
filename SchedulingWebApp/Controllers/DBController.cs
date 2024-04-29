using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text.Json;
using Dapper;
using Microsoft.Data.Sqlite;
using SchedulingWebApp.Controllers.Connection;
using SchedulingWebApp.Data.Model;
using Z.Dapper.Plus;

// TODO: provide more functions for finer database control
namespace SchedulingWebApp.Controllers.Database;

public class DBController : DatabaseConnection {
	private const string BasePath = "../SqliteDB/database/table_info";
	private readonly IDbConnection _connection;

	public DBController() {
		_connection = CreateConnection();
	}

	private string ReadInFile(string filename) => 
	File.ReadAllText($"{BasePath}/{filename}");

	private List<T> ReadJSON<T>(string JSONinput) {
		return JsonSerializer.Deserialize<List<T>>(JSONinput) ?? new List<T>();
	}

	private string BulkToJSON<T>(List<T> test)	{
		return JsonSerializer.Serialize<List<T>>(test);
	}

	private void InsertBulk<T>(List<T> inputList) {
		 _connection.BulkInsert<T>(inputList);
		Console.WriteLine($"modified table {typeof(T).ToString()}");
	}

	// TODO: figure out why ClearTable is throwing sql error 1

	private void ClearTable(string tableName) {
		var num = _connection.Execute($@"
		DELETE FROM @tablename;
		",new {tablename = tableName});
		Console.WriteLine($"{num.ToString()} rows modified in table {num.GetType()}");
	}
	private async Task ClearTableAsync(string table) {
		var num = await _connection.ExecuteAsync(@"DELETE FROM @table", new {table });
		Console.WriteLine($"{num.ToString()} rows modified in table {num.GetType()}");
	}
	// TODO: remove once you figure out why ClearTable(string) isn't working
	private void ClearAllTables() {
		var num = _connection.Execute("DELETE FROM Course");
		var num2 = _connection.Execute("DELETE FROM Major");

		Console.WriteLine($"{num} rows deleted from Table Course");
		Console.WriteLine($"{num2} rows deleted from Table Major");
	}


	private async Task TablesExist() {
		var majorTable = createMajorTable();
		var courseTable = createCourseTable();
		var coursematchTable = createCourseMatchTable();
		var pairsTable = createPairsTable();
		var prereqsTable = createPreReqsTable();

		var tasksInProgress = new List<Task> {majorTable, courseTable, coursematchTable, pairsTable, prereqsTable};
		await Task.WhenAll(tasksInProgress);
	}


	private async Task createMajorTable() {
		var sql = @"
				CREATE TABLE IF NOT EXISTS 
				Major (
					Id INT(7) PRIMARY KEY,
   		 		Major VARCHAR(64) NOT NULL
					);
            ";
			await _connection.ExecuteAsync(sql);
	}
	private async Task createCourseTable() {
		var sql = @"
				CREATE TABLE IF NOT EXISTS 
				Course (
					CourseID INT(10) PRIMARY KEY,
					CourseCode VARCHAR(10) UNIQUE NOT NULL,
					CourseName VARCHAR(30),
					PreReq VARCHAR(30),
					CoReq VARCHAR(30),
					PreCoReqs VARCHAR(30),
					CourseDescription VARCHAR(200),
					Credits INT(1),
					StudentLearningOutcomes VARCHAR(500),
					Outcome1 VARCHAR(500),
					Outcome2 VARCHAR(500),
					Outcome3 VARCHAR(500),
					Outcome4 VARCHAR(500),
					Outcome5 VARCHAR(500),
					Outcome6 VARCHAR(500),
					Outcome7 VARCHAR(500),
					Outcome8 VARCHAR(500),
					Outcome9 VARCHAR(500),
					Outcome10 VARCHAR(500),
					Outcome11 VARCHAR(500),
					Outcome12 VARCHAR(500),
					Outcome13 VARCHAR(500),
					Outcome14 VARCHAR(500),
					Outcome15 VARCHAR(500),
					Outcome16 VARCHAR(500),
					Outcome17 VARCHAR(500),
					Outcome18 VARCHAR(500),
					Outcome19 VARCHAR(500),
					Outcome20 VARCHAR(500),
					IsActive BIT,
					DegreeUsage VARCHAR(100)
					);
            ";
			await _connection.ExecuteAsync(sql);
	}
	private async Task createCourseMatchTable() {
		var sql = @"
				CREATE TABLE IF NOT EXISTS 
				CourseMatch (
    				CourseCode VARCHAR(10),
    				PreCoreq VARCHAR(50) NOT NULL,
    				CourseID INT(10),
    				FOREIGN KEY (CourseCode) REFERENCES Course(CourseCode),
    				FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    				PRIMARY KEY (CourseCode, PreCoreq, CourseID)
					);
            ";
			await _connection.ExecuteAsync(sql);
	}
	private async Task createPairsTable() {
		var sql = @"
				CREATE TABLE IF NOT EXISTS 
				Pairs (
					MajorID INT(7) NOT NULL,
					CourseID INT(10),
					FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
					);	
            ";
			await _connection.ExecuteAsync(sql);
	}	
	
		private async Task createPreReqsTable() {
		var sql = @"
				CREATE TABLE IF NOT EXISTS 
				Prerequisites (
   	 			PreCourseCode VARCHAR(10),
					PreCoreq VARCHAR(50) NOT NULL,
    				PRIMARY KEY (PreCourseCode)
					);
            ";
			await _connection.ExecuteAsync(sql);
	}	
	
	public async Task onInitialize() {
		var settingUp = TablesExist();
		var courseJson = ReadJSON<Course>(ReadInFile("courseData.js"));
		var majorJson = ReadJSON<Major>(ReadInFile("majorData.js"));
		await settingUp.ContinueWith((finishSetup) => {
		try {
			ClearAllTables();
			InsertBulk<Course>(courseJson);
			InsertBulk<Major>(majorJson);
		} catch (SqliteException e) {
			if(e.SqliteErrorCode != 19) {
				throw new Exception($"Unhandled Exception! {e.Message}");
			} else {
				Console.WriteLine($@"Non-Fatal Exception Caught! SQL code 19: SQL constraint violation.");
			}
		}
		});
		

		
	}

};