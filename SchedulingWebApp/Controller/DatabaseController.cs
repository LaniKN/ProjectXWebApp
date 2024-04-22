using System.ComponentModel;
using System.Data;
using System.Text.Json;
using Dapper;
using Microsoft.Data.Sqlite;
using SchedulingWebApp.Controller.Interface;
using SchedulingWebApp.Data.Model;
using Z.Dapper.Plus;


namespace SchedulingWebApp.Controller.BaseClass;

public class DatabaseController : DatabaseConnection {

	private const string BasePath = "../SqliteDB/database";
	private readonly IDbConnection _connection;
	
	public DatabaseController() {

		_connection = CreateConnection();
		
		}

	// used to create a default connection to the database
	// change this function should it be switched to a nonlocal database
	public IDbConnection CreateConnection() {
		return new SqliteConnection($"Data Source={BasePath}/courses.db");
	}


	// likely will be depreciated at somepoint.
	// depends on if we need it or not
	// may also look at simplifying it further
	public string ReturnJSON(Course course)	{
		return JsonSerializer.Serialize<Course>(course);
	}

	public string ReturnJSON(CourseMatch coursematches)	{
		return JsonSerializer.Serialize<CourseMatch>(coursematches);
	}

	public string ReturnJSON(Major majors)	{
		return JsonSerializer.Serialize<Major>(majors);
	}

	public string ReturnJSON(Pairs pairs)	{
		return JsonSerializer.Serialize<Pairs>(pairs);
	}

	public string ReturnJSON(Prerequisites prerequisites)	{
		return JsonSerializer.Serialize<Prerequisites>(prerequisites);
	}


	//used to convert from a json file into a list of objects T
	public List<T> GetFromJSON<T>(string path) {
		var fileJson = File.ReadAllText($"{BasePath}{path}");
		return JsonSerializer.Deserialize<List<T>>(fileJson)
		?? new List<T>();
	}


	// keep using this for now till I figure out a better way
	public async Task<T> RetunObjectSingle<T>(string sqlString) =>
		await _connection.QuerySingleAsync<T>(sqlString);


	//functions that insert and delete will likely be made private in the future to avoid bad actors messing with the database

	[Description("Deletes all entries from a specified table")]
	private void DeleteTableEntries(string tableName) {
		var count = _connection.Execute(@"
		DELETE FROM @tablename;
		",new {tablename = tableName});
		Console.WriteLine($"{count.ToString()} lines delete from {tableName}");
	}
	// TODO: possibly replace with overloaded function for fine tuned deletes
	[Description("Deletes entries from a table where the specified parameter is equal to provided value")]
	private void DeleteSingleEntry(string tableName, string queryParam, string queryValue) {
		var count = _connection.Execute(@"
		DELETE FROM @tablename
		WHERE @queryparam = @queryvalue", new {
			tablename = tableName,
			queryparam = queryParam,
			queryvalue = queryValue
		});
		Console.WriteLine($"{count.ToString()} entry(s) deleted");
	}
	// WARNING: this should only be called in Initialize to clear current entries so we can apply new ones.
	// Do not try using this anywhere else. I'm too lazy to make sure exceptions aren't thrown for duplicate entries atm.
	// TODO: exception handle for duplicate entries
	[Description("if you're reading this you're probably not supposed to be using this")]
	private void ClearTables() {
		var rac = _connection.Execute("DELETE FROM Course");
		var racm = _connection.Execute("DELETE FROM CourseMatch;");
		var ram = _connection.Execute("DELETE FROM Major");
		var rap = _connection.Execute("DELETE FROM Pairs");
		var rapr = _connection.Execute("DELETE FROM Prerequisites");


		Console.WriteLine($@"Cleartables Function ran. Deleted: 
		 {rac.ToString()} entries from table: Course
		 {racm.ToString()} entries from table: CourseMatch
		 {ram.ToString()} entries from table: Major
		 {rap.ToString()} entries from table: Pairs
		 {rapr.ToString()} entries from table: Prereqs
		");

	}
	// TODO: verify these should be private, then make them so


	public void InsertBulk(List<Course> courses) {
		var count = _connection.BulkInsert(courses);
		Console.WriteLine($"Bulk inserted {count.ToString()} into table Courses");
	}

	public void InsertBulk(List<CourseMatch> courseMatches) {
		var count = _connection.BulkInsert(courseMatches);
		Console.WriteLine($"Bulk inserted {count.ToString()} into table CourseMatch");
	}

	public void InsertBulk(List<Major> majors) {
		var count = _connection.BulkInsert(majors);
		Console.WriteLine($"Bulk inserted {count.ToString()} into table Major");
	}

	public void InsertBulk(List<Pairs> pairs) {
		var count = _connection.BulkInsert(pairs);
		Console.WriteLine($"Bulk inserted {count.ToString()} into table Pairs");
	}

	public void InsertBulk(List<Prerequisites> prereqs) {
		var count = _connection.BulkInsert(prereqs);
		Console.WriteLine($"Bulk inserted {count.ToString()} into table Prerequisites");
	}

	//called in Program.cs to read in the Json scripts to populate table
	// should this turn into an sql this could likely be removed
	public void Initialize() {
		ClearTables();
		InsertBulk(GetFromJSON<Course>("/table_info/courseData.js"));
		InsertBulk(GetFromJSON<Major>("/table_info/majorData.js"));
	}


}
