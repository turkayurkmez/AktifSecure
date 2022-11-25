using BasicAuthOnAPI.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Basic")
                .AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic", null);

/*
 * http://www.myorigin.com 
 * https://www.myorigin.com 
 * https://accounts.myorigin.com 
 * https://www.myorigin.com:1515 
 * 
 * Aynı orijin:
 * http://www.myorigin.com/hakkimizda 
 */

builder.Services.AddCors(option =>
{
    option.AddPolicy("allow", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
