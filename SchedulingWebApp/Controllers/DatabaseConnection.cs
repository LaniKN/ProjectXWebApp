using System.Data;
using Microsoft.Data.Sqlite;

namespace SchedulingWebApp.Controllers.Connection;

public class DatabaseConnection {
	private const string BasePath = "../SqliteDB/database";
	protected IDbConnection CreateConnection() {
		return new SqliteConnection($"Data Source={BasePath}/courses.db");
	}
}