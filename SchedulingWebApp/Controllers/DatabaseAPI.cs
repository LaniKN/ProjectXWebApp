using System.Collections.Specialized;
using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;
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
	private readonly List<Major> _cachedmajors;
	private readonly HashSet<string> _courseCodeLookUP;

	public DatabaseAPI() {
		_connection = CreateConnection();
		_cachedmajors = FetchMajors();
		_courseCodeLookUP = _connection.Query<string>(@"SELECT CourseCode FROM Course").ToHashSet();
	}
	public List<Major> getCachedMajors(){
		return _cachedmajors;
	}

	public string toJSON<T>(List<T> input) {
		return JsonSerializer.Serialize<List<T>>(input);
	}

	private List<Major> FetchMajors() {
		return _connection.Query<Major>(@"
		SELECT *
		FROM Major").ToList();
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
	// TODO: maybe make FetchCourse into one function?
	
	public Course FetchCourse(int courseID) =>
		_connection.QueryFirst<Course>(@"SELECT * FROM Course WHERE CourseID = @courseID;", new {courseID = courseID});
	
	//TODO: figure out why this is fucked
	public Course FetchCourse(string courseCode) =>
		_connection.QueryFirst<Course>(@"SELECT * FROM Course WHERE CourseCode LIKE @courseCode;", new {courseCode = courseCode});
	public Course FetchReqsSpecial(string fuckedString) =>
		_connection.QueryFirst<Course>(@"SELECT * FROM Course WHERE CourseCode = @scrubbedString",new { scrubbedString = String.Concat(fuckedString.Where(char.IsLetterOrDigit))});
	
	// will use for coures modal
	public List<int> FetchCoursesFromMajor(int majorID) =>
	  _connection.Query<int>(@"SELECT CourseID FROM Pairs WHERE MajorID = @id", new {id = majorID}).ToList();


	public void fetchCoursePreReq(string courseCode) {

	}
	public void fetchCourseCoReq(string courseCode) {
		
	}
	public void fetchCoursePreCoReq(string courseCode) {

	}

	public List<List<string>> FetchReqs(string courseCode) {
		List<List<string>> RequirementsList = new List<List<string>>{
			// Prereqs
			new List<string>(),
			// Coreqs
			new List<string>(),
			// PreCoreqs
			new List<string>()
		};
		Course incomingCourse = FetchCourse(courseCode);

		_courseCodeLookUP.Where(m => 
			incomingCourse.PreReq != null 
			? incomingCourse.PreReq.Contains(m): false).ToList().ForEach(t=> RequirementsList[0].Add(t));
		_courseCodeLookUP.Where(m => 
			incomingCourse.CoReq != null 
			? Regex.Replace(incomingCourse.CoReq, @"\s", string.Empty).Contains(m) : false).ToList().ForEach(t => RequirementsList[1].Add(t));
		_courseCodeLookUP.Where(m => 
			incomingCourse.PreCoReqs != null 
			? Regex.Replace(incomingCourse.PreCoReqs, @"\s", string.Empty).Contains(m) : false).ToList().ForEach(t => RequirementsList[2].Add(t));
		return RequirementsList;
	}
	public string FetchPreReqString(string courseCode) {
		Course incomingCourse = FetchCourse(courseCode);
		return incomingCourse.PreReq ?? "";
	}



	
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
