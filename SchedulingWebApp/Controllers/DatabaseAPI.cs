using System.Data;
using System.Text.Json;
using Dapper;
using SchedulingWebApp.Controllers.Connection;
using SchedulingWebApp.Data.Model;

namespace SchedulingWebApp.Controllers.API;
// if we swap to a dedicated SQL database, Async will apparently be more useful.
// however as it stands, pulling from the SQLite db doesn't work that well async.
public class DatabaseAPI : DatabaseConnection {
	private readonly IDbConnection _connection;
	// CHECK: do we need to cache majors from the sqlite database?
	//private readonly Dictionary<int,string> _majorsCache;

	public DatabaseAPI() {
		_connection = CreateConnection();
		//_majorsCache = getMajorsAsync().Result;
	}

	public string toJSON<T>(List<T> input) {
		return JsonSerializer.Serialize<List<T>>(input);
	}
	// using a dictionary due to value key-pair which allows for faster lookup using the key
	public async Task<Dictionary<int,string>> getMajorsAsync() {
		Dictionary<int,String> output = (await _connection.QueryAsync<Major>(@"
		SELECT *
		FROM Major")).ToDictionary(row => (int)row.Id,
											row => (string)row.major);
		return output;
	}

	// TODO: Finish the Fetch functions
	public Course FetchCourse(int courseID) =>
		_connection.QueryFirst<Course>(@"SELECT * FROM Course WHERE CourseID = @courseID;", new {courseID = courseID});
	public Course FetchCourse(string courseCode) =>
		_connection.QueryFirst<Course>(@"SELECT * FROM Course WHERE CourseCode = @courseCode;", new {courseCode = courseCode});
	
	public Prerequisites FetchPrereqs(string PreCode) =>
		_connection.QueryFirst<Prerequisites>(@"SELECT * FROM Prerequisites WHERE PreCourseCode = @PreCode;", new {PreCode = PreCode});

	

	
	// TODO: keep researching async/await usage
	// WARNING: don't use getCourseAsync atm. you won't get any info out of the table
	// use getCourse instead
	public async Task<Course> getCourseAsync(int courseID) => 
		await _connection.QueryFirstAsync<Course>(@"
		SELECT *
		FROM Course
		WHERE CourseID = @courseID", new {courseID = courseID});

	public async Task<Course> getCourseAsync(string courseCode) =>
		await _connection.QueryFirstAsync<Course>(@"
		SELECT *
		FROM Course
		WHERE CourseCode = @courseCode", new {courseCode = courseCode});

	[Obsolete("getEntrySQLAsync is unsecure, use Fetch{Table} or Fetch{Table}Async in production code")]
	public async Task<T> getEntrySQLAsync<T>(string sqlStatement) =>
		await _connection.QueryFirstAsync<T>(sqlStatement);

	[Obsolete("Experimental Function. Please do not use")]
	public Course FetchEntry(int courseID) {
		var sqlString = $@"
		SELECT *
		FROM Course
		WHERE";
		return _connection.QueryFirst<Course>(sqlString);
	}
}
