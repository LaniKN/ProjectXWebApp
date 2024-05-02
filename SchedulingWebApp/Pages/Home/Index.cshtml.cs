using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using SchedulingWebApp.Data.Model;

namespace SchedulingWebApp.Pages.Home;

public class IndexModel : PageModel
{
    private readonly static List<CourseViewModel> Courses = new List<CourseViewModel>();
    private readonly static List<Major> Majors = new List<Major>();

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
