namespace API.Config;

public static class ControllersExtension
{

    public static void AddControllers(this WebApplication app)
    {

        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                "{controller}/{action}/{id?}"
            );

            endpoints.MapControllerRoute(
                name: "areas",
                "{area}/{controller}/{action}/{id?}"
            );
            // endpoints.MapControllers();
        });
    }
}