using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}, ServiceLifetime.Scoped);
builder.Services.AddScoped<DeckSerivce, DeckSerivce>();
builder.Services.AddScoped<CardService, CardService>();
builder.Services.AddScoped<AppDbContext, AppDbContext>();   

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseStatusCodePagesWithReExecute("/Error/StatusCode/{0}");
app.UseStatusCodePagesWithReExecute("/Error/StatusCode", "?statusCode={0}");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Exception");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
