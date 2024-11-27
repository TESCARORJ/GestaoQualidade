namespace Nuclep.GestaoQualidade.API.Extensions
{
    public static class CorsConfigExtension
    {
        public static IServiceCollection AddCorsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = configuration.GetSection("CorsConfigSettings:Origins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("ApplicationPolicy", builder =>
                {
                    builder.WithOrigins(origins)
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("ApplicationPolicy");

            return app;
        }
    }

}
