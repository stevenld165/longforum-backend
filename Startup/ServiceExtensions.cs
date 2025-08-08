namespace longforum_backend.Startup;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        // Add service initializations here
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:3000");
            });
        });

        // services.AddScoped<ISomethingService, SomethingSerivce>():
    }
}