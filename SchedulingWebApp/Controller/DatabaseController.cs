using System.Data;
using System.Text.Json;
using Dapper;
using Microsoft.Data.Sqlite;
using SchedulingWebApp.Controller.Interface;
using SchedulingWebApp.Data.Model;
using Z.Dapper.Plus;


namespace SchedulingWebApp.Controller.BaseClass;

public class DatabaseController : DatabaseConnection {

	private const string _dataPath = "../SqliteDB/database";
	private readonly IDbConnection _connection;
	
	public DatabaseController() {

		_connection = CreateConnection();
		
		}


	public IDbConnection CreateConnection() {
		return new SqliteConnection($"Data Source={_dataPath}/courses.db");
	}

	public List<T> JsonParser<T>(string path) {
		var fileJson = File.ReadAllText(path);
		return JsonSerializer.Deserialize<List<T>>(fileJson)
		?? new List<T>();
	}

	//Overloads for converting each object type into a json string
	//May be converted to something else

	public string ReturnJSON(Course course)	{
		return JsonSerializer.Serialize<Course>(course);
	}

	public string ReturnJSON(CourseMajor coursemajor)	{
		return JsonSerializer.Serialize<CourseMajor>(coursemajor);
	}

	public string ReturnJSON(Major major)	{
		return JsonSerializer.Serialize<Major>(major);
	}

	public string ReturnJSON(Pairs pairs)	{
		return JsonSerializer.Serialize<Pairs>(pairs);
	}

	public string ReturnJSON(Prerequisites prerequisites)	{
		return JsonSerializer.Serialize<Prerequisites>(prerequisites);
	}

	public async Task<T> RetunObjectSingle<T>(string sqlString) =>
		await _connection.QuerySingleAsync<T>(sqlString);


	public void InsertAll(List<Course> courses) {
		_connection.Execute("DELETE FROM COURSE");
		_connection.BulkInsert(courses);
	}

	public void InsertAll(List<Pairs> pairs) {
		_connection.BulkInsert(pairs);
	}

	public void InsertAll(List<Major> majors) {
		_connection.Execute("DELETE FROM MAJOR");
		_connection.BulkInsert(majors);
	}

	public void Initialize() {
		InsertAll(JsonParser<Course>($"{_dataPath}/table_info/courseData.js"));
		InsertAll(JsonParser<Major>($"{_dataPath}/table_info/majorData.js"));
	}


}
