using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using SchedulingWebApp.Data.Model;
using SchedulingWebApp.Controllers.API;
using Dapper;

namespace SchedulingWebApp.Pages.Home;

public class IndexModel(ILogger<IndexModel> logger, DatabaseAPI databaseAPI) : PageModel
{

    private readonly ILogger<IndexModel> _logger = logger;
	private readonly DatabaseAPI _api = databaseAPI;

    private readonly static List<Course> courses = new List<Course>();
    private readonly static List<Major> majors = new List<Major>();

    private static ViewModel model = new ViewModel { };


    public void OnGet() 
    {

    }

    public PartialViewResult OnGetCoursesPartial() {


        return new PartialViewResult
        {
            ViewName = "_CoursesPartial",
            ViewData = new ViewDataDictionary<ViewModel>(ViewData, model)
        };
    }

	public PartialViewResult OnGetMajorsPartial() {
        

        return new PartialViewResult
        {
            ViewName = "_MajorsPartial",
            ViewData = new ViewDataDictionary<ViewModel>(ViewData, model)
        };
    }

    
}