namespace OpenClassroomApi.Configuration {
    public static class AppConfiguration {
        public static void AddDefaultConfiguration(this WebApplication webApplication) {
            if (webApplication.Environment.IsDevelopment()) {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }

            webApplication.UseHttpsRedirection();

            webApplication.UseAuthorization();

            webApplication.MapControllers();
        }
    }
}