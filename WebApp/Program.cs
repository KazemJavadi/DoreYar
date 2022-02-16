using WebApp.Helpers.Services;

//create new WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);

//adding services to container
builder.AddMyAppServices();

//create new WebApplication
var app = builder.Build();

//adding middlewares to WebApplication
app.UseMyAppMiddlewares();

//run WebApplication
app.Run();
