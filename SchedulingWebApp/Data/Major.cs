using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace SchedulingWebApp.Data.Model
{
	public class Major {
		[JsonPropertyName("Major")]
		public string major {get; set;}
		[JsonPropertyName("ID")]
		public int Id {get; set;}
	}
}