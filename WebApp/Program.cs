using DataAccess;
using DataAccess.Entities;
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

builder.Host.UseDefaultServiceProvider((context, options) =>
{
    bool isDevEnv = context.HostingEnvironment.IsDevelopment();
    //Will validate scopes in all environments
    options.ValidateScopes = isDevEnv;
    //Checks that every registered service has all its dependencies regitered
    options.ValidateOnBuild = isDevEnv;
});


builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<DeckSerivce>()
    .AddScoped<CardService>()
    .AddScoped<CardImageService>()
    .AddScoped<CardLogic>();

builder.Services.AddScoped<FileHelper>()
    .AddScoped<TextHelper>();

builder.Services.AddEndpointsApiExplorer() //Swagger
    .AddSwaggerGen(); //Swagger

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
