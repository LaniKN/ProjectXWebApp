using System.ComponentModel.DataAnnotations;


namespace SchedulingWebApp.Data.Model{
    public class CourseViewModel
    {        

        public List<Course>? Courses {get; set;}
        public Course? Course {get; set;}

        public bool Taken {get; set;}

        public Major? Major {get; set;}
    }
}

