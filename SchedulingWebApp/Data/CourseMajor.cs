using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesDB.model
{
	public class CourseMajor {
		public string? CourseCode { get; set; }
		public string? PreCoreq {get; set;}
        public string? PreCourseCode {get; set;}
	}
}