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

	public virtual List<T> JsonParser<T>(string path) {
		var fileJson = File.ReadAllText(path);
		return JsonSerializer.Deserialize<List<T>>(fileJson);
	}

	public void InsertAll(List<Course> courses) {
		_connection.BulkInsert(courses);
	}

	public void InsertAll(List<Pairs> pairs) {
		_connection.BulkInsert(pairs);
	}


}
