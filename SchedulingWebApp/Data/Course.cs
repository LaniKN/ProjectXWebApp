using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace SchedulingWebApp.Data.Model;

	public class Course
	{
		[JsonPropertyName("CourseOID")]
		public int CourseOID { get; set; }
		[JsonPropertyName("CourseCode")]
		public string? CourseCode { get; set; }
		[JsonPropertyName("Name")]
		public string? Name { get; set; }
		[JsonPropertyName("PreReqs")]
		public string? PreReqs { get; set; }

		
	}
