using DataAccess.SqlLite;
using Logic;
using Microsoft.EntityFrameworkCore;

namespace Api
{
	public class Program
	{
		public Program(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.SetupApplication();
			builder.Services.SetupDataAccessSqlLite();

			var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlLiteDataContext>();
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}

		public static void Main(string[] args)
		{
			new Program(args);
		}
	}
}