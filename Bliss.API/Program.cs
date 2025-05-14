using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NRG3.Bliss.API.AppointmentManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.AppointmentManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.IAM.Application.Internal.CommandServices;
using NRG3.Bliss.API.IAM.Application.Internal.OutboundServices;
using NRG3.Bliss.API.IAM.Application.Internal.QueryServices;
using NRG3.Bliss.API.IAM.Domain.Services;
using NRG3.Bliss.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using NRG3.Bliss.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using NRG3.Bliss.API.IAM.Infrastructure.Tokens.Configuration;
using NRG3.Bliss.API.IAM.Infrastructure.Tokens.Services;
using NRG3.Bliss.API.ReviewManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ReviewManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.ReviewManagement.Domain.Repositories;
using NRG3.Bliss.API.ReviewManagement.Domain.Services;
using NRG3.Bliss.API.ReviewManagement.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Infrastructure.Persistence.EFC.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => 
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Connection string is null.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Bliss API",
            Version = "v1",
            Description = "Bliss API Documentation",
            TermsOfService = new Uri("https://nrg3-appweb.github.io/Landing-Page/"),
            Contact = new OpenApiContact
            {
                Name   = "NRG3",
                Email = "contact@nrg3.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url  = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.EnableAnnotations();
});


// Add services to the container.
builder.Services.AddControllers();

// Dependency Injection Configuration

// Shared Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Service Management Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceCommandService, ServiceCommandService>();
builder.Services.AddScoped<IServiceQueryService, ServiceQueryService>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
builder.Services.AddScoped<ICompanyCommandService, CompanyCommandService>();
builder.Services.AddScoped<ICompanyQueryService, CompanyQueryService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

// Review Management Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();

var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
