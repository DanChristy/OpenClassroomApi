using Microsoft.EntityFrameworkCore;
using OpenClassroomApi.Data;

namespace OpenClassroomApi.Configuration {
    public static class AppServices {
        public static void AddDefaultServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(nameof(OpenClassroomApi))
            ));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}