using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesDB.model
{
	public class Course
	{
		public int CourseOID { get; set; }
		public string CourseCode { get; set; }
		public string? CourseName { get; set; }
		public string? PreReqs { get; set; }
		public string? Description {get; set;}
		public int Credits {get; set;}
		public string StudenLearningOUtcomes {get; set;}
		// don't use Outcome. Use Outcome# for now
		public List<string> Outcome = new List<string>();
		//use these instead
		public string? Outcome1 {get; set;}
		public string? Outcome2 {get; set;}
		public string? Outcome3 {get; set;}
		public string? Outcome4 {get; set;}
		public string? Outcome5 {get; set;}
		public string? Outcome6 {get; set;}
		public string? Outcome7 {get; set;}
		public string? Outcome8 {get; set;}
		public string? Outcome9 {get; set;}
		public string? Outcome10 {get; set;}
		public string? Outcome11 {get; set;}
		public string? Outcome12 {get; set;}
		public string? Outcome13 {get; set;}
		public string? Outcome14 {get; set;}
		public string? Outcome15 {get; set;}
		public string? Outcome16 {get; set;}
		public string? Outcome17 {get; set;}
		public string? Outcome18 {get; set;}
		public string? Outcome19 {get; set;}
		public string? Outcome20 {get; set;}
		public bool isActive {get; set;}
		public string? DegreeUsage {get; set;}
	}
}