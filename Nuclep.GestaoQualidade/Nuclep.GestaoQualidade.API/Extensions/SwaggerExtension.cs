namespace Nuclep.GestaoQualidade.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do Swagger
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Método de extensão para configurações do Swagger na API
        /// </summary>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            // Configurações adicionais do Swagger/OpenAPI
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Gestão de Qualidade API",
                    Version = "v1",
                    Description = "API para gerenciamento dos indicadores do sertor de Gestão de Qualidade",
                });
            });

            return services;
        }

        /// <summary>
        /// Método de extensão para executar as configurações do Swagger na API
        /// </summary>
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestão de Qualidade API v1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Inicia o Swagger com os endpoints fechados
            });

            return app;
        }
    }
}
