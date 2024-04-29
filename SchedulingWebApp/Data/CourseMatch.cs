using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace SchedulingWebApp.Data.Model
{
	public class CourseMatch {
		public string? CourseCode { get; set; }
		public string? PreCoreq {get; set;}
      public string? CourseID {get; set;}
	}
}