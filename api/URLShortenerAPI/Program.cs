using repository;
using service;
using System.Text;
using model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

string MyCustomPolicy = "CustomPolicy";

var builder = WebApplication.CreateBuilder(args);

#region configuration setup
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", optional: false);
builder.Configuration.AddEnvironmentVariables();
#endregion

// Configuring services
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyCustomPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

#region helpers
void ConfigureServices(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy(name: MyCustomPolicy,
            policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
    });

    services.AddRouting(options => options.LowercaseUrls = true);

    services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Dependency injections
    services.AddSingleton<IDatabaseContext, DatabaseContext>();
    services.AddTransient<IURLService, URLService>();
}
#endregion