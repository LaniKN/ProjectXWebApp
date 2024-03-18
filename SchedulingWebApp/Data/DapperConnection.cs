using System.Data;

namespace CoursesDB.Interfaces
{
    public interface HomeController
    {
        public IDbConnection CreateConnection();
    }
}