
namespace SchedulingWebApp.Data.Model{
    public class ViewModel
    {        
        public int courseId {get; set;}
        public string? CourseName {get; set;}
        public string? CourseCode {get; set;}
        public List<Course>? courses {get; set;}
        public List<int> courseIds {get; set;}

        public bool taken {get; set;}

        public int majorId {get; set;}

    }
}

