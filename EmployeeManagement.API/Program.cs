using EmployeeManagementLibrary.Data;
using MediatR;

namespace EmployeeManagement.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

		
			builder.Services.AddControllers();

			// Add MediatR and data access services

			builder.Services.AddSingleton<IDataAccess, DataAccess>();
			builder.Services.AddMediatR(typeof(DataAccess).Assembly);

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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
	}
}