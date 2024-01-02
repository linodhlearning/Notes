using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Api.Model;
using Notes.Api.Repository.Entities;

namespace Notes.Api.Utils
{
    public static class Extensions
    {
        public static ObjectResult HandleException(this Exception e, string? errorMessage = null)
        {
            var message = string.IsNullOrWhiteSpace(errorMessage) ? e.Message : errorMessage;

            return new ErrorResult(
                StatusCodes.Status500InternalServerError,
                new
                {
                    Status = StatusCodes.Status500InternalServerError,
                    message,
                    Data = new { UserData = e.Data, e.Message, e.StackTrace }
                });
        }

        public static IApplicationBuilder DbMigrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<NotesDBContext>();
            dbContext.Database.EnsureCreated(); 
            //context.Database.EnsureDeleted();
            //context.Database.Migrate();  
            return app;
        }
    }
}
