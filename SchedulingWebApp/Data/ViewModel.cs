
namespace SchedulingWebApp.Data.Model{
    public class ViewModel
    {        
        public int courseId {get; set;}
        public List<Course>? courses {get; set;}

        public bool taken {get; set;}

        public int majorId {get; set;}

        // public List<Major> majors {get; set;}
    }
}

