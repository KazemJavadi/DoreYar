using DataAccess;
using Hellang.Middleware.ProblemDetails;
using Logic;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Reflection;
using WebApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); //Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); //WebAPI

builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}, ServiceLifetime.Scoped); //DbContext 

builder.Services.AddScoped<DeckSerivce>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<CardImageService>();
builder.Services.AddScoped<CardLogic>();

builder.Services.AddScoped<FileHelper>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DeckSerivce)));
builder.Services.AddProblemDetails(options =>
{
    options.IsProblem = httpContext => new ProblemDetailsMiddlewareHelper().IsProblem(httpContext);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
