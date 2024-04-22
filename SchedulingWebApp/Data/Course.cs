
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
		[JsonPropertyName("CourseOID")] [JsonRequired]
		public int CourseID { get; set; }
		[JsonPropertyName("CourseCode")]
		public string CourseCode { get; set; }
		[JsonPropertyName("Name")]
		public string? CourseName { get; set; }
		[JsonPropertyName("PreReqs")]
		public string? PreReq { get; set; }
		[JsonPropertyName("CoReqs")]
		public string CoReq { get; set; }
		[JsonPropertyName("PreCoReqs")]
		public string PreCoReqs { get; set; }
		[JsonPropertyName("Description")]
		public string CourseDescription { get; set; }
		[JsonPropertyName("Credits")]
		public string Credits { get; set; }
		[JsonPropertyName("StudentLearningOutcomes")]
		public string StudentLearningOutcomes {get; set;}
		[JsonPropertyName("Outcome1")]
		public string? Outcome1 {get; set;}
		[JsonPropertyName("Outcome2")]
		public string? Outcome2 {get; set;}
		[JsonPropertyName("Outcome3")]
		public string? Outcome3 {get; set;}
		[JsonPropertyName("Outcome4")]
		public string? Outcome4 {get; set;}
		[JsonPropertyName("Outcome5")]
		public string? Outcome5 {get; set;}
		[JsonPropertyName("Outcome6")]
		public string? Outcome6 {get; set;}
		[JsonPropertyName("Outcome7")]
		public string? Outcome7 {get; set;}
		[JsonPropertyName("Outcome8")]
		public string? Outcome8 {get; set;}
		[JsonPropertyName("Outcome9")]
		public string? Outcome9 {get; set;}
		[JsonPropertyName("Outcome10")]
		public string? Outcome10 {get; set;}
		[JsonPropertyName("Outcome11")]
		public string? Outcome11 {get; set;}
		[JsonPropertyName("Outcome12")]
		public string? Outcome12 {get; set;}
		[JsonPropertyName("Outcome13")]
		public string? Outcome13 {get; set;}
		[JsonPropertyName("Outcome14")]
		public string? Outcome14 {get; set;}
		[JsonPropertyName("Outcome15")]
		public string? Outcome15 {get; set;}
		[JsonPropertyName("Outcome16")]
		public string? Outcome16 {get; set;}
		[JsonPropertyName("Outcome17")]
		public string? Outcome17 {get; set;}
		[JsonPropertyName("Outcome18")]
		public string? Outcome18 {get; set;}
		[JsonPropertyName("Outcome19")]
		public string? Outcome19 {get; set;}
		[JsonPropertyName("Outcome20")]
		public string? Outcome20 {get; set;}
		[JsonPropertyName("isActive")]
		public bool isActive {get; set;}
		[JsonPropertyName("DegreeProgramUsage")]
		public string? DegreeUsage {get; set;}
		
	}
