using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SchedulingWebApp.Data.Model;
using SchedulingWebApp.Pages.Shared;
using SchedulingWebApp.Controllers.API;
using SchedulingWebApp.Controllers.Database;

namespace SchedulingWebApp.Controllers;


// public class ModelController(ILogger<IndexModel> logger, DatabaseController databaseController) : PageModel
public class ModalController(ILogger<ModalController> logger, DatabaseAPI databaseAPI) : Controller
{
    private readonly ILogger<ModalController> _logger = logger;
    private readonly DatabaseAPI _api = databaseAPI;


//something to ask on monday, can we hold off the creation of the Courses model? can we load the Courses model with data after we receive major selection?

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult CoursesPopUp()
	{
		return PartialView("CoursesModal");
		//return View();
	}

/*
	public JsonResult returnCourseTest() {
		List<int> testCourses = new List<int>{24874,24873,24975};
		return Json(testCourses);
		// return _api.FetchCourse(courseID).CourseCode ?? "";
		//in the end the return should be JsonResult, and it should connect to API that provides a List of courses
		//based on users selection of major and the pairs result. return Json(courses);
	}

	[HttpPost]
	public JsonResult OpenCoursesModalPartial(Course model)
	{

		if (ModelState.IsValid)
		{

		}
		else
		{
			return Json("Model validation failed");
		}

		// //Returns _CoursesPartial
		// return new PartialViewResult
		// {
		// 	ViewName="_CoursesPartial",
		// 	//ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, new CourseViewModel { })
		// };
	}
	*/
}

    
    


