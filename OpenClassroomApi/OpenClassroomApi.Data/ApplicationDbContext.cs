using Microsoft.EntityFrameworkCore;
using OpenClassroomApi.Data.Models;

namespace OpenClassroomApi.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<School> Schools { get; set; }
    }
}