using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;
using WebApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}, ServiceLifetime.Scoped);
builder.Services.AddScoped<DeckSerivce, DeckSerivce>();
builder.Services.AddScoped<CardService, CardService>();
builder.Services.AddScoped<AppDbContext, AppDbContext>();   
builder.Services.AddScoped<FileHelper, FileHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStatusCodePagesWithReExecute(/*"/Error/StatusCode"*/ WebApp.Pages.Error.StatusCodeModel.AbsolutePath, "?statusCode={0}");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(/*"/Error/Exception"*/ WebApp.Pages.Error.ExceptionModel.AbsolutePath);
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

//app.MapGet("/", () => "Hello world");
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();

//app.MapGet("/test/{name?}", (string name) => { return $"Hello {name}"; });
app.Run();
