using DataAccess;
using Hellang.Middleware.ProblemDetails;
using Logic;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Reflection;
using WebApp.Helpers;

//create new WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);

//adding services to container
builder.Services.AddRazorPages(); //Razor Pages
builder.Services.AddControllers(); //WebAPI

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<DeckSerivce>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<CardImageService>();

builder.Services.AddScoped<CardLogic>();

builder.Services.AddScoped<FileHelper>();
builder.Services.AddScoped<TextHelper>();

builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DeckSerivce)));
builder.Services.AddProblemDetails(options =>
{
    options.IsProblem = httpContext => new ProblemDetailsMiddlewareHelper().IsProblem(httpContext);
});

//create new WebApplication
var app = builder.Build();

//adding middlewares to WebApplication
app.UseStatusCodePagesWithReExecute(WebApp.Pages.Error.StatusCodeModel.AbsolutePath, "?statusCode={0}");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(WebApp.Pages.Error.ExceptionModel.AbsolutePath);
    app.UseProblemDetails();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//Endpoint middlewars
app.MapRazorPages(); //Razor Pages endpoints
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //MVC endpoints
app.MapControllers(); //WebAPI endpoints

//run WebApplication
app.Run();
