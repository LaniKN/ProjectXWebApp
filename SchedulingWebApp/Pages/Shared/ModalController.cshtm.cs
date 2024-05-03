using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchedulingWebApp.Controllers.API;
using SchedulingWebApp.Data.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace SchedulingWebApp.Pages.Shared;

public class IndexModel(ILogger<IndexModel> logger, DatabaseAPI databaseAPI) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;
	private readonly DatabaseAPI _api = databaseAPI;
	
		
	public Course returnCourseWId(int courseID) {
		return _api.FetchCourse(courseID) ?? new Course();
	}
	public Course returnCourseWCode(string courseCode) {
		return _api.FetchCourse(courseCode) ?? new Course();
	}
	public List<List<string>> returnCourseReqs(string courseCode) {
		return _api.FetchReqs(courseCode);
	}

	public List<Major> returnMajors(){
		return _api.getCachedMajors();
	}

//will return a list of course IDs where the chosen major ID is matching on pairs table
	public  List<int> returningCourses(int mId){
		return _api.FetchCoursesFromMajor(mId);
	}
	
	// possible way to use async functions;
	public string returnMajorInfo(int id) {
		var test = _api.getMajorsAsync();
		test.Wait();
		return (test.Result)[id];
	}
	
}

