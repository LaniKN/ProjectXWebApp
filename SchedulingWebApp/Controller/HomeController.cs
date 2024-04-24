using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SchedulingWebApp.Data.Model;
using SchedulingWebApp.Pages.Shared;

namespace SchedulingWebApp.Controller;


// public class IndexModel(ILogger<IndexModel> logger, DatabaseController databaseController) : PageModel
public class HomeController() : PageModel
{
    // private readonly ILogger<IndexModel> _logger = logger;
    // private readonly DatabaseController _databaseController = databaseController;

	public PartialViewResult OnGetCoursesModalPartial()
	{
		//Returns _CoursesPartial
		return new PartialViewResult
		{
			ViewName="_CoursesPartial",
			ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, new CourseViewModel { })
		};
	}
}

    
    


