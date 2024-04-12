using System.Configuration;
using System.Data;
using System.Text.Json;
using Dapper;
using Microsoft.Data.Sqlite;
using SchedulingWebApp.Controller.Interface;
using SchedulingWebApp.Data.Model;

namespace SchedulingWebApp.Controller.DapperConnection;

public class DapperConnection : DatabaseConnection {

	private readonly Configuration _configuration;
	private readonly string _testFile = "${workspaceFolder:ProjectXWebApp}/SqliteDB/database/table_info/courseData.js";
	public DapperConnection(Configuration config) {
		_configuration = config;
	}

	public IDbConnection CreateConnection() {
		return new SqliteConnection("Data Source = Courses.db");
	}	

}