var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("DatabaseAppDb"));

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddSwaggerGen(options =>
     {
         options.SwaggerDoc("v1", new OpenApiInfo
         {
             Description = "WebServer API v1",
             Title = "WebServer API",
             Version = "1.0"
         });
     });

     var app = builder.Build();

// Configure the HTTP request pipeline. 
app.MapCarter();

app.UseExceptionHandler(options => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebServer API V1");
        c.RoutePrefix = string.Empty;
    });

    await app.InitialiseDatabaseAsync();
}

app.Run();
