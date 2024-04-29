using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using SchedulingWebApp.Controllers.API;
using SchedulingWebApp.Controllers.Database;

var builder = WebApplication.CreateBuilder(args);
Task noTouch = new DBController().onInitialize();



// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>  {
        options.Conventions.AddPageRoute("/Home/Index", "");
		  options.Conventions.AddPageRoute("/CourseTree/Index","/tree");
		  
    });

builder.Services.AddScoped<DatabaseAPI>();
var app = builder.Build();

await noTouch;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Run();
