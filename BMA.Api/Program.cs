using Microsoft.OpenApi.Models;
using BMA.Infrastructure.Extensions;
using BMA.Application.AutoMapper;
using BMA.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("auth", new OpenApiSecurityScheme
	{
		Name = "auth",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = "Bearer",
		Description = "A one time token. Call Login Api Using Username:admin & Password:admin123 "
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Id = "auth",
					Type = ReferenceType.SecurityScheme
				}
			}, new List<string>()
		}
			});
});


builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
