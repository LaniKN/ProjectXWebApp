using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchedulingWebApp.Controller.BaseClass;
using SchedulingWebApp.Data.Model;

namespace SchedulingWebApp.Pages.CourseTree;

public class IndexModel(ILogger<IndexModel> logger, DatabaseController databaseController) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;
	private readonly DatabaseController _databaseController = databaseController;
	public async Task<Course> GetThing() {
		var thing  =  _databaseController.RetunObjectSingle<Course>(@"
		SELECT *
		FROM Course
		WHERE CourseID ='24850';
		");

		return await thing;
		
	}
	public int GetThingId(Course course) {
		return course.CourseID;
	}
	public void OnGet()
    {

    }
}
}
