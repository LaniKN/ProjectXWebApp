using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulingWebApp.Data.model;

	public class Course
	{
		public int CourseOID { get; set; }
		public string? CourseCode { get; set; }
		public string? Name { get; set; }
		public string? PreReqs { get; set; }

		
	}
