using ExpensesApi.Application.Mappers;
using ExpensesApi.Domain.Repositories;
using ExpensesApi.Infrastructure.Data;
using ExpensesApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Load Presentation layer assembly
        var presentationAssembly = typeof(ExpensesApi.Presentation.AssemblyReference).Assembly;
        services.AddControllers()
                .AddApplicationPart(presentationAssembly);

        // Register all AutoMapper profiles in this assembly
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();

        // Configure Swagger to include XML comments (if you have them)
        services.AddSwaggerGen(c =>
        {
            var presentationDocumentationFile = $"Presentation.xml";
            var presentationDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);
            c.IncludeXmlComments(presentationDocumentationFilePath);
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpensesApi", Version = "v1" });
        });
    }
}
