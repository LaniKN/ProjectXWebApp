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

    private readonly static List<Course> course = new List<Course>();
    //private readonly static List<Major> majors = new List<Major>();

    private static List<Major> major = new List<Major>();

//put saved model with major picked
    private static ViewModel viewModel = new ViewModel();

    public void fillNewMajorModel() {
        foreach(Major elem in _api.getCachedMajors()) {
            major.Add(elem);
        }
    }

    public void fillCoursesList(Major major) {
        List<int> courseIds = _api.FetchCoursesFromMajor(major.Id);

        foreach (int elem in courseIds){
            course.Add(_api.FetchCourse(elem));
        }
    }


    public void OnGet() 
    {

    }

    public PartialViewResult OnGetCoursesPartial() {
        return new PartialViewResult
        {
            ViewName = "_CoursesPartial",
            ViewData = new ViewDataDictionary<List<Course>>(ViewData, course)
        };
    }

	public PartialViewResult OnGetMajorsPartial() {
        fillNewMajorModel();
        return new PartialViewResult
        {
            ViewName = "_MajorsPartial",
            ViewData = new ViewDataDictionary<List<Major>>(ViewData, major)
        };
    }
    

    public void OnGetSubmitMajor(Major model) {
        Console.WriteLine("In get submit major");
        fillCoursesList(model);
    }
    
}