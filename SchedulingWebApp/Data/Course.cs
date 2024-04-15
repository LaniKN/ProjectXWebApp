
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;


namespace SchedulingWebApp.Data.Model;
	public class Course
	{
	
		[JsonPropertyName("CourseOID:")] [JsonRequired]
		public int CourseID { get; set; }
		[JsonPropertyName("CourseCode:")]
		public string CourseCode { get; set; }
		[JsonPropertyName("Name:")]
		public string? Name { get; set; }
		[JsonPropertyName("PreReqs:")]
		public string? PreReqs { get; set; }
		[JsonPropertyName("CoReqs:")]
		public string CoReqs { get; set; }
		[JsonPropertyName("PreCoReqs:")]
		public string PreCoReqs { get; set; }
		[JsonPropertyName("Description:")]
		public string Description { get; set; }
		[JsonPropertyName("Credits:")]
		public string Credits { get; set; }
		[JsonPropertyName("StudentLearningOutcomes:")]
		public string StudenLearningOutcomes {get; set;}
		// don't use Outcome. Use Outcome# for now
		public List<string> Outcome = new List<string>();
		//use these instead
		[JsonPropertyName("Outomce1:")]
		public string? Outcome1 {get; set;}
		[JsonPropertyName("Outomce2:")]
		public string? Outcome2 {get; set;}
		[JsonPropertyName("Outomce3:")]
		public string? Outcome3 {get; set;}
		[JsonPropertyName("Outomce4:")]
		public string? Outcome4 {get; set;}
		[JsonPropertyName("Outomce5:")]
		public string? Outcome5 {get; set;}
		[JsonPropertyName("Outomce6:")]
		public string? Outcome6 {get; set;}
		[JsonPropertyName("Outomce7:")]
		public string? Outcome7 {get; set;}
		[JsonPropertyName("Outomce8:")]
		public string? Outcome8 {get; set;}
		[JsonPropertyName("Outomce9:")]
		public string? Outcome9 {get; set;}
		[JsonPropertyName("Outomce10:")]
		public string? Outcome10 {get; set;}
		[JsonPropertyName("Outomce11:")]
		public string? Outcome11 {get; set;}
		[JsonPropertyName("Outomce12:")]
		public string? Outcome12 {get; set;}
		[JsonPropertyName("Outomce13:")]
		public string? Outcome13 {get; set;}
		[JsonPropertyName("Outomce14:")]
		public string? Outcome14 {get; set;}
		[JsonPropertyName("Outomce15:")]
		public string? Outcome15 {get; set;}
		[JsonPropertyName("Outomce16:")]
		public string? Outcome16 {get; set;}
		[JsonPropertyName("Outomce17:")]
		public string? Outcome17 {get; set;}
		[JsonPropertyName("Outomce18:")]
		public string? Outcome18 {get; set;}
		[JsonPropertyName("Outomce19:")]
		public string? Outcome19 {get; set;}
		[JsonPropertyName("Outomce20:")]
		public string? Outcome20 {get; set;}
		[JsonPropertyName("isActive:")]
		public bool isActive {get; set;}
		[JsonPropertyName("DegreeUsage:")]
		public string? DegreeUsage {get; set;}
		
	}
