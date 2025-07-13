using WebApi_CustomModels.Filters;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container.
builder.Services.AddControllers(options =>
{
    // Register global exception filter
    options.Filters.Add(typeof(CustomExceptionFilter));
});

// 🔹 Register custom authorization filter for DI
builder.Services.AddScoped<CustomAuthFilter>();

// 🔹 Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();