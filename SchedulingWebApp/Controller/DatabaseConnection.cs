using System.Data;
using Microsoft.Data.Sqlite;

namespace SchedulingWebApp.Controller.Connection;

public class DatabaseConnection {
	private const string BasePath = "../SqliteDB/database";
	protected IDbConnection CreateConnection() {
		return new SqliteConnection($"Data Source={BasePath}/courses.db");
	}
}