using System.Data;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.WebEncoders.Testing;

namespace SchedulingWebApp.Controller.Interface;

public interface DatabaseConnection
{

	public IDbConnection CreateConnection();
}