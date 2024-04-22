using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchedulingWebApp.Controller.BaseClass;
using SchedulingWebApp.Data.Model;

namespace SchedulingWebApp.Pages.CourseTree;

public class IndexModel(ILogger<IndexModel> logger, DatabaseController databaseController) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;
	private readonly DatabaseController _databaseController = databaseController;
	public void OnGet()
    {

    }
}
