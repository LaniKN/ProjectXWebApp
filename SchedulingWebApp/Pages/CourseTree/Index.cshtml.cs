using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchedulingWebApp.Controllers.API;
using SchedulingWebApp.Data.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace SchedulingWebApp.Pages.CourseTree;

public class IndexModel(ILogger<IndexModel> logger, DatabaseAPI databaseAPI) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;
	private readonly DatabaseAPI _api = databaseAPI;
		
	public Course returnCourse(int courseID) {
		return _api.FetchCourse(courseID) ?? new Course();
	}
	public Course returnCourse(string courseCode) {
		return _api.FetchCourse(courseCode) ?? new Course();
	}
	public List<List<string>> returnCourseReqs(string courseCode) {
		return _api.FetchReqs(courseCode);
	}

	

	// possible way to use async functions;
	public string returnMajorTest() {
		var test = _api.getMajorsAsync();
		test.Wait();
		_api.FetchReqs("BME3200");
		return (test.Result)[1];
	}

	//modal stuff below here
	// private readonly static List<ViewModel> courses = new List<ViewModel>();

    public void OnGet() 
    {

    }

    public PartialViewResult OnGetCoursesPartial() {
        return new PartialViewResult
        {
            ViewName = "_CoursesPartial",
            ViewData = new ViewDataDictionary<Course>(ViewData, new Course { })
        };
    }

	public PartialViewResult OnGetMajorsPartial() {
        return new PartialViewResult
        {
            ViewName = "_MajorsPartial",
            ViewData = new ViewDataDictionary<Major>(ViewData, new Major { })
        };
    }
}

