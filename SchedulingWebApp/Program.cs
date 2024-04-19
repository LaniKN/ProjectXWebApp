using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using SchedulingWebApp.Controller.BaseClass;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>  {
        options.Conventions.AddPageRoute("/Home/Index", "");
		  
    });

builder.Services.AddScoped<DatabaseController>();
var app = builder.Build();

new DatabaseController().Initialize();

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
