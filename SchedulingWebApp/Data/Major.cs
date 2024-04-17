using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace SchedulingWebApp.Data.Model
{
	public class Major {
		[JsonPropertyName("Id")]
		public int Id {get; set;}
		[JsonPropertyName("MajorName")]
		public string? MajorName {get; set;}
	}
}