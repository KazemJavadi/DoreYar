using Hellang.Middleware.ProblemDetails;

namespace WebApp.Helpers.Services
{
    public static class WebApplicationExtensions
    {
        public static void UseMyAppMiddlewares(this WebApplication app)
        {
            app.UseStatusCodePagesWithReExecute(Pages.Error.StatusCodeModel.AbsolutePath, "?statusCode={0}");

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(Pages.Error.ExceptionModel.AbsolutePath);
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

        }
    }
}
