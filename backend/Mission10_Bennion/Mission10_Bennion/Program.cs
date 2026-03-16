using Microsoft.EntityFrameworkCore;
using Mission10_Bennion.Data;

// this is where the app gets set up before it actually runs
var builder = WebApplication.CreateBuilder(args);

// telling the app we're using controllers (that's where the API endpoints live)
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// hooking up the database using the connection string from appsettings.json
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingLeague")));

// CORS lets the React frontend (on port 3000) talk to this backend - without this it just blocks everything
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// only show the API docs page when we're running locally
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
// make sure CORS is applied before anything else tries to handle requests
app.UseCors("AllowReact");
app.UseAuthorization();
app.MapControllers();

app.Run();
