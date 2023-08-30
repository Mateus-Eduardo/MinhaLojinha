
using Microsoft.Extensions.Options; 
using LojinhaServer.Models;
using MongoDB.Driver;

namespace LojinhaServer.Extensions
{
    public static class ServiceExtensions
    {
        // Este método estende a funcionalidade de IServiceCollection para configurar políticas CORS.
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => {
                    builder .AllowAnyMethod()      // Permite qualquer método HTTP (GET, POST, etc.).
                            .AllowAnyHeader();     // Permite qualquer origem (domínio) fazer solicitações.
                    
                });
            });
        }

        // Este método estende a funcionalidade de IServiceCollection para configurar as configurações do MongoDB.
        public static void ConfigureMongoDBSettings(this IServiceCollection services, IConfiguration config)
        {
            // Configura as opções MongoDBSettings usando as configurações fornecidas no arquivo de configuração.
            services.Configure<MongoDBSettings>(config.GetSection("MongoDBSettings"));

            // Registra uma instância de IMongoDatabase como um serviço Singleton.
            services.AddSingleton<IMongoDatabase>(provider => {
                // Obtém as configurações do MongoDBSettings do arquivo de configuração.
                var settings = provider.GetRequiredService<IOptions<MongoDBSettings>>().Value;

                // Cria uma nova instância do MongoClient com base na string de conexão fornecida nas configurações.
                var client = new MongoClient(settings.ConnectionString);

                // Retorna uma referência para o banco de dados especificado nas configurações.
                return client.GetDatabase(settings.DatabaseName);
            });
        }
    }
}
