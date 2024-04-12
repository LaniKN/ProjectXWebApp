using System.Data;

namespace SchedulingWebApp.Controller.Interfaces
{
    public interface HomeController
    {
        public IDbConnection CreateConnection();
    }
}