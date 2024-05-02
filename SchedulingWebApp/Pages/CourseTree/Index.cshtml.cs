using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchedulingWebApp.Controller.API;
using SchedulingWebApp.Data.Model;

namespace SchedulingWebApp.Pages.CourseTree;

public class IndexModel(ILogger<IndexModel> logger, DatabaseAPI databaseAPI) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;
	private readonly DatabaseAPI _api = databaseAPI;
	
	public Course returnCourse(int courseID) {
		return _api.FetchCourse(courseID) ?? new Course();
	}

	// possible way to use async functions;
	public string returnMajorTest() {
		var test = _api.getMajorsAsync();
		test.Wait();
		_api.FetchReqs("BME3200");
		return (test.Result)[1];
	}
	public void OnGet()
    {

    }
}
