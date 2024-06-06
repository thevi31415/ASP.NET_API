using ASP.NET_API.Data;
using ASP.NET_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ASP.NET_API.Model;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDBContext>(options => options.UseSqlServer(

    builder.Configuration.GetConnectionString("DefaultConnection")

    ));
builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
var secretKey = builder.Configuration["AppSettings:SecretKey"];

/*var secretKey = "uhwqutqtzacybhnqefdqyylbzyiebeha";
*/
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication
    (JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = false,
         ValidateAudience = false,

         ValidateIssuerSigningKey = true,

         IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

         ClockSkew = TimeSpan.Zero
     };
 });
   
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "API - NGUYEN DUONG THE VI - HCMUTE - UPDATE - 2");
app.MapControllers();

app.Run();
