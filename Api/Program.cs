using MediatR;

namespace Api
{
	public class Pong { }
	public class Ping : IRequest<Pong>
	{

	}
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

			initializeMediatR(builder);

			var app = builder.Build();

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


		private void initializeMediatR(WebApplicationBuilder builder)
		{
			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(Ping).Assembly);
			});
		}


		public static void Main(string[] args)
		{
			new Program(args);
		}
	}
}