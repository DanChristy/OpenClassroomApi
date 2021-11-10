using Microsoft.EntityFrameworkCore;
using OpenClassroomApi.BusinessManagers;
using OpenClassroomApi.BusinessManagers.Interfaces;
using OpenClassroomApi.Data;
using OpenClassroomApi.Data.Services;
using OpenClassroomApi.Data.Services.Interfaces;

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

        public static void AddCustomServices(this IServiceCollection services) {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISchoolBusinessManager, SchoolBusinessManager>();
        }
    }
}