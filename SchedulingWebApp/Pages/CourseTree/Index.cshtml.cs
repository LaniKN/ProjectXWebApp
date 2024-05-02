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
	public string returnCourseTest(int courseID) {
		return _api.FetchCourse(courseID).CourseCode ?? "";
	}
	// possible way to use async functions;
	public string returnMajorTest() {
		var test = _api.getMajorsAsync();
		test.Wait();
		return (test.Result)[3];
	}
	private readonly static List<CourseViewModel> Courses = new List<CourseViewModel>();

    public void OnGet() 
    {

    }

    public PartialViewResult OnGetCoursesPartial() {
        return new PartialViewResult
        {
            ViewName = "_CoursesPartial",
            ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, new CourseViewModel { })
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
