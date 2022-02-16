namespace WebApp.Helpers.Services
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddMyAppServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages(); //Razor Pages
            builder.Services.AddControllers(); //WebAPI

            builder.Services.AddDatabaseLayer(builder);
            builder.Services.AddServiceLayer();
            builder.Services.AddLogicLayer();
            builder.Services.AddHelpers();
            builder.Services.AddOtherService();

            return builder;
        }

       
    }
}
