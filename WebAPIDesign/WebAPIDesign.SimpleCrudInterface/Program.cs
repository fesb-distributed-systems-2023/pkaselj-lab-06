using WebAPIDesign.SimpleCrudInterface.Repositories;
using WebAPIDesign.SimpleCrudInterface.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Important: Dependency Injection
/*
 * Singleton - Constructed during server startup
 *           - Lasts until server is shut down
 *           - Data persists between requests
 *           - Visible to all threads/requests
 *           - Prone to deadlocks (Use locks)
 *           
 *  How it works:
 *      Every time a class requests IEmailRepository in its constructor
 *      the server automatically passes it an EmailRespository instance.
 *      The server constructs the EmailRepository object if needed.
 */
builder.Services.AddSingleton<IEmailRepository, EmailRepository>();

/* 
 * Transient - Constructed for each HTTP request
 *           - Lasts until the response is returned
 *           - Data persits only in the specific request
 *           - Data visible to all request-bound objects
 *           - Visible only to the given request
 */
// builder.Services.AddTransient<IEmailRepository, EmailRepository>();

/* 
 * Scoped   - Constructed for each requesting object
 *          - Lasts until the requesting object is destroyed
 *          - Data persits only until the requesting object is destroyed
 *          - Visible only to the requesting object
 */
// builder.Services.AddScoped<IEmailRepository, EmailRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
