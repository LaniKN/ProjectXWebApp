using System.Data;

namespace SchedulingWebApp.Controller.Interface;

public interface DatabaseConnection {
	public IDbConnection CreateConnection();
}