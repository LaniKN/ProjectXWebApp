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

     private static List<Course>? courses = new List<Course>();
    private static List<Major> major = new List<Major>();
    public static List<int> codesInt = new List<int>();
	public static List<int> codesNeedInt = new List<int>();

//put saved model with major picked
    

    public void fillNewMajorModel() {
        foreach(Major elem in _api.getCachedMajors()) {
            if(!major.Contains(elem)){
                major.Add(elem);
            }
        }
    }

    public void fillCoursesList(int majorId) {
        List<int> courseIds = _api.FetchCoursesFromMajor(majorId);

        foreach (int elem in courseIds){
            if(!courses.Contains(_api.FetchCourse(elem))){
            courses.Add(_api.FetchCourse(elem));
            }
			if(!codesNeedInt.Contains(elem)) {
				codesNeedInt.Add(elem);
			}
        }
    }

	public List<int> getCourses(){
		foreach (int need in codesNeedInt) {
			foreach (int taken in codesInt) {
				if (need == taken) {
					codesNeedInt.Remove(taken);
				}
			}
		}
		return codesNeedInt;
	}


    public PartialViewResult OnGetCoursesPartial() {
        return new PartialViewResult
        {
            ViewName = "_CoursesPartial",
            ViewData = new ViewDataDictionary<List<Course>>(ViewData, courses),
        };
    }


	public PartialViewResult OnGetMajorsPartial() {
        major = new List<Major>();
        fillNewMajorModel();
        return new PartialViewResult
        {
            ViewName = "_MajorsPartial",
            ViewData = new ViewDataDictionary<List<Major>>(ViewData, major)
        };
    }
    
    
//make it a fucking cookie and find that in a cookie.
//2 am, May-8: didn't need a cookie :)

    public void OnPostSubmitMajor() {
        string id = Request.Form["major"];
        int major = Int32.Parse(id ?? "0");
        
        // _logger.LogInformation("In post submit major. " + major);
        // _logger.LogInformation("In post submit major. ID: " + id);
        courses = new List<Course>();
        fillCoursesList(major);
    }

    
    public void OnPostSubmitCourses() {
        string codeString = Request.Form["selected"];
        List<string> codesString = codeString.Split(new char[] { ',' }).ToList();
        _logger.LogInformation("In Post Courses " + codeString);
        _logger.LogInformation("List of codes " + codesString.Count());

        foreach (var code in codesString) {
            int codeInt = Int32.Parse(code ?? "0");
            codesInt.Add(codeInt);
        }
    }
}

